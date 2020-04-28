<template>
  <canvas ref="canvas-paint"></canvas>
</template>

<script>
export default {
  name: "paint",
  data: function() {
    return {};
  },
  props: {
    height: {
      type: Number,
      default: window.innerHeight
    },
    width: {
      type: Number,
      default: window.innerWidth
    },
    img: {
      type: String
    }
  },
  methods: {
    draw: function(img) {
      let el = this.$el;
      let ctx = el.getContext("2d");
      let height = this.height;
      let width = this.width;
      // console.log(height, width);
      ctx.canvas.width = width;
      ctx.canvas.height = height;

      let rate=(height * 1.1) / img.height
      let x=0
      let y=0
    //   console.log(rate)
      ctx.drawImage(img, x, y,img.width*rate,img.height*rate);
    },
    init: function() {
      this.$refs["canvas-paint"].height = this.height;
      this.$refs["canvas-paint"].width = this.width;
      let img = new Image();
      img.src = this.img;
      let func = this.draw;
      img.onload = function() {
        func(img);
      };
    }
  },
  mounted: function() {
    this.init();
  }
};
</script>

<style scoped>
canvas {
  pointer-events: none;
}
</style>