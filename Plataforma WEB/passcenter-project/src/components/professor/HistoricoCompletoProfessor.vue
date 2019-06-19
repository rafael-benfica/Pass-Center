<template>
  <div>
    <div class="row area-exibicao">
      <div class="row">
        <div class="col s12 m3 l3 espacamento">
          <a class="dropdown-trigger btn" data-target="dropdownPeriodos">
            <i class="material-icons left">insert_invitation</i>Selecione uma data:
          </a>
        </div>
      </div>
      <div class="row">
        <div
          class="col s12 m3 l3 espacamento"
          v-for="itemDisciplinas in disciplinas"
          :key="itemDisciplinas.id"
        >
          <div
            class="card modal-trigger"
            href="#modalSessoes"
            @click="carregarSessoes(itemDisciplinas.eau_codigo)"
          >
            <div class="card-content">
              <span class="card-title tituloCard">{{ itemDisciplinas.eve_nome }}</span>
              <p class="turmaCard">{{ itemDisciplinas.eve_sigla }}</p>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- Dropdown Periodos -->
    <ul id="dropdownPeriodos" class="dropdown-content">
      <li v-for="item in periodos" :key="item.id">
        <a
          class="waves-effect"
          @click="obtemDisciplinas(item.eau_periodo_identificacao)"
        >{{ item.eau_periodo_identificacao }}</a>
      </li>
    </ul>

    <!-- Modal Sessões -->
    <div id="modalSessoes" class="modal bottom-sheet modal-fixed-footer">
      <div class="modal-content">
        <h4 class="col s10 m12 l12 historico">Histórico de Aulas</h4>
        <p>Esses são os dias registrados:</p>
        <div class="row">
          <div class="col s4 m1 l1 espacamento" v-for="item in sessoes" :key="item.id">
            <div class="waves-effect waves-teal btn-large">
              <div class="row">
                <div class="col s12">{{ trataData(item.ses_horario_inicio)  + trataData(item.ses_horario_inicio)  }} </div>
                
              </div>
              
            </div>
          </div>
        </div>
      </div>
      <div class="modal-footer">
        <a href="#!" class="modal-close waves-effect waves-green btn-flat">Fechar</a>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "HistoricoCompletoProfessor",
  data() {
    return {
      periodos: {},
      disciplinas: [],
      sessoes: []
    };
  },
  mounted: function() {
    $(document).ready(function() {
      $(".dropdown-trigger").dropdown();
    });

    $(document).ready(function() {
      $(".modal").modal();
    });

    this.$http.get("EventosAuditores/PeriodosIdentificacao").then(
      response => {
        this.periodos = response.body;
      },
      response => {
        console.log(
          "ERRO ao carregar os Periodos! Código de resposta (HTTP) do servidor: " +
            response.status
        );
      }
    );
  },

  methods: {
    obtemDisciplinas(periodo) {
      this.$http
        .get("EventosAuditores/DisciplinasHistorico", {
          params: { identificacao: periodo }
        })
        .then(
          response => {
            this.disciplinas = response.body;
            console.log("Obteve Disciplinas!");
          },
          response => {
            console.log(
              "ERRO ao carregar os Dados! Código de resposta (HTTP) do servidor: " +
                response.status
            );
          }
        );
    },
    carregarSessoes(id) {
      this.$http.get("Sessoes/Historico", { params: { eau_codigo: id } }).then(
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
    trataData(data) {
      var horaEdata = data.split("T");

      var data = horaEdata[0].split("-").reverse();

      return data[0] + "/" + data[1] + "/" + data[2];
    },
    trataHora(data) {
      var horaEdata = data.split("T");

      var data = horaEdata[0].split("-").reverse();

      return horaEdata[1];
    }
  }
};
</script>
<style src="./../../assets/css/professor/HistoricoCompletoProfessor.css" scoped></style>