<template>
  <div>
    <div class="row area-exibicao">
      <div class="row espacamento">
        <div class="col s3">
          <div class="card">
            <div class="card-content">
              <div class="input-field">
                <select v-model="instituicao">
                  <option value disabled selected>Selecione a Instituição</option>
                  <option
                    :value="item"
                    v-for="item in instituicoes"
                    :key="item.id"
                  >{{ item.ins_nome_fantasia }}</option>
                </select>
                <label>Instituição</label>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div v-if="selecionou">
        <div v-if="identificadores.length != 0">
          <div class="col s12 m3 espacamento" v-for="item in identificadores" :key="item.id">
            <div class="card">
              <div class="card-content modal-trigger" href="#modal" @click="identificador = item">
                <br />
                <h3 class="cardDisciplina">{{ item.ata_identificador }}</h3>
                <br />
                <br />
              </div>
            </div>
          </div>

          <div class="col s12 m3 espacamento">
            <div class="card">
              <div class="card-content">
                <div class="row">
                  <div class="col s12 m12 l12">
                    <h6
                      class="center-align"
                    >Passe a TAG que deseja atrelar em um Totem no modo de Cadastro.</h6>
                  </div>
                </div>
                <div class="row">
                  <div class="col s12 m12 l12">
                    <div class="center-align">
                      <div class="lds-ripple">
                        <div></div>
                        <div></div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div class="row altura" v-else>
          <div class="col offset-m3 m5 s12 card ajuste espacamento">
            <div class="col offset-m1 m10 s12">
              <div class="row">
                <div class="col s12 m12 l12">
                  <h3
                    class="center-align"
                  >Passe a TAG que deseja atrelar em um Totem no modo de Cadastro.</h3>
                </div>
              </div>
              <div class="row">
                <div class="col s12 m12 l12">
                  <div class="center-align">
                    <div class="lds-ripple">
                      <div></div>
                      <div></div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div id="modal" class="modal margem">
      <div class="modal-content">
        <h4 class="centro">Atrelar Identificador</h4>
        <hr />

        <form onsubmit="return false">
          <div class="row">
            <div class="col s12">
              <div class="col s11 input-field">
                <input
                  id="pessoa"
                  placeholder="Entre com o nome da Pessoa"
                  type="text"
                  class="validate"
                  v-model="busca"
                  autofocus
                />
                <label for="pessoa" class="active">Buscar por Nome:</label>
              </div>
              <div class="col s1">
                <a
                  class="btn-floating btn-large waves-effect waves-light iconeBG"
                  @click="buscarPessoas()"
                >
                  <button class="transparent">
                    <i class="material-icons icone">search</i>
                  </button>
                </a>
              </div>
            </div>
          </div>
        </form>

        <div class="row" v-if="mostrarTabela">
          <table>
            <thead class="centro">
              <tr>
                <th>Nome</th>
                <th>Matricula</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="item in pessoas" :key="item.id">
                <td>{{ item.pes_nome + " " + item.pes_sobrenomes }}</td>
                <td>{{ item.pes_matricula }}</td>
                <td>
                  <a
                    class="waves-effect waves-light btn modal-close"
                    @click="confirmacaoAtrelar(item.usu_codigo);"
                  >Selecionar</a>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>

      <div class="modal-footer row col s12 m12 l12">
        <a class="col s12 m4 l4 modal-close waves-effect waves-teal btn red">Cancelar</a>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "AtrelarIdentificadoresADM",
  data() {
    return {
      instituicoes: [],
      identificadores: [],
      pessoas: [],
      instituicao: {},
      intervalo: 0,
      busca: "",
      ide_identificador: 0,
      selecionou: false,
      mostrarTabela: false
    };
  },

  mounted() {
    this.$http.get("Instituicoes").then(
      response => {
        this.instituicoes = response.body;
        $(document).ready(function() {
          $(".modal").modal();
          M.updateTextFields();
          $("select").formSelect();
        });
      },
      response => {
        this.erro("Instituições", response.status);
      }
    );
  },

  beforeDestroy() {
    this.para();
  },

  watch: {
    instituicao(value) {
      this.para();
      this.selecionou = true;
      this.obtemDados();
    }
  },

  methods: {
    obtemDados: function() {
      console.log("Obtendo dados...");
      this.intervalo = setInterval(() => {
        this.$http
          .get("AtrelarTag/ADM", {
            params: { ins_codigo: this.instituicao.ins_codigo }
          })
          .then(
            response => {
              this.identificadores = response.body;
            },
            response => {
              this.para();
              this.erro("Identificadores", response.status);
            }
          );
      }, 1000);
    },

    para() {
      clearInterval(this.intervalo);
    },

    buscarPessoas() {
      this.$http
        .get("Pessoas/todas/ADM", {
          params: { nome: this.busca, ins_codigo: this.instituicao.ins_codigo }
        })
        .then(
          response => {
            this.pessoas = response.body;
            this.mostrarTabela = true;
          },
          response => {
            console.log(
              "ERRO ao carregar os Dados! Código de resposta (HTTP) do servidor: " +
                response.status
            );
          }
        );
    },
    confirmacaoAtrelar(codigo) {
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
          var dadosIdentificadores = {
            ide_codigo: this.identificador.ata_codigo,
            ide_identificador: this.identificador.ata_identificador,
            usu_codigo: {
              usu_codigo: codigo
            }
          };

          this.$http.post("Identificadores", dadosIdentificadores).then(
            response => {
              this.mostrarTabela = false;
              swalWithBootstrapButtons(
                "Salvo!",
                "Todas as informações foram salvas.",
                "success"
              );
            },
            response => {
              this.erro("Dados Identificadores", response.status);
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
        );
    }
  }
};
</script>

<style src="./../../assets/css/administrador/AtrelarTagADM.css" scoped></style>
