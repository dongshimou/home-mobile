<template>
  <div class="live">
    <div id="live-box">
      <img :src="getImgUrl('pixel',role.id)" alt :class="{imgGray:!isOnline}" />
      <div class="live-label">
      <!-- <label class="new-label" v-if="role.isNew">New!</label> -->
      <img src="@/assets/new.png" alt="" v-if="role.isNew"/>
      <!-- <label class="online-label" v-else-if="isOnline">Online</label> -->
      <img src="@/assets/online.png" alt="" v-else-if="isOnline"/>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "live",
  methods: {
    getImgUrl(icon, id) {
      return require("@/assets/" + icon + id + ".png");
    },
    load: function(roomId) {
      this.$http
        .get(this.url, {
          params: { room_id: roomId }
        })
        .then(
          response => {
            // console.log(response);
            if (response.body.data.room_info.online > 0) {
              this.isOnline = true;
            }
          },
          response => {
            console.log(response);
          }
        );
    }
  },
  data: function() {
    return {
      url: "/proxy/live",
      isOnline: false
    };
  },

  props: {
    role: {
      type: Object,
      default: function() {
        return {
          id: 0,
          isNew: false,
          isOnline: false,
          roomId: 4006440
        };
      }
    }
  },
  mounted: function() {
    // console.log("live", this.role);
    this.load(this.role.roomId);
  },
  watch: {}
};
</script>

<style scoped>
.live {
  display: flex;
  flex-direction: column;
  width: calc(90vw / 4);
}

@media screen and (max-width: 480px) {
  .live{
    margin-bottom: 32px;
  }
  #live-box {
    margin-left: 16px;
    margin-right: 16px;
    max-height: 50px;
    max-width: 50px;
  }
}
@media screen and (min-width: 480px) and (max-width: 1280px) {
   .live{
    margin-bottom: 64px;
  }
  #live-box {
    margin-left: 32px;
    margin-right: 32px;
    max-height: 100px;
    max-width: 100px;
  }
  .online-label {
    font-size: 150%;
  }
  .new-label {
    font-size: 150%;
  }
}
#live-box {
  height: 100%;
  width: 100%;
}
.live-label{
margin-top: -10px;
}
.live-label>img{
  width: 70%;
}

.online-label {
  color: white;
}
.new-label {
  color: black;
  text-shadow: 0px 0px 5px #ffffff;
}
</style>

<style>
.imgGray {
  filter: grayscale(100%);
  -webkit-filter: grayscale(100%);
  -moz-filter: grayscale(100%);
  -ms-filter: grayscale(100%);
  -o-filter: grayscale(100%);
  filter: gray;
}
</style>