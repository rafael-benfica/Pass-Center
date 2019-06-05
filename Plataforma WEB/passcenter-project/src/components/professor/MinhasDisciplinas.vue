<template>
  <div class="fonte">
    <div class="row area-exibicao">
      <div
        class="col s12 m3 l3 espacamento"
        v-for="itemDisciplinas in disciplinas"
        :key="itemDisciplinas.id"
      >
        <!-- {{ item }} -->
        <div
          class="card"
          :class="{ pulse: itemDisciplinas.eau_operacao}"
          @click="modalDisciplinaAtiva(itemDisciplinas)"
        >
          <div class="card-image">
            <a
              class="btn-floating halfway-fab waves-effect waves-light blue darken-1 btn modal-trigger botao"
              href="#modal1"
            >
              <i class="material-icons" @click="carregarSessoes(itemDisciplinas.eau_codigo)">history</i>
            </a>
          </div>
          <div class="card-content">
            <span class="card-title tituloCard">{{ itemDisciplinas.eve_nome }}</span>
            <p class="turmaCard">{{ itemDisciplinas.eve_sigla }}</p>
          </div>
        </div>
      </div>
    </div>
    <div id="modal1" class="modal bottom-sheet">
      <div class="modal-content">
        <h4 class="col s10 m12 l12 historico">Histórico</h4>
        <div class="row">
          <div
            class="col s12 m3 l3 espacamento"
            v-for="itemSessoes in sessoes"
            :key="itemSessoes.id"
          >
            <div
              class="card modal-trigger"
              href="#modal2"
              @click="carregarlista(itemSessoes.ses_codigo)"
            >
              <div class="card-content">
                <span class="card-title tituloCard">{{ recebeData(itemSessoes.ses_horario_inicio) }}</span>
                <a
                  class="btn-floating halfway-fab waves-effect waves-light blue darken-1 btn botao"
                >
                  <i class="material-icons" v-if="itemSessoes.ses_sessao_automatico==0">edit</i>
                  <i class="material-icons" v-else>font_download</i>
                </a>
              </div>
            </div>
          </div>
        </div>
        <div class="modal-footer">
          <a href="#!" class="modal-close waves-effect waves-green btn-flat">Fechar</a>
        </div>
      </div>
    </div>
    <div id="modal2" class="modal modal-fixed-footer">
      <div class="modal-content row topo">
        <div class="col s12 m12 l12">
          <table>
            <thead class="centro">
              <tr>
                <th>Nome do Aluno</th>
                <th>Matrícula do Aluno</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="item in lista" :key="item.id">
                <td>{{ item.nomes_concatenados }}</td>
                <td>{{ item.pes_matricula }}</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
      <div class="modal-footer">
        <a href="#!" class="modal-close waves-effect waves-green btn-flat">Fechar</a>
      </div>
    </div>
    <!-- Modal Structure -->
    <div id="modalDisciplinaAtiva" class="modal modal-fixed-footer">
      <div class="modal-content">
        <div class="row">
          <div class="col s12 center-align">
            <h4>{{disciplinasSelecionada.eve_nome}}</h4>
          </div>
          <div class="col s12 center-align">
            <h5>Alunos Presentes</h5>
          </div>
        </div>

        <table>
          <thead class="centro">
            <tr>
              <th>Nome do Aluno</th>
              <th>Matrícula do Aluno</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="item in alunosLive" :key="item.id">
              <td>{{ item.nomes_concatenados }}</td>
                  <td>{{ item.pes_matricula }}</td>
              <td>
                <a class="waves-effect waves-light btn red accent-4">
                  <i class="material-icons left">close</i>Remover
                </a>
              </td>
            </tr>
          </tbody>
        </table>

        <p>{{disciplinasSelecionada}}</p>
      </div>
      <div class="modal-footer">
        <a href="#!" class="modal-close waves-effect waves-green btn-flat">Agree</a>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "MinhasDisciplinas",
  data() {
    return {
      disciplinas: [],
      sessoes: [],
      lista: [],
      intervalo:{},
      alunosLive:[],
      disciplinasSelecionada: {}
    };
  },
  mounted: function() {
    $(document).ready(function() {
      $(".modal").modal();
    });

    this.$http.get("EventosAuditores/Disciplinas").then(
      response => {
        this.disciplinas = response.body;
        this.obtemDados();
      },
      response => {
        console.log(
          "ERRO ao carregar os Dados! Código de resposta (HTTP) do servidor: " +
            response.status
        );
      }
    );
  },

  beforeDestroy() {
    clearInterval(this.intervalo);
  },

  methods: {
    modalDisciplinaAtiva(item) {
      clearInterval(this.intervalo);
      console.log(item);
      this.disciplinasSelecionada = item;
      var modal = document.querySelector("#modalDisciplinaAtiva");
      var instance = M.Modal.init(modal, { dismissible: false, onCloseEnd: this.obtemDados() });
      instance.open();

      this.$http.get("Presencas/live", { params: { eau_codigo: item.eau_codigo } }).then(
        response => {
          this.alunosLive = response.body;
        },
        response => {
          console.log(
            "ERRO ao carregar os Dados! Código de resposta (HTTP) do servidor: " +
              response.status
          );
        }
      );
    },
    obtemDados: function() {
      console.log("Obtendo dados...");

      this.intervalo = setInterval(() => {
        this.$http.get("EventosAuditores/Disciplinas").then(
          response => {
            this.disciplinas = response.body;
            console.log("olaaa");
          },
          response => {
            console.log(
              "ERRO ao carregar os Dados! Código de resposta (HTTP) do servidor: " +
                response.status
            );
            clearInterval(this.intervalo);
          }
        );
      }, 1000);
    },

    recebeData(data) {
      var horaEdata = data.split("T");

      var data = horaEdata[0].split("-").reverse();

      return data[0] + "/" + data[1] + "/" + data[2] + " - " + horaEdata[1];
    },

    carregarSessoes(id) {
      this.$http.get("Sessoes", { params: { eau_codigo: id } }).then(
        response => {
          this.sessoes = response.body;
        },
        response => {
          console.log(
            "ERRO ao carregar os Dados! Código de resposta (HTTP) do servidor: " +
              response.status
          );
        }
      );
    },
    carregarlista(id) {
      this.$http.get("Presencas", { params: { ses_codigo: id } }).then(
        response => {
          this.lista = response.body;
        },
        response => {
          console.log(
            "ERRO ao carregar os Dados! Código de resposta (HTTP) do servidor: " +
              response.status
          );
        }
      );
    }
  }
};
</script>

<style src="./../../assets/css/professor/MinhasDisciplinas.css" scoped=""></style>
