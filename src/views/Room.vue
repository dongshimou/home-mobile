<template>
  <div id="room">
    <div id="room-title">
      <label>{{label}}</label>
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
      label:"不去直播间坐坐么?",
      roles: [
        {
          id: 0,
          isNew: false,
          roomId: 4006440
        },
        {
          id: 6,
          isNew: true,
          roomId: 523
        },
        {
          id: 0,
          isNew: false,
          roomId: 45678
        },
        {
          id: 6,
          isNew: false,
          roomId: 1234
        },
        {
          id: 0,
          isNew: false,
          roomId: 1212
        },
        {
          id: 6,
          isNew: false,
          roomId: 2233
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
  margin-top: 12vh;
  margin-bottom: 5vh;
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
  position:absolute;
  bottom: 5vh;
  width: 100%;
}
#room-ref > img {
  margin-top:5vh;
  width: 40%;
  max-width: 100%;
}
</style>
