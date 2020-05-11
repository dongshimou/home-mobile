<template>
  <div id="role" :style="{'background-color':role.background.color}">
    <!-- 顶栏 -->
    <div id="role-nav">
      <div id="role-nav-left">
        <div class="role-nav-box">
          <a :href="role.link.weibo">
            <img src="@/assets/icon/xinlang.png" alt />
          </a>
        </div>
        <div class="role-nav-box">
          <a :href="role.link.wechat">
            <img src="@/assets/icon/weixin.png" alt />
          </a>
        </div>
        <div class="role-nav-box">
          <a :href="role.link.qq">
            <img src="@/assets/icon/qq.png" alt />
          </a>
        </div>
      </div>
      <div id="role-nav-right">
        <div class="role-nav-btn role-nav-box">
          <img src="@/assets/menu.png" alt />
        </div>
      </div>
    </div>
    <!-- 内容 -->
    <div id="role-context">
      <!-- 左区域 -->
      <div id="role-ctx-left">
        <!-- logo -->
        <div id="role-ctx-left-name">
          <img id="role-logo" class="animated bounceInLeft" :src="getImgUrl('logo/',role.id)" alt />
          <img id="role-name" class="animated bounceInLeft" :src="getImgUrl('name/',role.id)" alt />
          <!-- <img id="role-logo" :src="getImgUrl('logotest',role.id)" alt=""/> -->
        </div>
        <!-- 职业 -->
        <div id="role-ctx-left-job" class="animated bounceInLeft">
          <div id="role-job-checkbox">
            <!-- 文字 -->
            <div id="role-job-checkbox-txt">
              <img
                v-for="(job,index) in role.job"
                :src="getImgUrl('label',job.name)"
                alt
                :key="index"
              />
            </div>
            <!-- 图标 -->
            <div id="role-job-checkbox-img">
              <img
                class="role-job-checkbox-img-class"
                v-for="(job,index) in role.job"
                :src="getImgUrl('icon',job.name)"
                alt
                :key="index"
                :style="{'background-color':job.color}"
                :class="{imgLight:!istrans(job.color)}"
              />
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="role-container">
      <img
        ref="role-img"
        class="role-npc role-img animated bounceInRight"
        :src="getImgUrl('lihui/',role.id)"
        @load="loadRole()"
        alt
      />
    </div>
    <div class="role-container">
      <img :src="getImgUrl('circle/',role.id)" alt class="role-img heart" @load="load_ring=true" />
    </div>

    <img id="role-arrow" class="animated infinite bounce slow" src="@/assets/arrow.png" />
    <div id="role-bottom"></div>
    <div id="role-line" :style="{'background-color':role.line.color}" />
    <ring
      id="role-ring"
      :color="role.ring.color"
      :height="role.ring.height"
      :width="role.ring.width"
      :start="false"
    />
  </div>
</template>
<script>
import Ring from "@/components/Ring.vue";
// import Paint from "@/components/Paint.vue";
export default {
  name: "role",
  //   install: function(vue) {
  //     vue.component(this.name, this);
  //   },
  components: {
    // Paint,
    Ring
  },
  data: function() {
    return {
      start: false,
      load_role: false,
      load_ring: false
    };
  },
  methods: {
    getImgUrl(icon, id) {
      return require("@/assets/" + icon + id + ".png");
    },
    istrans(c) {
      return c == "#ffffff00";
    },
    checkScreen() {
      let width = window.innerWidth;
      if (width < 480) {
        this.role.ring.space = 24;
      } else if (width < 1280) {
        this.role.ring.space = 48;
      }
      // save img size
    },
    loadRole() {
      let el = this.$refs["role-img"];
      this.$store.state.role.height = el.height;
      this.$store.state.role.width = el.width;
      this.role.ring.height = el.height;
      this.role.ring.width = el.width;
      // console.log("role.ring", that.role.ring, "el", el.height, el.width);
      this.start = true;
      this.load_role = true;
    },
    loadSuccess() {
      if (this.load_role && this.load_ring) {
        this.$emit("load");
        console.log("emit load")
      }
    }
  },
  watch: {
    load_role: function() {
      this.loadSuccess();
    },
    load_ring: function() {
      this.loadSuccess();
    }
  },
  props: {
    role: {
      type: Object,
      default: function() {
        return {
          id: 0, // 0 1 6 7 8
          link: {
            weibo: "//weibo.com",
            wechat: "//wechat.com",
            qq: "//qq.com"
          },
          job: [
            {
              name: "sing",
              color: "#ffffff00"
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
            height: window.outerHeight,
            width: window.outerWidth,
            space: 24
          },
          background: {
            color: "#3d9def"
          },
          line: {
            color: "#ffffff"
          }
        };
      }
    }
  },
  mounted: function() {
    this.checkScreen();
    this.$emit("load");
  }
};
</script>
<style>
@media screen and (max-width: 425px) {
  :root {
    --height: 32px;
  }
  .role-nav-box {
    width: var(--height);
    height: var(--height);
    margin-right: calc(var(--height) / 4);
  }
  #role-logo {
    left: calc(39px / 2);
  }
  #role-ctx-left-name {
    margin-top: calc(var(--height));
  }
  #role-ctx-left-job {
    margin-left: calc(39px / 2);
  }
  #role-arrow {
    width: calc(57px / 3 * 2);
    left: calc(50vw - 57px / 3);
  }
}
@media screen and (min-width: 426px) and (max-width: 768px) {
  :root {
    --height: 48px;
  }
  .role-nav-box {
    width: var(--height);
    height: var(--height);
    margin-right: calc(var(--height) / 4);
  }
  #role-logo {
    left: calc(39px / 2);
  }
  #role-ctx-left-name {
    margin-top: calc(var(--height));
    max-width: 30vw;
  }
  #role-ctx-left-job {
    margin-left: calc(39px / 2);
  }
  #role-arrow {
    width: calc(57px);
    left: calc(50vw - 57px / 2);
  }
}
@media screen and (min-width: 769px) and (max-width: 1024px) {
  :root {
    --height: 64px;
  }
  .role-nav-box {
    width: var(--height);
    height: var(--height);
    margin-right: 24px;
  }
  #role-logo {
    left: 39px;
  }
  #role-ctx-left-name {
    margin-top: calc(var(--height) / 2);
    max-width: 30vw;
  }
  #role-ctx-left-job {
    margin-left: 39px;
  }
  #role-arrow {
    width: 57px;
    left: calc(50vw - 57px / 2);
  }
}
@media screen and (min-width: 1280px) {
  :root {
    --height: 64px;
  }
  #role-ctx-left-name {
    margin-top: calc(var(--height));
    max-width: 30vw;
  }
}

.role-container {
  width: 100%;
  display: flex;
  height: calc(115% - var(--height));
  top: var(--height);
  margin: auto;
  position: absolute;
}
.role-nav-box > a > img {
  width: 100%;
}
.role-nav-box > img {
  width: 100%;
}
#role {
  display: block;
  flex-direction: row-reverse;
  height: 100%;
  z-index: 1;
}
#role-nav {
  width: 100%;
  height: var(--height);
  text-align: left;
  display: inline-flex;
}
#role-context {
  width: 100%;
  display: flex;
  height: calc(100% - var(--height));
}
#role-bottom {
  height: 10vh;
}
#role-line {
  height: 100%;
  position: absolute;
  left: 0;
  top: 0;
  width: 4px;
  background-color: #c5e2fa;
  z-index: 20;
}
#role-nav-left {
  width: 50%;
  display: flex;
  height: 100%;
  margin-left: calc(var(--height) / 3);
  flex-direction: row;
}

#role-nav-right {
  width: 50%;
  height: 100%;
  display: flex;
  margin-right: calc(var(--height) / 3);
  flex-direction: row-reverse;
}
.role-nav-btn {
  margin: 0px;
}

#role-ctx-left {
  margin: 0 0 0 0vw;
  height: 100%;
  width: 50vw;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
}
#role-logo {
  position: relative;
  max-width: 110%;
  z-index: 5;
}
#role-name {
  right: 3vw;
  float: right;
  position: relative;
  max-width: 230%;
  z-index: 20;
}
#role-cover {
  left: 0vw;
  top: 10vh;
  position: absolute;
  width: 143%;
  max-width: 143%;
  max-height: 143%;
  z-index: 10;
}
.role-npc {
  /* top: 10vh; */
  /* top: 64px; */
  z-index: 10;
}
.role-img {
  /* top: var(--height); */
  /* left: 0px; */
  /* position: absolute; */
  max-height: 200%;
  height: 100%;
  max-width: 200%;
  margin: auto;
}
#role-ring {
  left: 0vw;
  top: 0vh;
  position: absolute;
  z-index: 0;
}
#role-arrow {
  position: absolute;
  /* bottom: calc(5vh); */
  bottom: 3vh;
  z-index: 20;
}
#role-ctx-left-job {
  margin-bottom: 32px;
}

#role-ctx-right {
  height: 100%;
  width: 50vw;
  display: flex;
  flex-direction: column;
  justify-content: center;
}
#role-job-checkbox {
  bottom: 20px;
  position: relative;
}
#role-job-checkbox-txt {
  /* height: 100%; */
  width: 50%;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
}
#role-job-checkbox-txt > img {
  max-width: 100%;
  max-height: 100%;
  width: 70%;
  height: 70%;
  margin-bottom: 15px;
  z-index: 5;
}
#role-job-checkbox-img {
  /* height: 100%; */
  width: 50%;
  display: flex;
  flex-direction: column;
}
#role-job-checkbox-img > img {
  max-width: 100%;
  max-height: 100%;
  width: 50%;
  height: 50%;
  z-index: 5;
  border-radius: 3px;
}
</style>

<style scoped>
.imgLight {
  filter: brightness(100%);
  -webkit-filter: brightness(100%);
  -moz-filter: brightness(100%);
  -ms-filter: brightness(100%);
  -o-filter: brightness(100%);
}
</style>

<style>
@keyframes beatOut {
  from {
    -moz-transform: scale(1, 1);
    -webkit-transform: scale(1, 1);
    -o-transform: scale(1, 1);
    transform: scale(1, 1);
  }
  50% {
    -moz-transform: scale(1.15, 1.15);
    -webkit-transform: scale(1.15, 1.15);
    -o-transform: scale(1.15, 1.15);
    transform: scale(1.15, 1.15);
  }
  to {
    -moz-transform: scale(1, 1);
    -webkit-transform: scale(1, 1);
    -o-transform: scale(1, 1);
    transform: scale(1, 1);
  }
}
@keyframes beatIn {
  from {
    -moz-transform: scale(1, 1);
    -webkit-transform: scale(1, 1);
    -o-transform: scale(1, 1);
    transform: scale(1, 1);
  }
  50% {
    -moz-transform: scale(0.95, 0.95);
    -webkit-transform: scale(0.95, 0.95);
    -o-transform: scale(0.95, 0.95);
    transform: scale(0.95, 0.95);
  }
  to {
    -moz-transform: scale(1, 1);
    -webkit-transform: scale(1, 1);
    -o-transform: scale(1, 1);
    transform: scale(1, 1);
  }
}

.heart {
  animation: beatIn 0.5s infinite;
}
</style>
