// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import store from './assets/js/store/store.js'
import VueResource from 'vue-resource';
Vue.use(VueResource);

// Vue.http.options.root = 'http://localhost:51474/api';
// Vue.http.options.root = 'http://192.168.0.70/api';
Vue.http.options.root = 'http://192.168.35.234/api';
// Vue.http.options.root = 'http://192.168.33.41/api';

Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  store,
  template: '<App/>',
  components: { App }
})
