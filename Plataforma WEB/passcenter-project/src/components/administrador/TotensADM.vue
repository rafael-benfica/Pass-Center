<template>
  <div>
    <div class="row area-exibicao">
      <div
        class="col s12 m3 espacamento"
        v-for="(item, index) in totens"
        :key="item.id"
        @click="verDados(index)"
      >
        <div class="card modal-trigger" href="#modalVer">
          <div class="card-content">
            <h3 class="cardDisciplina">{{ item.tot_nome }}</h3>
            <h5 class="cardDisciplina">{{ item.tot_numero_serie }}</h5>
            <h5 class="cardDisciplina green" v-if="item.tot_operacao">ATIVO</h5>
            <h5 class="cardDisciplina orange" v-else>OCIOSO</h5>
            <br>
          </div>
        </div>
      </div>
      <div class="col s12 m3 l3 espacamento">
        <a class="modal-trigger" href="#modalAdd" @click="addDados()">
          <div class="card">
            <div class="card-content">
              <h5 class="cardDisciplina">Adicionar</h5>
              <h3 class="cardDisciplina">
                <i class="icone material-icons">add_circle_outline</i>
              </h3>
            </div>
          </div>
        </a>
      </div>
    </div>

    <div id="modalAdd" class="modal margem">
      <div class="modal-content">
        <h4 class="centro">Cadastro Totem</h4>
        <hr>

        <div class="row col s12 m12 l12">
          <div class="input-field col s12 m4">
            <select v-model="instituicao">
              <option value disabled selected>Selecione a Instituição</option>
              <option
                :value="item.ins_codigo"
                v-for="item in instituicoes"
                :key="item.id"
              >{{ item.ins_nome_fantasia }}</option>
            </select>
            <label>Instituição</label>
          </div>
          <div class="input-field col s12 m4">
            <input id="nome" type="text" class="validate" v-model="nome">
            <label for="nome">Nome:</label>
          </div>

          <div class="input-field col s12 m4">
            <input id="numero_serie" type="text" class="validate" v-model="numero_serie">
            <label for="numero_serie">Número de Série:</label>
          </div>
        </div>

        <div class="modal-footer row col s12 m12 l12">
          <a class="col s12 m4 l4 modal-close waves-effect waves-teal btn red">Cancelar</a>
          <p class="col s12 m4 l4"></p>
          <a
            class="col s12 m4 l4 waves-effect waves-teal btn green"
            @click="confirmacaoCriar()"
          >Confirmar</a>
        </div>
      </div>
    </div>

    <div id="modalVer" class="modal margem">
      <div class="modal-content">
        <h4 class="centro">Totem</h4>
        <hr>

        <div class="row col s12 m12 l12">
          <div class="input-field col s12 m4">
            <select v-model="instituicao">
              <option value disabled selected>Selecione a Instituição</option>
              <option
                :value="item.ins_codigo"
                v-for="item in instituicoes"
                :key="item.id"
              >{{ item.ins_nome_fantasia }}</option>
            </select>
            <label>Instituição</label>
          </div>
          <div class="input-field col s12 m4">
            <input id="nome" type="text" class="validate" v-model="nome">
            <label for="nome">Nome:</label>
          </div>

          <div class="input-field col s12 m4">
            <input id="numero_serie" type="text" class="validate" v-model="numero_serie">
            <label for="numero_serie">Número de Série:</label>
          </div>
        </div>

        <div class="modal-footer row col s12 m12 l12">
          <a class="col s12 m4 l4 modal-close waves-effect waves-teal btn red">Cancelar</a>
          <p class="col s12 m4 l4"></p>
          <a
            class="col s12 m4 l4 waves-effect waves-teal btn green"
            @click="confirmacaoUpdate()"
          >Confirmar</a>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Totens",
  data() {
    return {
      totens: [],
      instituicoes: [],
      instituicao: 0,
      codigo: 0,
      nome: "",
      numero_serie: ""
    };
  },

  mounted() {
    this.carregarDados(),
      $(document).ready(function() {
        $(".modal").modal();
        $("select").formSelect();
      });

    this.$http.get("Instituicoes").then(
      response => {
        this.instituicoes = response.body;
      },
      response => {
        this.erro("Instituições", response.status);
      }
    );
  },

  methods: {
    carregarDados() {
      this.$http.get("Totens/ADM").then(
        response => {
          this.totens = response.body;
        },
        response => {
          console.log(
            "ERRO ao carregar os Dados! Código de resposta (HTTP) do servidor: " +
              response.status
          );
        }
      );
    },

    verDados(index) {
      var dados = this.totens[index];

      this.instituicao = dados.ins_codigo;
      this.codigo = dados.tot_codigo;
      this.nome = dados.tot_nome;
      this.numero_serie = dados.tot_numero_serie;
      $(document).ready(function() {
        M.updateTextFields();
        $("select").formSelect();
      });
    },

    addDados() {
      this.instituicao = 0;
      this.codigo = 0;
      this.nome = "";
      this.numero_serie = "";
      $(document).ready(function() {
        M.updateTextFields();
        $("select").formSelect();
      });
    },

    confirmacaoCriar() {
      const swalWithBootstrapButtons = swal.mixin({
        confirmButtonClass: "btn green sepraracaoBotoes",
        cancelButtonClass: "btn red sepraracaoBotoes",
        buttonsStyling: false
      });

      swalWithBootstrapButtons({
        title: "Todos os dados estão corretos?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sim, Crie!",
        cancelButtonText: "Não, cancele!",
        reverseButtons: true
      }).then(result => {
        if (result.value) {
          var dadosTotem = {
            tot_nome: this.nome,
            tot_numero_serie: this.numero_serie,
            ins_codigo: {
              ins_codigo: this.instituicao
            }
          };

          this.$http.post("Totens", dadosTotem).then(
            response => {
              this.carregarDados();
              swalWithBootstrapButtons(
                "Salvo!",
                "Todas as informações foram salvas.",
                "success"
              );
            },
            response => {
              this.erro("Dados Totem", response.status);
            }
          );
        } else if (result.dismiss === swal.DismissReason.cancel) {
          this.carregarDados(),
            swalWithBootstrapButtons(
              "Okay!",
              "Revise/altere o que for necessário ;)",
              "info"
            );
        }
      });
    },

 confirmacaoUpdate() {
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
          var dadosTotem = {
            tot_codigo: this.codigo,
            tot_nome: this.nome,
            tot_numero_serie: this.numero_serie,
            ins_codigo: {
              ins_codigo: this.instituicao
            }
          };

                  this.$http.put("Totens/ADM", dadosTotem).then(
                    response => {
                      this.carregarDados();
                      swalWithBootstrapButtons(
                        "Alterado!",
                        "As alterações foram salvas.",
                        "success"
                      );
                    },
                    response => {
                      this.erro("Dados do Totem", response.status);
                    }
                  );

        } else if (
          // Read more about handling dismissals
          result.dismiss === swal.DismissReason.cancel
        ) {
          this.carregarDados();
          swalWithBootstrapButtons(
            "Cancelado!",
            "Alterações não enviadas!",
            "error"
          );
        }
      });
    },

    erro(msg, code) {
      swal({
        title: "Oops!",
        text: "Algo deu errado! Os dados não foram salvos!",
        type: "error"
      }),
        console.log(
          "ERRO ao atualizar " +
            msg +
            "! Código de resposta (HTTP) do servidor: " +
            code
        ),
        this.carregarDados();
    }
  }
};
</script>


<style src="./../../assets/css/gerenteGeral/Geral.css" scoped></style>
