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
              <h1 class="login">Login</h1>
            </div>
            <form id="login" onsubmit="return false">
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
                <div class="row">
                  <div class="input-field col s12">
                    <input
                      id="password"
                      type="password"
                      class="validate"
                      autocomplete="current-password"
                      v-model="senha"
                      required
                    >
                    <label for="password">Senha</label>
                  </div>
                </div>
              </div>

              <div class="card-content">
                <button class="waves-effect waves-light btn-large" @click="logar()">Entrar</button>
              </div>
            </form>

            <div class="card-action">
              <a class="esqueciSenha" href="#">Esqueci minha senha</a>
            </div>
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
      login: "",
      senha: ""
    };
  },
  
  mounted: function() {
    if (this.getCookie("Token") != "") {
      this.encaminhar(this.getCookie("TipoUser"));
    }
  },

  methods: {
    getCookie(cname) {
      var name = cname + "=";
      var decodedCookie = decodeURIComponent(document.cookie);
      var ca = decodedCookie.split(";");
      for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == " ") {
          c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
          return c.substring(name.length, c.length);
        }
      }
      return "";
    },

    logar() {
      var sha512 = require("js-sha512");

      var form = document.getElementById("login");
      var isValidForm = form.checkValidity();

      if (isValidForm) {
        this.$http
          .post("Tokens", {
            usu_login: this.login,
            usu_senha: sha512(this.senha)
          })
          .then(
            response => {
              var dados = response.body;
              this.$store.commit("INSERIRTOKEN", dados[0]);
              this.$store.commit("INSERIRTIPOUSER", dados[1]);
              this.$store.commit("CARREGARTOKEN");

              var d = new Date();
              d.setTime(d.getTime() + 30 * 60 * 1000);
              var expires = "expires=" + d.toUTCString();

              document.cookie =
                "Token=" + dados[0] + ";" + expires + "; path=/";
              document.cookie =
                "TipoUser=" + dados[1] + ";" + expires + "; path=/";
              console.log("ola");

              this.encaminhar(dados[1]);
            },
            response => {
              console.log(
                "ERRO! Código de resposta (HTTP) do servidor: " +
                  response.status
              );
            }
          );
      }
    },

    encaminhar(dados) {
      if (dados == 5) {
        this.$router.push("aluno");
      } else if (dados == 4) {
        this.$router.push("professor");
      } else if (dados == 3) {
        this.$router.push("gerenteCadastro");
      } else if (dados == 2) {
        this.$router.push("gerenteGeral");
      } else if (dados == 1) {
        this.$router.push("administrador");
      }
    }
  }
};
</script>

<style src="./../../assets/css/geral/Login.css" scoped></style>



