import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

const state = {
  token: "",
}

const mutations = {
    INSERIRTOKEN (state, payload) {
      state.token = payload
    },

    CARREGARTOKEN (state) {
      Vue.http.headers.common['Authorization'] = state.token;  
    },
}


export default new Vuex.Store({
  state,
  mutations
})

