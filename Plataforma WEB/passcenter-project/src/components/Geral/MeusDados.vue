<template>
  <div class="row area-exibicao">
    <form class="col s12 card">
      <div class="row topo">
        <span class="card-title">Meus Dados</span>
      </div>
      <div class="row">
        <div class="input-field col s12 m4">
          <input id="nome" type="text" class="validate" v-model="nome">
          <label for="nome">Nome</label>
        </div>
        <div class="input-field col s12 m6">
          <input id="sobrenome" type="text" class="validate" v-model="sobrenomes">
          <label for="sobrenome">Sobrenome</label>
        </div>
        <div class="input-field col s12 m2">
          <input id="data_nascimento" type="text" class="validate" v-model="data_nascimento">
          <label for="data_nascimento">Data de Nascimento</label>
        </div>
      </div>
      <div class="row">
        <div class="input-field col s12 m4">
          <input id="cpf" type="text" class="validate" v-model="CPF">
          <label for="cpf">CPF</label>
        </div>
        <div class="input-field col s12 m4">
          <input id="rg" type="text" class="validate" v-model="RG">
          <label for="rg">RG</label>
        </div>
        <div class="input-field col s12 m4">
          <select v-model="sexo">
            <option value disabled>Selecione um sexo</option>
            <option value="1">Masculino</option>
            <option value="2">Feminino</option>
            <option value="3">Outros</option>
          </select>
          <label>Sexo:</label>
        </div>
      </div>
      <div class="row">
        <div class="input-field col s12 m3">
          <input id="bairro" type="text" class="validate" v-model="bairro">
          <label for="bairro">Bairro</label>
        </div>
        <div class="input-field col s12 m5">
          <input id="rua" type="text" class="validate" v-model="logradouro">
          <label for="rua">Rua</label>
        </div>
        <div class="input-field col s12 m2">
          <input id="numero" type="text" class="validate" v-model="numero">
          <label for="numero">Número</label>
        </div>
        <div class="input-field col s12 m2">
          <input id="cep" type="text" class="validate" v-model="CEP">
          <label for="cep">CEP</label>
        </div>
      </div>
      <div class="row">
        <div class="input-field col s12 m5">
          <input id="municipio" type="text" class="validate" v-model="municipio">
          <label for="municipio">Município</label>
        </div>
        <div class="input-field col s12 m3">
          <select v-model="estado">
            <option value disabled>Selecione um estado</option>
            <option value="AC">Acre</option>
            <option value="AL">Alagoas</option>
            <option value="AP">Amapá</option>
            <option value="AM">Amazonas</option>
            <option value="BA">Bahia</option>
            <option value="CE">Ceará</option>
            <option value="DF">Distrito Federal</option>
            <option value="ES">Espírito Santo</option>
            <option value="GO">Goiás</option>
            <option value="MA">Maranhão</option>
            <option value="MT">Mato Grosso</option>
            <option value="MS">Mato Grosso do Sul</option>
            <option value="MG">Minas Gerais</option>
            <option value="PA">Pará</option>
            <option value="PB">Paraíba</option>
            <option value="PR">Paraná</option>
            <option value="PE">Pernambuco</option>
            <option value="PI">Piauí</option>
            <option value="RJ">Rio de Janeiro</option>
            <option value="RN">Rio Grande do Norte</option>
            <option value="RS">Rio Grande do Sul</option>
            <option value="RO">Rondônia</option>
            <option value="RR">Roraima</option>
            <option value="SC">Santa Catarina</option>
            <option value="SP">São Paulo</option>
            <option value="SE">Sergipe</option>
            <option value="TO">Tocantins</option>
          </select>
          <label>Estado:</label>
        </div>
        <div class="input-field col s12 m4">
          <input id="Complemento" type="text" class="validate" v-model="complemento">
          <label for="Complemento">Complemento</label>
        </div>
      </div>
      <div class="row">
        <div class="input-field col s12 m6">
          <input id="email" type="email" class="validate" v-model="login">
          <label for="email">Email</label>
        </div>
        <div class="input-field col s12 m6">
          <input id="password" type="password" class="validate" autocomplete="no" v-model="senha">
          <label for="password">Senha</label>
        </div>
      </div>
      <div class="row">
        <div class="input-field col s12 m6">
          <input id="tel_residencial" type="text" class="validate" v-model="tel_residencial">
          <label for="tel_residencial">Telefone Residencial:</label>
        </div>
        <div class="input-field col s12 m6">
          <input id="tel_celular" type="text" class="validate" v-model="tel_celular">
          <label for="tel_celular">Telefone Celular:</label>
        </div>
      </div>
      <div class="row">
        <div class="input-field col s12 m12">
          <textarea id="infoadd" class="materialize-textarea" v-model="infoadd"></textarea>
          <label for="infoadd">Informações Adicionais</label>
        </div>
      </div>
      <div class="row">
        <div class="col s12">
          <a class="waves-effect waves-teal btn" @click="confirmacao()">Alterar Dados</a>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
export default {
  nome: "MeusDados",
  data() {
    return {
      nome: "",
      sobrenomes: "",
      data_nascimento: "",
      CPF: "",
      RG: "",
      sexo: "",
      logradouro: "",
      numero: "",
      bairro: "",
      CEP: "",
      municipio: "",
      estado: "",
      complemento: "",
      login: "",
      senha: "",
      tel_residencial: "",
      tel_celular: "",
      infoadd: ""
    };
  },

  mounted() {
    this.$http.get("Pessoas").then(
      response => {
        var dados = response.body[0];

        this.nome = dados.pes_nome;
        this.sobrenomes = dados.pes_sobrenomes;
        (this.data_nascimento = dados.pes_data_nascimento.replace(
          "T00:00:00",
          ""
        )),
          (this.CPF = dados.pes_cpf);
        this.RG = dados.pes_rg;
        this.sexo = dados.pes_sexo;
        this.logradouro = dados.end_logradouro;
        this.numero = dados.end_numero;
        this.bairro = dados.end_bairro;
        this.CEP = dados.end_cep;
        this.municipio = dados.end_municipio;
        this.estado = dados.end_estado;
        this.complemento = dados.end_complemento;
        this.login = dados.usu_login;
        this.senha = dados.usu_senha;
        this.tel_residencial = dados.pes_tel_residencial;
        this.tel_celular = dados.pes_tel_celular;
        this.infoadd = dados.pes_info_adicionais;

        $(document).ready(function() {
          M.updateTextFields();
          $("select").formSelect();
        });
      },
      response => {
        console.log(
          "ERRO! Código de resposta (HTTP) do servidor: " + response.status
        );
      }
    );
  },

  methods: {
    confirmacao() {
      const swalWithBootstrapButtons = swal.mixin({
        confirmButtonClass: "btn green sepraracaoBotoes",
        cancelButtonClass: "btn red sepraracaoBotoes",
        buttonsStyling: false
      });

      swalWithBootstrapButtons({
        title: "Você tem certeza?",
        text: "Você não poderá reverter essa ação!",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sim, faça!",
        cancelButtonText: "Não, cancele!",
        reverseButtons: true
      }).then(result => {
        if (result.value) {
          const dodosPessoais = {
            pes_nome: this.nome,
            pes_sobrenomes: this.sobrenomes,
            pes_data_nascimento: this.data_nascimento,
            pes_cpf: this.CPF,
            pes_rg: this.RG,
            pes_sexo: this.sexo,
            pes_tel_residencial: this.tel_residencial,
            pes_tel_celular: this.tel_celular,
            pes_info_adicionais: this.infoadd
          };

          var dodosEndereco = {
            end_logradouro: this.logradouro,
            end_numero: this.numero,
            end_bairro: this.bairro,
            end_municipio: this.municipio,
            end_cep: this.CEP,
            end_estado: this.estado,
            end_complemento: this.complemento
          };

          var dodosUsuario = {
            usu_login: this.login,
            usu_senha: this.senha
          };

          this.$http.put("Pessoas/MeusDados", dodosPessoais).then(
            response => {
              this.$http.put("Enderecos/MeusDados", dodosEndereco).then(
                response => {
                  this.$http.put("Usuarios/MeusDados", dodosUsuario).then(
                    response => {
                      swalWithBootstrapButtons(
                        "Alterado!",
                        "As alterações foram salvas.",
                        "success"
                      );
                    },
                    response => {
                      erro("Dados do Usuário", response.status);
                    }
                  );
                },
                response => {
                  erro("Endereço", response.status);
                }
              );
            },
            response => {
              erro("Dados Pessoais", response.status);
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
            "Cancelado!",
            "Alterações não enviadas!",
            "error"
          );
        }
      });
    }
  }
};
</script>

<style src="./../../assets/css/geral/MeusDados.css" scoped></style>