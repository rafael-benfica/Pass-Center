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
              <h1 class="login">Redefinir Senha</h1>
            </div>
            <form id="atualizarSenha" onsubmit="return false">
              <div class="formulario">
                <div class="row">
                  <div class="input-field col s12">
                    <input
                      id="senha_nova"
                      type="password"
                      :class="classNova"
                      v-model="senha_nova"
                      autocomplete="new-password"
                      required
                    >
                    <label for="senha_nova">Nova Senha:</label>
                    <span class="helper-text" :data-error="msg_erro"/>
                  </div>
                </div>
                <div class="row">
                  <div class="input-field col s12">
                    <input
                      id="senha_conf"
                      type="password"
                      :class="classConf"
                      v-model="senha_conf"
                      autocomplete="confirm-new-password"
                      required
                    >
                    <label for="senha_conf">Confirme Nova Senha:</label>
                    <span class="helper-text" data-error="As senhas não coincidem!"/>
                  </div>
                </div>
              </div>

              <div class="card-content">
                <button class="waves-effect waves-light btn-large" @click="trocarSenha()">Redefinir Senha</button>
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
  name: "RedefinirSenha",
  data() {
    return {
      senha: "",
      senha_conf: "",
      senha_nova: "",
      msg_erro: "",

      classNova: "",
      classConf: ""
    };
  },
  mounted() {
    this.$http.get("Pessoas").then(
      response => {
        this.senha = response.body[0].usu_senha;
      },
      response => {
        console.log(
          "ERRO! Código de resposta (HTTP) do servidor: " + response.status
        );
      }
    );
  },

  watch: {
    senha_nova(value) {
      var sha512 = require("js-sha512");

      if (this.senha_nova != this.senha_conf) {
        this.classConf = "invalid";
      } else {
        this.classConf = "valid";
      }

      if (this.senha_nova == "") {
        this.classNova = "validate";
        this.msg_erro = "Campo obrigatório";
      } else if (sha512(this.senha_nova) == this.senha) {
        this.classNova = "invalid";
        this.msg_erro = "A Nova senha não pode ser igual a Senha Atual!";
      } else {
        this.classNova = "valid";
      }
    },
    senha_conf(value) {
      if (this.senha_conf == "") {
        this.classConf = "validate";
      } else if (this.senha_nova != this.senha_conf) {
        this.classConf = "invalid";
      } else {
        this.classConf = "valid";
      }
    }
  },

  methods: {
    trocarSenha() {
      var form = document.getElementById("atualizarSenha");
      var isValidForm = form.checkValidity();

      if (isValidForm) {
        const swalWithBootstrapButtons = swal.mixin({
          confirmButtonClass: "btn green sepraracaoBotoes",
          cancelButtonClass: "btn red sepraracaoBotoes",
          buttonsStyling: false
        });

        swalWithBootstrapButtons({
          title: "Você tem certeza?",
          text: "Após redefinir a senha, você será levado para a página de login!",
          type: "warning",
          showCancelButton: true,
          confirmButtonText: "Sim, faça!",
          cancelButtonText: "Não, cancele!",
          reverseButtons: true
        }).then(result => {
          if (result.value) {
            var sha512 = require("js-sha512");

            var senhas = {
              senhaAtual: this.senha,
              senhaNova: sha512(this.senha_conf)
            };

            this.$http.put("Usuarios/Senha", senhas).then(
              response => {
                $(document).ready(function() {
                  $("#modalAlterarSenha").modal("close");
                });
                swalWithBootstrapButtons(
                  "Alterado!",
                  "A sua senha foi alterada com sucesso!",
                  "success"
                );
                this.$store.commit('LOGOUT');
                this.$router.push("/Login");
              },
              response => {
                erro("Dados do Usuário", response.status);
              }
            );

            function erro(msg, code) {
              swalWithBootstrapButtons(
                "Ops!",
                "Algo deu errado! Alterações não realizadas! Entre em contato o Administrador!",
                "error"
              );
              console.log(
                "ERRO ao atualizar " +
                  msg +
                  "! Código de resposta (HTTP) do servidor: " +
                  code
              );
            }
          } else if (
            // Read more about handling dismissals
            result.dismiss === swal.DismissReason.cancel
          ) {
            swalWithBootstrapButtons(
              "Okay!",
              "Revise/altere o que for necessário ;)",
              "info"
            );
          }
        });
      }
    }
  }
};
</script>

<style src="./../../assets/css/geral/Login.css" scoped></style>



