<template>
  <div id="room">
    <div id="room-title">
      <label>点击跳转到主播直播间</label>
    </div>

    <div id="room-context">
      <live v-for="(role,index) in roles" :key="index" :role="role" />
    </div>
    <div id="room-ref">
      <img src="@/assets/contact.png" alt />
    </div>
  </div>
</template>

<script>
import Live from "@/components/Live.vue";

export default {
  name: "room",
  components: {
    Live
  },
  data: function() {
    return {
      roles: [
        {
          id: 0,
          isNew: false,
          roomId: 4006440
        },
        {
          id: 6,
          isNew: true,
          roomId: 4006600
        },
        {
          id: 0,
          isNew: false,
          roomId: 4006440
        },
        {
          id: 6,
          isNew: false,
          roomId: 4006603
        },
        {
          id: 0,
          isNew: false,
          roomId: 4006441
        },
        {
          id: 6,
          isNew: false,
          roomId: 4006602
        }
      ]
    };
  },
  mounted: function() {
    console.log(this.roles);
  }
};
</script>

<style scoped>
@media screen and (max-width: 480px) {
  #room-title > label {
    font-size: 90%;
  }
}
@media screen and (min-width: 480px) and (max-width: 1280px) {
  #room-title > label {
    font-size: 150%;
  }
}
#room {
  height: 100%;
  width: 100%;
  display: flex;
  flex-direction: column;
  background-color: black;
}
#room-title {
  margin-top: 15vh;
  margin-bottom: 3vh;
  width: 100%;
}
#room-title > label {
  color: white;
}
#room-context {
  margin-left: 5vw;
  margin-right: 5vw;
  width: auto;
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
}
.role-room {
  width: 30vw;
}
#room-ref {
  width: 100%;
}
#room-ref > img {
  margin-top:5vh;
  width: 40%;
  max-width: 100%;
}
</style>
