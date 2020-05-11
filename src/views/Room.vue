<template>
  <div id="room">
    <div id="room-title">
      <label>{{label}}</label>
    </div>

    <div id="room-context">
      <live v-for="(role,index) in roles" :key="index" :role="role" />
    </div>
    <div id="room-space">
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
      label: "不去直播间坐坐么?",
      roles: [
        {
          id: 0,
          isNew: false,
          name: "铃果",
          roomId: 21376408
        },
        {
          id: 7,
          isNew: false,
          name: "七柠",
          roomId: 21379626
        },
        {
          id: 6,
          isNew: false,
          name: "陆桃",
          roomId: 21469273
        },
        {
          id: 4,
          isNew: false,
          name: "时音",
          roomId: 21517635
        },
        {
          id: 3,
          isNew: false,
          name: "山梨",
          roomId: 21545501
        },

        {
          id: 1,
          isNew: false,
          name: "柚一",
          roomId: 21623289
        },
        {
          id: 8,
          isNew: false,
          name: "芭娜娜",
          roomId: 21664773
        },
        {
          id: 5,
          isNew: false,
          name: "双荔",
          roomId: 21738080
        },

        // {
        //   id: 9,
        //   isNew: false,
        //   name: "橘九",
        //   roomId: 21420315
        // },
        {
          id: 10,
          isNew: false,
          name: "千橙",
          roomId: 21738056
        },
        {
          id: 100,
          isNew: true,
          name: "未知",
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
#room-space{
  height: 100%;
}
#room-ref {
  position: relative;
  bottom: 5vh;
  height: 30%;
  width: 100%;
}
#room-ref > img {
  /* margin-top: 5vh; */
  width: 40%;
  max-width: 100%;
}
</style>
