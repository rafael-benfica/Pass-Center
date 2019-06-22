<template>
  <div>
    <div class="row area-exibicao" v-show="!clicou">
      <div class="col offset-m3 m5 s12 card ajuste espacamento">
        <div class="row">
          <div class="col offset-m1 m10 s12">
            <div class="row">
              <div class="col s12 m12 l12">
                <h3 class="center-align">Qual Período você deseja buscar?</h3>
              </div>
            </div>

            <div class="row">
              <div class="col offset-m3 m7 s12">
                <a class="dropdown-trigger1 btn" data-target="dropdownPeriodos1">
                  <i class="material-icons left">insert_invitation</i>Selecione um Período:
                </a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="row area-exibicao" v-show="clicou">
      <div class="row">
        <div class="col s12 m3 l3 espacamento">
          <a class="dropdown-trigger2 btn" data-target="dropdownPeriodos2">
            <i class="material-icons left">insert_invitation</i>Alterar Período
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
            @click="carregarSessoes(itemDisciplinas.eau_codigo); nomeHistorico = itemDisciplinas.eve_nome+' - '+ itemDisciplinas.eau_periodo_identificacao ;"
          >
            <div class="card-content">
              <span class="card-title cardDisciplina">{{ itemDisciplinas.eve_nome }}</span>
              <p
                class="cardTurmaCarga"
              >{{ itemDisciplinas.eve_sigla +" | "+ itemDisciplinas.eau_periodo_identificacao}}</p>
              <p
                class="cardFaltasPresencas"
              >{{ itemDisciplinas.presencas}} presenças em {{itemDisciplinas.sessoes}} aulas</p>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- Dropdown Periodos 1 -->
    <ul id="dropdownPeriodos1" class="dropdown-content">
      <li v-for="item in periodos" :key="item.id">
        <a
          class="waves-effect"
          @click="obtemDisciplinas(item.eau_periodo_identificacao); clicou = true;"
        >{{ item.eau_periodo_identificacao }}</a>
      </li>
    </ul>

    <!-- Dropdown Periodos 2 -->
    <ul id="dropdownPeriodos2" class="dropdown-content">
      <li v-for="item in periodos" :key="item.id">
        <a
          class="waves-effect"
          @click="obtemDisciplinas(item.eau_periodo_identificacao);"
        >{{ item.eau_periodo_identificacao }}</a>
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: "HistoricoCompletoAluno",
  data() {
    return {
      periodos: {},
      disciplinas: [],
      clicou: false
    };
  },
  mounted: function() {
    $(document).ready(function() {
      $(".modal").modal();
      $(".dropdown-trigger1").dropdown();
      $(".dropdown-trigger2").dropdown();
    });

    this.$http.get("EventosAuditores/Participantes/PeriodosIdentificacao").then(
      response => {
        this.periodos = response.body;
      },
      response => {
        this.erro("obter periodos", response.status);
      }
    );
  },

  methods: {
    obtemDisciplinas(periodo) {
      this.$http
        .get("Presencas/Participante/PorPeriodoIdentificacao", {
          params: { eau_periodo_identificacao: periodo }
        })
        .then(
          response => {
            this.disciplinas = response.body;
            console.log("Obteve Disciplinas!");
          },
          response => {
            this.erro("obter preseças", response.status);
          }
        );
    },
    erro(msg, code) {
      swal({
        title: "Oops!",
        text: "Algo deu errado! Entre em contato com os Administradores.",
        type: "error"
      }),
        console.log(
          "ERRO em " + msg + "! Código de resposta (HTTP) do servidor: " + code
        );
    }
  }
};
</script>
<style src="./../../assets/css/aluno/HistoricoCompletoAluno.css" scoped></style>