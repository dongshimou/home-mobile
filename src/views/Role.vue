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
          <img src="@/assets/menu.png" alt="" />
        </div>
      </div>
    </div>
    <!-- 内容 -->
    <div id="role-context">
      <!-- 左区域 -->
      <div id="role-ctx-left">
        <!-- logo -->
        <div id="role-ctx-left-name">
          <img id="role-logo" class="animated bounceInLeft" :src="getImgUrl('logo',role.id)" alt />
          <img id="role-name" class="animated bounceInLeft" :src="getImgUrl('name',role.id)" alt />
        </div>
        <!-- 职业 -->
        <div id="role-ctx-left-job" class="animated bounceInLeft">
          <div id="role-job-checkbox">
            <!-- 文字 -->
            <div id="role-job-checkbox-txt">
              <img src="@/assets/sing.png" alt />
              <img src="@/assets/game.png" alt />
              <img src="@/assets/dance.png" alt />
            </div>
            <!-- 图标 -->
            <div id="role-job-checkbox-img">
              <img class="role-job-checkbox-img-class" src="@/assets/job1.png" alt />
              <img class="role-job-checkbox-img-class" src="@/assets/job2.png" alt />
              <img class="role-job-checkbox-img-class" src="@/assets/job3.png" alt />
            </div>
          </div>
        </div>
      </div>
      <!-- 右区域 -->
      <div id="role-ctx-right"></div>
    </div>
    <img id="role-arrow" class="animated infinite bounce slow" src="@/assets/arrow.png" />
    <div id="role-bottom"></div>
    <!-- <paint
      id="role-paint"
      class="role-npc animated bounceInRight"
      :img="getImgUrl('lihui',role.id ) "
    />-->
    <img
      ref="role-img"
      class="role-npc role-img animated bounceInRight"
      :src="getImgUrl('lihui',role.id)"
      @load="loadRole()"
      alt
    />
    <ring
      id="role-ring"
      :color="role.ring.color"
      :height="role.ring.height"
      :width="role.ring.width"
      :start="start"
    />
    <div id="role-line" />
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
      start: false
    };
  },
  methods: {
    getImgUrl(icon, id) {
      return require("@/assets/" + icon + id + ".png");
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
          }
        };
      }
    }
  },
  mounted: function() {
    this.checkScreen();
  }
};
</script>
<style>
@media screen and (max-width: 480px) {
  :root {
    --height: 32px;
  }
  #role-nav {
    height: var(--height);
  }
  #role-paint {
    top: var(--height);
  }
  #role-context {
    height: calc(100vh - var(--height) - 10vh);
  }
  #role-nav-left {
    margin-left: 16px;
  }
  #role-nav-right {
    margin-right: 16px;
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
    margin-top: calc(var(--height) / 2);
  }
  #role-ctx-left-job {
    margin-left: calc(39px / 2);
  }
  #role-arrow {
    width: calc(57px / 2);
    left: calc(50vw - 57px / 2 / 2);
  }
}
@media screen and (min-width: 480px) and (max-width: 1280px) {
  :root {
    --height: 64px;
  }
  #role-nav {
    height: var(--height);
  }
  #role-paint {
    top: var(--height);
  }
  #role-context {
    height: calc(100vh - var(--height) - 10vh);
  }
  #role-nav-left {
    margin-left: 24px;
  }
  #role-nav-right {
    margin-right: 24px;
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
}
#role {
  display: block;
  flex-direction: row-reverse;
  height: 100%;
  z-index: 1;
}
#role-nav {
  width: 100%;
  text-align: left;
  display: inline-flex;
}
#role-context {
  width: 100%;
  display: flex;
  /* height: 95vh; */
  /* background: url('../assets/lihui02.png'); */
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
}

#role-nav-right {
  width: 50%;
  height: 100%;
  display: flex;
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
  max-width: 130%;
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
  top: var(--height);
  left: 0px;
  position: absolute;
  max-height: 200%;
  height: 100%;
  max-width: 200%;
}
#role-ring {
  left: 0vw;
  top: 0vh;
  position: absolute;
  z-index: 0;
}
#role-paint {
  left: 0vw;
  display: none;
  position: absolute;
}
#role-arrow {
  position: absolute;
  bottom: 10vh;
  z-index: 20;
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
  height: 100%;
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
  height: 100%;
  width: 50%;
  display: flex;
  flex-direction: column;
}
#role-job-checkbox-img > img {
  max-width: 100%;
  max-height: 100%;
  width: 50%;
  height: 50%;
}
.role-job-checkbox-img-class:hover {
  background-color: #1b7eeb;
  border-radius: 10px;
}
</style>

<style>

@keyframes beat{
	from {
		-moz-transform:scale(1,1);
		-webkit-transform:scale(1,1);
		-o-transform:scale(1,1);
		transform:scale(1,1);
	}
	50% {
		-moz-transform:scale(1.15,1.15);
		-webkit-transform:scale(1.15,1.15);
		-o-transform:scale(1.15,1.15);
		transform:scale(1.15,1.15);
	}
	to {
		-moz-transform:scale(1,1);
		-webkit-transform:scale(1,1);
		-o-transform:scale(1,1);
		transform:scale(1,1);
	}
}

.heart{
	animation: beat 0.5s infinite;
}
</style>
