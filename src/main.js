import Vue from 'vue'
import App from './App.vue'
import store from './store'
import router from './router'

// full page
import 'animate.css'
import '@/other/fullpage/fullpage.css'
import VueFullpage from '@/other/fullpage/index.js'
Vue.use(VueFullpage)

// resize
import 'vue-resize/dist/vue-resize.css'
import VueResize from 'vue-resize'
Vue.use(VueResize)

// http
import VueResource from 'vue-resource'
Vue.use(VueResource);

// loading
import VueLoading from 'vue-loading-template'
Vue.use(VueLoading, /** options **/)

// slideout
import SlideOut from '@hyjiacan/vue-slideout'
import '@hyjiacan/vue-slideout/lib/slideout.css'
// import SlideOut component, and set the defaults props
Vue.use(SlideOut, {
  // set props here
})

Vue.config.productionTip = false

new Vue({
  store,
  router,
  render: h => h(App)
}).$mount('#app')
