import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

const state = {
  count: 0,
  token: "",
  meusDados: {}
}

const mutations = {
    INSERIRTOKEN (state, payload) {
      state.token = payload
    },

    CARREGARTOKEN (state) {
      Vue.http.headers.common['Authorization'] = state.token;  
    },

    INSERIRMEUSDADOS (state, payload) {
      state.meusDados = payload
    },

    inserir: state => state.count++,
    decrement: state => state.count--
}


export default new Vuex.Store({
  state,
  mutations
})

