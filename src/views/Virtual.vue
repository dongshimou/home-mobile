<template>
  <div id="virtual">
    <div class="fullpage-root" :style="{height:height}">
      <div class="fullpage-container">
        <div class="fullpage-wp" v-fullpage="opts" ref="fullpage">
          <!-- page -->
          <div class="page-0 page">
            <vue-loading
              v-show="!success"
              type="spin"
              color="#ffffff"
              :size="{ width: '50px', height: '50px' }"
              :style="{ 'margin-top' : ['calc(50vh - 25px)']}"
            ></vue-loading>
            <role v-for="(role,index) in roles" v-show="success&&index==cur" :role="role" :key="index" />
          </div>
          <!-- <div class="page-1 page">
            <img src="@/assets/1.png" />
          </div>-->
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
      success: false,
      height: "0px",
      cur: 0,
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
              name:"sing",
              color:"#176fe3"
            },
            {
              name:"game",
              color:"#ffffff00"
            },
            {
              name:"dance",
              color:"#ffffff00"
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
              name:"sing",
              color:"#6435ce"
            },
            {
              name:"game",
              color:"#ffffff00"
            },
            {
              name:"dance",
              color:"#ffffff00"
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
              name:"sing",
              color:"#ff886c"
            },
            {
              name:"game",
              color:"#ffffff00"
            },
            {
              name:"dance",
              color:"#ffffff00"
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
              name:"sing",
              color:"#ff82c4"
            },
            {
              name:"game",
              color:"#ffffff00"
            },
            {
              name:"dance",
              color:"#ffffff00"
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
              name:"game",
              color:"#13aea6"
            },
            {
              name:"sing",
              color:"#ffffff00"
            },
            {
              name:"dance",
              color:"#ffffff00"
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
      }, 2000);
    }
  },
  created: function() {},
  mounted: function() {
    this.height = window.innerHeight + "px";
    this.loading();
  }
};
</script>

<style>
.page-2 {
  background-color: black;
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
