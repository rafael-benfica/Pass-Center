<template>
  <div>
    <div class="row area-exibicao">
      <div class="col s12 m4 l4 espacamento" v-for="(item, index) in enventosAuditores" :key="item.id">
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
            <div class="col s12 m6 l6">
              <div class="col s10 m10 l10 input-field">
                <input id="disciplina" type="text" class="validate" v-model="disciplinaBusca" >
                <label for="disciplina">Buscar Disciplina:</label>
              </div>
              <div class="col s2 m2 l2">
                <a
                  class="btn-floating btn-large waves-effect waves-light iconeBG modal-trigger"
                  href="#modalBuscaDisciplina"
                >
                  <i class="material-icons icone">search</i>
                </a>
              </div>
            </div>
            <div class="col s12 m6 l6">
              <div class="col s10 m10 l10 input-field">
                <input id="professor" type="text" class="validate" v-model="professorBusca">
                <label for="professor">Buscar Professor:</label>
              </div>
              <div class="col s2 m2 l2">
                <a class="btn-floating btn-large waves-effect waves-light iconeBG modal-trigger" href="#modalBuscaProfessor" @click="buscarProfessores()">
                  <i class="material-icons icone">search</i>
                </a>
              </div>
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

      <!-- Modal Busca Disciplina -->
      <div id="modalBuscaDisciplina" class="modal margem">
        <div class="modal-content">
          <h3>Busca de Disciplina</h3>
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
              <tr v-for="(item, index) in disciplinas" :key="item.id" @click="verDados(index)">
                <td>{{ item.tur_sigla }}</td>
                <td>{{ item.tur_nome }}</td>
                <td>
                  <a class="waves-effect waves-light btn modal-trigger" href="#modalVer">Selecionar</a>
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
              <tr v-for="(item, index) in professores" :key="item.id" @click="buscarProfessoresAtribuir(index)">
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
              <tr v-for="item in alunos" :key="item.id">
                <td>{{ item.pes_nome +" "+ item.pes_sobrenomes }}</td>
                <td>{{ "#"+item.pes_matricula }}</td>
                <td>
                  <a class="waves-effect waves-light btn red modal-trigger" href="#modalVer">Remover</a>
                </td>
              </tr>
            </tbody>
          </table>

          <a class="col s12 m12 l12 centro waves-effect waves-light btn botaoVerMais" @click="addDados()">Adicionar alunos</a>

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
      professorBusca: "",
      disciplinaBusca: "",
      professores: [],
      disciplinas: [],
      alunos: [],
      enventosAuditores: [],
      evento_auditor: [],
      nomeDisciplina: "",
      nomeAuditor: ""
    };
  },
  mounted() {
    this.$http.get("EnventosAuditores").then(
      response => {
        this.enventosAuditores = response.body;
      },
      response => {
        console.log(
          "ERRO ao carregar os Dados! Código de resposta (HTTP) do servidor: " +
            response.status
        );
      }
    );

    $(document).ready(function() {
      $(".modal").modal();
    });
  },
  methods: {

    listarAlunos(){
      this.$http.get("Usuarios/porTipo", { params: { tipo: 5 } }).then(
        response => {
          this.alunos = response.body;
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
      var dados = this.enventosAuditores[index];
      this.nomeDisciplina = dados.eve_nome;
      this.nomeAuditor = dados.pes_nome;
    },

    buscarProfessores() {
      this.$http.get("Pessoas/Professores", { params: { nome: this.professorBusca } }).then(
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

    buscarProfessoresAtribuir(index) {
      this.professorBusca = this.professores[index].pes_nome + " " + this.professores[index].pes_sobrenomes;
      console.log("oi");
    },


    confirmação() {
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
          swalWithBootstrapButtons(
            "Alterado!",
            "As alterações foram salvas.",
            "success"
          );
        } else if (
          // Read more about handling dismissals
          result.dismiss === swal.DismissReason.cancel
        ) {
          swalWithBootstrapButtons(
            "Cancelado!",
            "Alterações descartadas!",
            "error"
          );
        }
      });
    }
  }
};
</script>


<style src="./../../assets/css/gerenteGeral/GeralGerenteTurmas.css" scoped></style>
