<template>
  <div>
    <div class="grey lighten-3 menu-superior">
      <a href="#" class="center-align">
        <router-link :to="{ name: 'Home' }">
          <img src="./../../assets/img/logo.png">
        </router-link>
      </a>
    </div>

    <div class="container">
      <div class="row">
        <div class="col offset-m3 m6 s12 ajuste">
          <div class="card">
            <div class="row">
              <h1 class="login">Esqueci Minha Senha</h1>
            </div>
            <form id="redefinirSenha" onsubmit="return false">
              <div class="formulario">
                <div class="row">
                  <div class="input-field col s12">
                    <input
                      id="email"
                      type="email"
                      class="validate"
                      autocomplete="username email"
                      v-model="login"
                      required
                    >
                    <label for="email">Email</label>
                  </div>
                </div>
              </div>

              <div class="card-content">
                <button class="waves-effect waves-light btn-large" @click="redefinirSenha()">Entrar</button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Login",
  data() {
    return {
      login: ""
    };
  },
  methods: {
    redefinirSenha() {
      var form = document.getElementById("redefinirSenha");
      var isValidForm = form.checkValidity();

      if (isValidForm) {
        var dodosUsuario = {
          usu_login: this.login
        };

        this.$http.put("Usuarios/EsqueciMinhaSenha", dodosUsuario).then(
          response => {
            swal(
              "Pronto!",
              "Enviamos um e-mail com uma senha temporária!",
              "success"
            );
            this.$store.commit("LOGOUT");
            this.$router.push("/Login");
          },
          response => {
            this.erro("Dados do Usuário", response.status);
          }
        );
      }
    },
    erro(msg, code) {
      swal({
        title: "Oops!",
        text: "Algo deu errado! Entre em contato com os Administradores!",
        type: "error"
      }),
        console.log(
          "ERRO em " + msg + "! Código de resposta (HTTP) do servidor: " + code
        )
    }
  }
};
</script>

<style src="./../../assets/css/geral/Login.css" scoped></style>



