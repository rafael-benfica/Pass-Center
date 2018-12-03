import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

const state = {
  rootAPI: "http://localhost:51474/api",
  count: 0,
  token: "",
}

const mutations = {
    INSERIRTOKEN (state, payload) {
        state.token = payload
      },
    inserir: state => state.count++,
    decrement: state => state.count--
}

export default new Vuex.Store({
  state,
  mutations
})

