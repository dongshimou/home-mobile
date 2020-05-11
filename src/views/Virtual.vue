<template>
  <div id="virtual">
    <vue-loading
      v-show="!success"
      type="spin"
      color="#ffffff"
      :size="{ width: '50px', height: '50px' }"
      :style="{ 'margin-top' : ['calc(50vh - 25px)'], 'margin-bottom':['calc(50vh - 25px)']}"
    ></vue-loading>
    <div class="fullpage-root" :style="{height:height}">
      <div class="fullpage-container">
        <div class="fullpage-wp" v-fullpage="opts" ref="fullpage">
          <!-- page -->
          <div class="page-0 page" :style="{height:height}">
            <role
              v-for="(role,index) in roles"
              v-show="success&&index==cur"
              :role="role"
              :key="index"
              @loadimg="loadCount()"
            />
            <!-- <role :role="roles[1]" @load="success=true" /> -->
          </div>
          <!-- <div class="page-1 page">
            <img src="@/assets/1.png" />
          </div> -->
          <div class="page-2 page" :style="{height:height}">
            <room />
          </div>
          <!-- <div class="page-3 page">
            <img src="@/assets/2.png" />
          </div>-->
        </div>
      </div>
    </div>
    <div id="page-wide" style="display: block;" v-show="isWide">
      <div id="page-wide-box">
        <img
          src="@/assets/route.png"
          id="wide-box-img"
          style="display:inline-block;"
          width="128"
          height="194"
        />
        <span id="wide-box-txt">为了更好的体验，请将手机/平板竖过来</span>
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
      success: false,
      height: "0px",
      cur: 0,
      count: 0,
      isWide: false,
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
          job: [
            {
              name: "sing",
              color: "#176fe3"
            },
            {
              name: "game",
              color: "#ffffff00"
            },
            {
              name: "dance",
              color: "#ffffff00"
            }
          ],
          ring: {
            color: "#1b7eeb",
            height: window.innerHeight,
            width: window.innerWidth,
            space: 24
          },
          background: {
            color: "#3d9def"
          },
          line: {
            color: "#ffffff"
          }
        },

        {
          id: 1, // 0 1 6 7 8
          link: {
            weibo: "//weibo.com",
            wechat: "//wexin.com",
            qq: "//qq.com"
          },
          job: [
            {
              name: "sing",
              color: "#6435ce"
            },
            {
              name: "game",
              color: "#ffffff00"
            },
            {
              name: "dance",
              color: "#ffffff00"
            }
          ],
          ring: {
            color: "#171241",
            height: window.innerHeight,
            width: window.innerWidth,
            space: 24
          },
          background: {
            color: "#34288e"
          },
          line: {
            color: "#ffffff"
          }
        },
        {
          id: 6, // 0 1 6 7 8
          link: {
            weibo: "//weibo.com",
            wechat: "//wexin.com",
            qq: "//qq.com"
          },
          job: [
            {
              name: "sing",
              color: "#ff886c"
            },
            {
              name: "game",
              color: "#ffffff00"
            },
            {
              name: "dance",
              color: "#ffffff00"
            }
          ],
          ring: {
            color: "#fd9964",
            height: window.outerHeight,
            width: window.outerWidth,
            space: 24
          },
          background: {
            color: "#ffc07d"
          },
          line: {
            color: "#ffffff"
          }
        },
        {
          id: 7, // 0 1 6 7 8
          link: {
            weibo: "//weibo.com",
            wechat: "//wexin.com",
            qq: "//qq.com"
          },
          job: [
            {
              name: "sing",
              color: "#ff82a4ff"
            },
            {
              name: "game",
              color: "#ffffff00"
            },
            {
              name: "dance",
              color: "#ffffff00"
            }
          ],
          ring: {
            color: "#f77196",
            height: window.innerHeight,
            width: window.innerWidth,
            space: 24
          },
          background: {
            color: "#ffa3be"
          },
          line: {
            color: "#ffffff"
          }
        },
        {
          id: 8, // 0 1 6 7 8
          link: {
            weibo: "//weibo.com",
            wechat: "//wexin.com",
            qq: "//qq.com"
          },
          job: [
            {
              name: "game",
              color: "#13aea6"
            },
            {
              name: "sing",
              color: "#ffffff00"
            },
            {
              name: "dance",
              color: "#ffffff00"
            }
          ],
          ring: {
            color: "#25d9af",
            height: window.innerHeight,
            width: window.innerWidth,
            space: 24
          },
          background: {
            color: "#78f3cc"
          },
          line: {
            color: "#ffffff"
          }
        }
      ],
      role: {}
    };
  },
  methods: {
    load: function(i) {
      this.cur = i;
      console.log("load", i);
      this.role = this.roles[i];
      let func = this.load;
      i++;
      if (i >= this.roles.length) {
        i = 0;
      }
      setTimeout(func, 5000, i);
    },
    loading: function() {
      let that = this;
      setTimeout(function() {
        that.success = true;
        that.load(0);
        that.handleResize();
      }, 2000);
    },
    loadCount: function() {
      this.count++;
      if (this.count == this.roles.length) {
        this.loading();
      }
    },
    handleResize: function() {
      if (window.innerWidth > window.innerHeight) {
        this.isWide = true;
      } else {
        this.isWide = false;
      }
      this.initSize();
    },
    initSize: function() {
      this.height = window.innerHeight + "px";
    }
  },
  created: function() {},
  watch: {},
  mounted: function() {
    this.initSize();
    window.addEventListener("resize", this.handleResize);
  }
};
</script>

<style>
.page-2 {
  background-color: black;
}
#page-wide {
  width: 100%;
  height: 100%;
  background: #32373b;
  position: fixed;
  left: 0;
  right: 0;
  top: 0;
  bottom: 0;
  z-index: 9999;
  display: none;
  text-align: center;
}
#page-wide-box {
  position: relative;
  margin-left: auto;
  margin-right: auto;
  top: 50%;
  transform: translateY(-50%);
  -webkit-transform: translateY(-50%);
}
#wide-box-txt {
  font-size: 22px;
  display: block;
  color: #ffd40a;
  text-align: center;
  width: 100%;
  padding-top: 10px;
  line-height: 2;
}
#wide-box-img {
  animation: routeIt 1.5s infinite;
}

@keyframes routeIt {
  0% {
    transform: rotate(-90deg);
  }
  30% {
    transform: rotate(-90deg);
  }
  70% {
    transform: rotate(0deg);
  }
  100% {
    transform: rotate(0deg);
  }
}
</style>

<style scoped>
img {
  width: auto;
  height: auto;
  max-width: 100%;
  max-height: 100%;
}
</style>
