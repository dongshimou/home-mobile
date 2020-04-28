<template>
  <canvas ref="canvas-ring"></canvas>
</template>

<script>
export default {
  name: "ring",
  data: function() {
    return {
      curRing: 1,
      maxRing: 20,
      minRing: 1,
      dir: true
    };
  },
  props: {
    color: {
      type: String,
      default: "#ffcc66"
    },
    height: {
      type: Number,
      default: 0
    },
    width: {
      type: Number,
      default: 0
    },
    start: {
      type: Boolean,
      default: false
    }
  },
  watch: {
    start: function(val) {
      if (val) {
        this.init();
      }
    }
  },
  methods: {
    draw: function() {
      let el = this.$el;
      let ctx = el.getContext("2d");
      //   console.log(ctx);
      let height = this.height;
      let width = this.width;
      ctx.canvas.width = width;
      ctx.canvas.height = height;
      let x = (60 / 100) * width;
      let y = (50 / 100) * height;
      let baseRadius = (30 / 100) * height;
      // console.log(width, height, baseRadius);
      this.maxRing = baseRadius / 20 + 10;
      this.space = width / 30;
      let radius = baseRadius + this.curRing;
      if (this.dir) {
        this.curRing += width / 500;
      } else {
        this.curRing -= width/ 250;
      }
      if (this.curRing > this.maxRing) {
        this.dir = false;
      }
      if (this.curRing < this.minRing) {
        this.dir = true;
      }
      //   console.log(this.dir,this.curRing,radius,this.maxRing,this.minRing)
      ctx.clearRect(0, 0, width + radius * 2, height + radius * 2);
      ctx.beginPath();
      ctx.arc(x, y, radius, 0, Math.PI * 2, false);
      ctx.strokeStyle = this.color;
      ctx.lineWidth = this.space;
      ctx.stroke();
      // ctx.fillStyle=this.color
      // ctx.fillText(ctx.canvas.height, x, y);
      // ctx.fillText(ctx.canvas.width, x, y + 10);
      // ctx.fillText(radius, x, y + 20);
      ctx.closePath();
      window.requestAnimationFrame(this.draw);
    },
    init: function() {
      this.$refs["canvas-ring"].height = this.height;
      this.$refs["canvas-ring"].width = this.width;
      window.requestAnimationFrame(this.draw);
    }
  },
  mounted: function() {
    // this.init();
  }
};
</script>

<style scoped>
canvas {
  pointer-events: none;
}
</style>