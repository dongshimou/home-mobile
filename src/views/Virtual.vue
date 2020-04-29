<template>
  <div id="virtual">
    <div class="fullpage-root">
      <div class="fullpage-container">
        <div class="fullpage-wp" v-fullpage="opts" ref="fullpage">
          <!-- page -->
          <div class="page-0 page">
            <role :role="role"></role>
          </div>
          <div class="page-1 page">
            <img src="@/assets/1.png" />
          </div>
          <div class="page-2 page">
            <room />
          </div>
          <!-- <div class="page-3 page">
            <img src="@/assets/2.png" />
          </div>-->
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Role from "@/views/Role.vue";
import Room from "@/views/Room.vue";
// import Paint from "@/components/Paint.vue"
// import Ring from "@/components/Ring.vue"

export default {
  components: {
    Role,
    Room
  },
  data: function() {
    return {
      opts: {
        start: 0,
        dir: "v",
        duration: 500
      },
      roles: [
        {
          id: 0, // 0 1 6 7 8
          link: {
            weibo: "//weibo.com",
            wechat: "//wexin.com",
            qq: "//qq.com"
          },
          job: {
            sing: true,
            game: true,
            dance: true
          },
          ring: {
            color: "#1b7eeb",
            height: window.outerHeight,
            width: window.outerWidth,
            space: 24
          },
          background: {
            color: "#3d9def"
          },
          line:{
            color:"#ffffff"
          }
        },
        {
          id: 1, // 0 1 6 7 8
          link: {
            weibo: "//weibo.com",
            wechat: "//wexin.com",
            qq: "//qq.com"
          },
          job: {
            sing: true,
            game: true,
            dance: true
          },
          ring: {
            color: "#1b7eeb",
            height: window.outerHeight,
            width: window.outerWidth,
            space: 24
          },
          background: {
            color: "#34288e"
          },
          line:{
            color:"#ffffff"
          }
        },
        {
          id: 6, // 0 1 6 7 8
          link: {
            weibo: "//weibo.com",
            wechat: "//wexin.com",
            qq: "//qq.com"
          },
          job: {
            sing: true,
            game: true,
            dance: true
          },
          ring: {
            color: "#223344",
            height: window.outerHeight,
            width: window.outerWidth,
            space: 24
          },
          background: {
            color: "#ffc07d"
          },
          line:{
            color:"#ffffff"
          }
        },
        {
          id: 7, // 0 1 6 7 8
          link: {
            weibo: "//weibo.com",
            wechat: "//wexin.com",
            qq: "//qq.com"
          },
          job: {
            sing: true,
            game: true,
            dance: true
          },
          ring: {
            color: "#1b7eeb",
            height: window.outerHeight,
            width: window.outerWidth,
            space: 24
          },
          background: {
            color: "#ffa3be"
          },
          line:{
            color:"#ffffff"
          }
        },
        {
          id: 8, // 0 1 6 7 8
          link: {
            weibo: "//weibo.com",
            wechat: "//wexin.com",
            qq: "//qq.com"
          },
          job: {
            sing: true,
            game: true,
            dance: true
          },
          ring: {
            color: "#1b7eeb",
            height: window.outerHeight,
            width: window.outerWidth,
            space: 24
          },
          background: {
            color: "#78f3cc"
          },
          line:{
            color:"#ffffff"
          }
        }
      ],
      role: {}
    };
  },
  methods: {
    load: function(i) {
      console.log("load", i);
      this.role = this.roles[i];
      let func = this.load;
      i++;
      if (i >= this.roles.length) {
        i = 0;
      }
      setTimeout(func, 5000, i);
    }
  },
  created: function() {
    this.load(0);
  },
  mounted: function() {}
};
</script>

<style>
#virtual {
  height: 100vh;
}
img {
  width: auto;
  height: auto;
  max-width: 100%;
  max-height: 100%;
}
.page-2 {
  background-color: black;
}
</style>
