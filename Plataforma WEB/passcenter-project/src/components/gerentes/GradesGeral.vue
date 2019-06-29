<template>
  <div>
    <div class="row area-exibicao">
      <div class="col s12 m4 l4 espacamento" v-for="item in grades" :key="item.id">
        <div class="card">
          <div class="card-image">
            <a
              class="btn-floating halfway-fab waves-effect waves-light modal-trigger"
              href="#modalVer"
              @click="verDados(item);"
            >
              <i class="material-icons">create</i>
            </a>
          </div>
          <div class="card-content modal-trigger" href="#GerirGrade">
            <h3 class="cardDisciplina">{{ item.gra_nome }}</h3>
            <h5
              class="cardDisciplina"
              v-if="item.gra_prox_grade_nome != null"
            >{{ item.gra_prox_grade_nome }}</h5>
            <h5 v-else>Última Grade</h5>
            <br />
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
        <h4 class="centro">Cadastro Grade</h4>
        <hr />

        <div class="row">
          <div class="input-field col s12 m6">
            <input id="nome" type="text" class="validate" v-model="nome" />
            <label for="nome">Nome:</label>
          </div>
          <div class="input-field col s12 m6">
            <select v-model="prox_grade">
              <option value disabled selected>Selecione a próxima Grade</option>
              <option
                :value="item.gra_codigo"
                v-for="item in grades"
                :key="item.id"
              >{{ item.gra_nome }}</option>
            </select>
            <label>Próxima Grade</label>
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
        <h4 class="centro">Grade</h4>
        <hr />

        <div class="row">
          <div class="input-field col s12 m6">
            <input id="nomeVer" type="text" class="validate" v-model="nome" />
            <label for="nomeVer">Nome:</label>
          </div>
          <div class="input-field col s12 m6">
            <select v-model="prox_grade">
              <option value disabled selected>Selecione a próxima Grade</option>
              <option
                :value="item.gra_codigo"
                v-for="item in grades"
                :key="item.id"
              >{{ item.gra_nome }}</option>
            </select>
            <label>Próxima Grade</label>
          </div>
        </div>

        <div class="modal-footer row col s12 m12 l12">
          <a class="col s12 m4 l4 modal-close waves-effect waves-teal btn red">Cancelar</a>
          <p class="col s12 m4 l4"></p>
          <a
            class="col s12 m4 l4 waves-effect waves-teal btn green"
            @click="confirmacaoAtualizar()"
          >Confirmar</a>
        </div>
      </div>
    </div>

    <!-- Modal Gerir Grade -->
    <div id="GerirGrade" class="modal margem">
      <div class="modal-content">
        <h4 class="centro">Gerir Grade</h4>
        <hr />

        <table>
          <thead class="centro">
            <tr>
              <th>Nome da Sigla</th>
              <th>Nome da Disciplina</th>
              <th>Nome do Professor(a)</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="item in disciplinasDaGrade" :key="item.id">
              <td>{{ "#"+item.eve_sigla }}</td>
              <td>{{ "#"+item.eve_nome }}</td>
              <td>{{ item.pes_nome +" "+ item.pes_sobrenomes }}</td>
              <td>
                <a class="waves-effect waves-light btn red">Remover</a>
              </td>
            </tr>
          </tbody>
        </table>
      </div>

      <div class="row">
        <div class="col s12">
          <a
            class="col s12 centro waves-effect waves-light btn modal-trigger botaoVerMais"
            href="#modalBuscaDisciplina"
            @click="disciplinaBusca = '';"
          >Adicionar Disciplina</a>
        </div>
      </div>

      <div class="modal-footer row col s12 m12 l12">
        <a class="col s12 m4 l4 modal-close waves-effect waves-teal btn red">Cancelar</a>
      </div>
    </div>

    <!-- Modal Busca Disciplina -->
    <div id="modalBuscaDisciplina" class="modal margem">
      <div class="modal-content">
        <h3>Busca de Disciplinas</h3>
        <hr />
        <div class="row">
          <form onsubmit="return false">
            <div class="col s12">
              <div class="col s10 m10 l10 input-field">
                <input
                  id="disciplina"
                  placeholder="Entre com o nome da Disciplina"
                  type="text"
                  class="validate"
                  v-model="disciplinaBusca"
                />
                <label for="disciplina" class="active">Buscar Disciplina:</label>
              </div>

              <div class="col s2 m2 l2">
                <a
                  class="btn-floating btn-large waves-effect waves-light iconeBG modal-trigger"
                  href="#modalBuscaDisciplina"
                  @click="buscarDisciplinas()"
                >
                  <i class="material-icons">search</i>
                </a>
              </div>
            </div>
          </form>
        </div>
        <div class="row">
          <div class="col s12">
            <table>
              <thead class="centro">
                <tr>
                  <th>Sigla</th>
                  <th>Nome</th>
                  <th></th>
                </tr>
              </thead>
              <tbody>
                <tr
                  v-for="(item, index) in disciplinas"
                  :key="item.id"
                  @click="buscarDisciplinasAtribuir(index)"
                >
                  <td>{{ item.eve_sigla }}</td>
                  <td>{{ item.eve_nome }}</td>
                  <td>
                    <a class="waves-effect waves-light btn modal-close">Selecionar</a>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "gradesGeral",
  data() {
    return {
      grades: [],
      disciplinas: [],
      disciplinasDaGrade: [],
      grade: 0,
      prox_grade: 0,
      nome: "",
      disciplinaBusca: ""
    };
  },

  mounted() {
    this.carregarDados(),
      $(document).ready(function() {
        $(".modal").modal();
      });
  },

  methods: {
    carregarDados() {
      this.$http.get("Grades").then(
        response => {
          this.grades = response.body;
        },
        response => {
          console.log(
            "ERRO ao carregar os Dados! Código de resposta (HTTP) do servidor: " +
              response.status
          );
        }
      );
    },

    carregarDisciplinasGrade() {
      this.$http.get("Grades").then(
        response => {
          this.disciplinasDaGrade = response.body;
        },
        response => {
          console.log(
            "ERRO ao carregar os Dados! Código de resposta (HTTP) do servidor: " +
              response.status
          );
        }
      );
    },

    addDados() {
      this.nome = "";
      this.prox_grade = 0;
      $(document).ready(function() {
        M.updateTextFields();
        $("select").formSelect();
      });
    },

    verDados(item) {
      (this.grade = item.gra_codigo), (this.nome = item.gra_nome);
      this.prox_grade = item.gra_prox_grade;
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
          var dadosGrade = {
            gra_nome: this.nome,
            gra_prox_grade: this.prox_grade
          };

          this.$http.post("Grades", dadosGrade).then(
            response => {
              this.carregarDados();
              swalWithBootstrapButtons(
                "Salvo!",
                "Todas as informações foram salvas.",
                "success"
              );
            },
            response => {
              this.erro("Dados Grade", response.status);
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

    confirmacaoAtualizar() {
      const swalWithBootstrapButtons = swal.mixin({
        confirmButtonClass: "btn green sepraracaoBotoes",
        cancelButtonClass: "btn red sepraracaoBotoes",
        buttonsStyling: false
      });

      swalWithBootstrapButtons({
        title: "Todos os dados estão corretos?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sim, Atualize!",
        cancelButtonText: "Não, cancele!",
        reverseButtons: true
      }).then(result => {
        if (result.value) {
          var dadosGrade = {
            gra_codigo: this.grade,
            gra_nome: this.nome,
            gra_prox_grade: this.prox_grade
          };

          this.$http.put("Grades", dadosGrade).then(
            response => {
              this.carregarDados();
              swalWithBootstrapButtons(
                "Salvo!",
                "Todas as informações foram salvas.",
                "success"
              );
            },
            response => {
              this.erro("Dados Grade", response.status);
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

    buscarDisciplinas() {
      this.$http
        .get("EventosAuditores/BuscarNomes", {
          params: { nome: this.disciplinaBusca }
        })
        .then(
          response => {
            this.disciplinas = response.body;
            console.log(response.body);
          },
          response => {
            this.erro("buscar as disciplinas", response.status);
          }
        );
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
