<template>
  <div id="virtual" :class="{blackback:success,blueback:!success}">
    <vue-loading
      v-show="!success"
      type="spin"
      color="#ffffff"
      :size="{ width: '50px', height: '50px' }"
      :style="{ 'padding-top' : ['calc(50vh - 25px)'], 'margin-bottom':['calc(50vh - 25px)'],'background-color':['#ffffff00']}"
    ></vue-loading>
    <slide-out @close="onClose" :visible.sync="showMenu" size="50%">
      <div slot="header"></div>敬请期待
    </slide-out>
    <div class="fullpage-root" :style="{height:height}">
      <div class="fullpage-container">
        <div class="fullpage-wp" v-fullpage="opts" ref="fullpage">
          <!-- page -->
          <div class="page-0 page" :style="{height:height}">
            <div id="role-change">
              <div id="role-left" @click="rolePrev()"></div>
              <div id="role-mid"></div>
              <div id="role-right" @click="roleNext()"></div>
            </div>
            <role
              v-for="(role,index) in roles"
              v-show="success&&index==cur"
              :role="role"
              :key="index"
              @loadimg="loadCount()"
              @popMenu="popMenu()"
            />
            <!-- <role :role="roles[1]" @load="success=true" /> -->
          </div>
          <!-- <div class="page-1 page">
            <img src="@/assets/1.png" />
          </div>-->
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
      pause: 0,
      showMenu: false,
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
          // 0
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
              name: "eat",
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
            color: "#c5e2fa"
          }
        },
        {
          // 7
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
              name: "eat",
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
          // 6
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
              name: "eat",
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
          // 10
          id: 10,
          link: {
            weibo: "//weibo.com",
            wechat: "//wexin.com",
            qq: "//qq.com"
          },
          job: [
            {
              name: "game",
              color: "#f68c60"
            },
            {
              name: "sing",
              color: "#ffffff00"
            },
            {
              name: "eat",
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
            color: "#f9e171"
          },
          line: {
            color: "#ffffff"
          }
        },
        {
          // 3
          id: 3,
          link: {
            weibo: "//weibo.com",
            wechat: "//wexin.com",
            qq: "//qq.com"
          },
          job: [
            {
              name: "game",
              color: "#326f9d"
            },
            {
              name: "sing",
              color: "#ffffff00"
            },
            {
              name: "eat",
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
            color: "#3bcfd0"
          },
          line: {
            color: "#045d7b"
          }
        },
        {
          // 1
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
              name: "eat",
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
            color: "#000000"
          }
        },
        {
          // 8
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
              name: "eat",
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
    apply: function(isNext) {
      if (isNext) {
        this.cur++;
      } else {
        this.cur--;
      }
      if (this.cur >= this.roles.length) {
        this.cur = 0;
      }
      if (this.cur < 0) {
        this.cur = this.roles.length - 1;
      }
      this.role = this.roles[this.cur];
    },
    load: function() {
      if (this.pause <= 0) {
        // console.log("load not pause");
        this.apply(true);
      } else {
        // console.log("load pause");
      }
      let func = this.load;
      setTimeout(func, 5000);
    },
    loading: function() {
      let that = this;
      setTimeout(function() {
        that.success = true;
        that.cur = -1;
        that.load(that.cur);
        that.handleResize();
      }, 2000);
    },
    loadCount: function() {
      this.count++;
      // 未全部加载也要出界面
      if (this.count >= this.roles.length - 1) {
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
    },
    popMenu: function() {
      this.showMenu = !this.showMenu;
    },
    onClose() {
      // this.load(this.cur)
    },
    roleNext() {
      this.pause++;
      this.apply(true);
      let that = this;
      setTimeout(function() {
        that.pause--;
      }, 5000);
    },
    rolePrev() {
      this.pause++;
      this.apply(false);
      let that = this;
      setTimeout(function() {
        that.pause--;
      }, 5000);
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
.blackback {
  background-color: black;
}
.blueback {
  background-color: #3d9def;
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
#role-change {
  position: fixed;
  margin: 30vh 5vw;
  width: calc(100% - 5vw * 2);
  height: calc(100% - 30vh * 2);
  display: flex;
  z-index: 1000;
}
#role-left {
  height: 100%;
  width: 30%;
}
#role-mid {
  height: 100%;
  width: 40%;
  pointer-events: none;
  z-index: 0;
}
#role-right {
  height: 100%;
  width: 30%;
}
</style>
