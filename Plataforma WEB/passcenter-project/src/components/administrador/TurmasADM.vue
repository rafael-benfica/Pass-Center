<template>
  <div>
    <div class="row area-exibicao">
      <div
        class="col s12 m4 l4 espacamento"
        v-for="(item, index) in eventos_auditores"
        :key="item.id"
      >
        <div class="modal-trigger" href="#modalEdit" @click="verDados(index)">
          <div class="card">
            <div class="card-content">
              <h1 class="card-title cardDisciplina">{{ item.eve_nome }}</h1>
              <h3 class="card-title cardDisciplina">Professor(a):</h3>
              <h4 class="cardTurmaCarga">{{ item.pes_nome }}</h4>
              <br>
            </div>
          </div>
        </div>
      </div>

      <!-- Card Add -->
      <div class="col s12 m3 l3 espacamento">
        <a class="modal-trigger" href="#modalAdd">
          <div class="card">
            <div class="card-content">
              <br>
              <br>
              <h5 class="cardDisciplina">Adicionar</h5>
              <h3 class="cardDisciplina">
                <i class="material-icons icone-card">add_circle_outline</i>
              </h3>
              <br>
            </div>
          </div>
        </a>
      </div>

      <!-- Modal Add -->
      <div id="modalAdd" class="modal margem">
        <div class="modal-content">
          <h4 class="centro">Cadastro de Turma</h4>
          <hr>
          <div class="row">
            <form onsubmit="return false">
              <div class="col s12 m6 l6">
                <div class="col s10 m10 l10 input-field">
                  <input
                    id="disciplina"
                    placeholder="Entre com o nome da Disciplina"
                    type="text"
                    class="validate"
                    v-model="disciplinaBusca"
                  >
                  <label for="disciplina" class="active">Buscar Disciplina:</label>
                </div>
                <div class="col s2 m2 l2">
                  <a
                    class="btn-floating btn-large waves-effect waves-light iconeBG modal-trigger"
                    href="#modalBuscaDisciplina"
                    @click="buscarDisciplinas()"
                  >
                    <button class="transparent">
                      <i class="material-icons icone">search</i>
                    </button>
                  </a>
                </div>
              </div>
            </form>
            <form onsubmit="return false">
              <div class="col s12 m6 l6">
                <div class="col s10 m10 l10 input-field">
                  <input
                    id="professor"
                    placeholder="Entre com o nome do Professor"
                    type="text"
                    class="validate"
                    v-model="professorBusca"
                  >
                  <label for="professor" class="active">Buscar Professor:</label>
                </div>
                <div class="col s2 m2 l2">
                  <a
                    class="btn-floating btn-large waves-effect waves-light iconeBG modal-trigger"
                    href="#modalBuscaProfessor"
                    @click="buscarProfessores()"
                  >
                    <button class="transparent">
                      <i class="material-icons icone">search</i>
                    </button>
                  </a>
                </div>
              </div>
            </form>
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

      <!-- Modal Busca Disciplina -->
      <div id="modalBuscaDisciplina" class="modal margem">
        <div class="modal-content">
          <h3>Busca de Disciplinas</h3>
          <hr>
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

      <!-- Modal Busca Professor -->
      <div id="modalBuscaProfessor" class="modal margem">
        <div class="modal-content">
          <h3>Busca de Professores</h3>
          <hr>
          <table>
            <thead class="centro">
              <tr>
                <th>Nome</th>
                <th>Matricula</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="(item, index) in professores"
                :key="item.id"
                @click="buscarProfessoresAtribuir(index)"
              >
                <td>{{ item.pes_nome + " " + item.pes_sobrenomes }}</td>
                <td>{{ item.pes_matricula }}</td>
                <td>
                  <a class="waves-effect waves-light btn modal-close">Selecionar</a>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>

      <!-- Modal Busca Alunso -->
      <div id="modalBuscaAlunos" class="modal margem">
        <div class="modal-content">
          <h3>Busca de Alunos</h3>
          <hr>

          <div class="row">
            <form onsubmit="return false">
              <div class="col s12 m12 l12">
                <div class="col s10 m10 l10 input-field">
                  <input
                    id="disciplina"
                    placeholder="Entre com o nome do Aluno"
                    type="text"
                    class="validate"
                    v-model="alunoBusca"
                  >
                  <label for="disciplina" class="active">Buscar ALuno:</label>
                </div>
                <div class="col s2 m2 l2">
                  <a
                    class="btn-floating btn-large waves-effect waves-light iconeBG"
                    @click="buscarAlunos()"
                  >
                    <button class="transparent">
                      <i class="material-icons icone">search</i>
                    </button>
                  </a>
                </div>
              </div>
            </form>
          </div>
          <table>
            <thead class="centro">
              <tr>
                <th>Nome</th>
                <th>Matricula</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="(item, index) in alunos"
                :key="item.id"
                @click="confirmacaoAdicionarAluno(index)"
              >
                <td>{{ item.nomes_concatenados }}</td>
                <td>{{ item.pes_matricula }}</td>
                <td>
                  <a class="waves-effect waves-light btn modal-close">Selecionar</a>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>

      <!-- Modal Edit -->
      <div id="modalEdit" class="modal margem">
        <div class="modal-content">
          <h3 class="centro">{{nomeDisciplina}}</h3>
          <h4>{{ nomeAuditor }}</h4>

          <table>
            <thead class="centro">
              <tr>
                <th>Nome do Aluno</th>
                <th>Matrícula do do Aluno</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="item in alunosMatriculados" :key="item.id">
                <td>{{ item.nomes_concatenados }}</td>
                <td>{{ "#"+item.pes_matricula }}</td>
                <td>
                  <a class="waves-effect waves-light btn red modal-trigger" href="#modalVer">Remover</a>
                </td>
              </tr>
            </tbody>
          </table>

          <a
            class="col s12 m12 l12 centro waves-effect waves-light btn botaoVerMais modal-trigger"
            href="#modalBuscaAlunos"
          >Adicionar alunos</a>

          <div class="modal-footer row col s12 m12 l12">
            <a href="#!" class="col s12 m4 l4 modal-close waves-effect waves-teal btn red">Fechar</a>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "TurmasGeral",
  data() {
    return {
      //Campos de Busca
      professorBusca: "",
      disciplinaBusca: "",
      alunoBusca: "",

      //Capturando Primary Keys
      pes_codigo: "",
      eve_codigo: "",

      //Retorno das Buscas
      eventos_auditores: [],
      professores: [],
      disciplinas: [],
      alunos: [],

      //Edição das Turmas
      nomeDisciplina: "",
      nomeAuditor: "",
      idEAU: 0,
      alunosMatriculados: []
    };
  },

  mounted() {
    this.listarEventosAuditores();

    $(document).ready(function() {
      $(".modal").modal();
    });
  },

  methods: {
    listarEventosAuditores() {
      this.$http.get("EventosAuditores").then(
        response => {
          this.eventos_auditores = response.body;
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
      var dados = this.eventos_auditores[index];
      this.nomeDisciplina = dados.eve_nome;
      this.nomeAuditor = dados.pes_nome;
      this.idEAU = dados.eau_codigo;

      this.listarAlunosMatriculados();
    },

    listarAlunosMatriculados() {
      this.$http.get("Turmas/EAU", { params: { eau: this.idEAU } }).then(
        response => {
          this.alunosMatriculados = response.body;
        },
        response => {
          console.log(
            "ERRO ao carregar os Dados! Código de resposta (HTTP) do servidor: " +
              response.status
          );
        }
      );
    },

    buscarProfessores() {
      this.$http
        .get("Pessoas/Professores", { params: { nome: this.professorBusca } })
        .then(
          response => {
            this.professores = response.body;
            console.log(response.body);
          },
          response => {
            console.log(
              "ERRO ao carregar os Dados! Código de resposta (HTTP) do servidor: " +
                response.status
            );
          }
        );
    },

    buscarDisciplinas() {
      this.$http
        .get("Eventos/BuscarNomes", { params: { nome: this.disciplinaBusca } })
        .then(
          response => {
            this.disciplinas = response.body;
            console.log(response.body);
          },
          response => {
            console.log(
              "ERRO ao carregar os Dados! Código de resposta (HTTP) do servidor: " +
                response.status
            );
          }
        );
    },

    buscarAlunos() {
      this.$http
        .get("Pessoas/PorTipoNome", {
          params: { nome: this.alunoBusca, tipo: 5 }
        })
        .then(
          response => {
            this.alunos = response.body;
            console.log(response.body);
          },
          response => {
            console.log(
              "ERRO ao carregar os Dados! Código de resposta (HTTP) do servidor: " +
                response.status
            );
          }
        );
    },

    buscarProfessoresAtribuir(index) {
      this.professorBusca =
        this.professores[index].pes_matricula +
        " | " +
        this.professores[index].pes_nome +
        " " +
        this.professores[index].pes_sobrenomes;
      this.pes_codigo = this.professores[index].pes_codigo;
    },

    buscarDisciplinasAtribuir(index) {
      this.disciplinaBusca =
        this.disciplinas[index].eve_sigla +
        " | " +
        this.disciplinas[index].eve_nome;
      this.eve_codigo = this.disciplinas[index].eve_codigo;
    },

    confirmacaoAdicionarAluno(index) {
      const swalWithBootstrapButtons = swal.mixin({
        confirmButtonClass: "btn green sepraracaoBotoes",
        cancelButtonClass: "btn red sepraracaoBotoes",
        buttonsStyling: false
      });

      swalWithBootstrapButtons({
        title: "Você tem certeza?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sim, faça!",
        cancelButtonText: "Não, cancele!",
        reverseButtons: true
      }).then(result => {
        if (result.value) {
          var dodosEventoAuditor = {
            Eau_codigo: {
              Eau_codigo: this.idEAU
            },
            Usu_codigo: {
              usu_codigo: this.alunos[index].usu_codigo
            }
          };

          this.$http.post("Turmas", dodosEventoAuditor).then(
            response => {
              swalWithBootstrapButtons(
                "Feito!",
                "Aluno(a) adicionado(a) na Turma!",
                "success"
              );
              this.listarAlunosMatriculados(),
              this.alunos = []; 
            },
            response => {
              this.erro("Dados Evento", response.status);
            }
          );
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
    },

    confirmacaoCriar() {
      const swalWithBootstrapButtons = swal.mixin({
        confirmButtonClass: "btn green sepraracaoBotoes",
        cancelButtonClass: "btn red sepraracaoBotoes",
        buttonsStyling: false
      });

      swalWithBootstrapButtons({
        title: "Você tem certeza?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sim, faça!",
        cancelButtonText: "Não, cancele!",
        reverseButtons: true
      }).then(result => {
        if (result.value) {
          var dodosEventoAuditor = {
            Eve_codigo: {
              Eve_codigo: this.eve_codigo
            },
            Pes_codigo: {
              Pes_codigo: this.pes_codigo
            }
          };

          this.$http.post("EventosAuditores", dodosEventoAuditor).then(
            response => {
              swalWithBootstrapButtons(
                "Turma Criada!",
                "A Turma foi criada com sucesso! Não esqueça de adicionar os alunos.",
                "success"
              );
              this.listarEventosAuditores();
              (this.professores = []), (this.disciplinas = []);
            },
            response => {
              this.erro("Dados Evento", response.status);
            }
          );
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


<style src="./../../assets/css/gerenteGeral/GeralGerenteTurmas.css" scoped></style>
