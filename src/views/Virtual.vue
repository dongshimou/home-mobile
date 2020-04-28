<template>
  <div id="virtual">
    <div class="fullpage-root">
      <div class="fullpage-container">
        <div class="fullpage-wp" v-fullpage="opts" ref="fullpage">
          <!-- page -->
          <div class="page-0 page">
            <role></role>
          </div>
          <!-- <div class="page-1 page">
            <img src="@/assets/1.png" />
          </div> -->
          <div class="page-2 page">
            <room />
          </div>
          <!-- <div class="page-3 page">
            <img src="@/assets/2.png" />
          </div> -->
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
    };
  }
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
