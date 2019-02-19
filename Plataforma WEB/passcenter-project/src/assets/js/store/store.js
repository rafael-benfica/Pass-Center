import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

const state = {
  token: "",
  tipoUser: 0
}

const mutations = {
    INSERIRTOKEN (state, payload) {
      //alert(payload);
      state.token = payload
    },
    INSERIRTIPOUSER (state, payload) {
      //alert(payload);
      state.tipoUser = payload
    },

    CARREGARTOKEN (state) {
      Vue.http.headers.common['Authorization'] = state.token;  
    },

    LOGOUT (state) {
      document.cookie = "Token=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
      document.cookie = "TipoUser=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
      console.log("sair");
    }
}


export default new Vuex.Store({
  state,
  mutations
})

