<template>
  <div>
    <div class="row area-exibicao">
      <div class="col s12 m4 l4 espacamento" v-for="item in disciplinas" :key="item.id">
        <div class="card">
          <div class="card-content">
            <h3 class="cardDisciplina">{{ item.eve_sigla }}</h3>
            <h5 class="cardDisciplina">{{ item.eve_nome }}</h5>
            <br>
          </div>
        </div>
      </div>
      <div class="col s12 m3 l3 espacamento">
        <a class="modal-trigger" href="#modal" @click="addDados()">
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

    <div id="modal" class="modal margem">
      <div class="modal-content">
        <h4 class="centro">Cadastro Disciplina</h4>
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
            <input id="sigla" type="text" class="validate" v-model="sigla">
            <label for="sigla">Sigla:</label>
          </div>

          <div class="input-field col s12 m4">
            <input id="nome" type="text" class="validate" v-model="nome">
            <label for="nome">Nome:</label>
          </div>
        </div>
        <div class="row">
          <div class="input-field col s12 m12">
            <textarea id="descricao" class="materialize-textarea" v-model="descricao"></textarea>
            <label for="descricao">Descricao</label>
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
  </div>
</template>

<script>
export default {
  name: "DisciplinasGeral",
  data() {
    return {
      disciplinas: [],
      instituicoes: [],
      instituicao: 0,
      sigla: "",
      nome: "",
      descricao: ""
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
      this.$http.get("Eventos", { params: { tipo: 1 } }).then(
        response => {
          this.disciplinas = response.body;
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
      this.sigla = "";
      this.nome = "";
      this.descricao = "";
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
          var dodosEvento = {
            eve_sigla: this.sigla,
            eve_nome: this.nome,
            eve_descricao: this.descricao,
            tev_codigo: {
              tev_codigo: 1
            },
            ins_codigo: {
              ins_codigo: this.instituicao
            }
          };

          this.$http.post("Eventos/ADM", dodosEvento).then(
            response => {
              this.carregarDados();
              swalWithBootstrapButtons(
                "Salvo!",
                "Todas as informações foram salvas.",
                "success"
              );
            },
            response => {
              this.erro("Dados Evento", response.status);
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
        ),
        this.carregarDados();
    }
  }
};
</script>


<style src="./../../assets/css/gerenteGeral/Geral.css" scoped></style>
