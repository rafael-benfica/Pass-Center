<template>
  <div>
    <div class="row area-exibicao">
      <div
        class="col s12 m3 l3 espacamento"
        v-for="itemDisciplinas in disciplinas"
        :key="itemDisciplinas.id"
      >
        <!-- {{ item }} -->
        <div class="card">
          <div class="card-content">
            <span class="card-title cardDisciplina">{{ itemDisciplinas.eve_nome }}</span>
            <p
              class="cardTurmaCarga"
            >{{ itemDisciplinas.eve_sigla +" | "+ itemDisciplinas.eau_periodo_identificacao}}</p>
            <p
              class="cardFaltasPresencas"
            >{{ itemDisciplinas.presencas}} presenças em {{itemDisciplinas.sessoes}} aulas</p>
            <a
              class="waves-effect waves-light btn modal-trigger botaoVerMais"
              href="#modal1"
              @click="carregaDiasFaltas(itemDisciplinas.eau_codigo);"
            >Ver mais</a>
          </div>
        </div>
      </div>
    </div>
    <!-- Modal Structure -->
    <div id="modal1" class="modal bottom-sheet modal-fixed-footer">
      <div class="modal-content">
        <div class="row">
          <div class="col s12 m12 l12">
            <h4 class="modalAjuste">Histórico de Faltas</h4>
            <br>
            <p class="modalAjuste">Essas são as aulas que você faltou:</p>
          </div>
        </div>

        <div class="row">
          <div class="col s12 m2 l2" v-for="item in faltas" :key="item.id">
            <div class="card">
              <div class="card-content">
                <span class="card-title cardTurmaCarga">
                  {{ trataData(item.ses_horario_inicio) }}
                  <br>
                  {{ trataHora(item.ses_horario_inicio) }}
                </span>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="modal-footer">
        <a class="modal-close waves-effect waves-green btn-flat">Fechar</a>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "MinhasDisciplinasAluno",
  data() {
    return {
      disciplinas: [],
      faltas: []
    };
  },

  mounted: function() {
    this.$http.get("Presencas/Participante").then(
      response => {
        this.disciplinas = response.body;
      },
      response => {
        this.erro("obter periodos", response.status);
      }
    );

    $(document).ready(function() {
      $(".modal").modal();
    });
  },

  methods: {
    carregaDiasFaltas(eau) {
      this.$http
        .get("Presencas/Participante/diasFaltas", {
          params: { eau_codigo: eau }
        })
        .then(
          response => {
            this.faltas = response.body;
          },
          response => {
            this.erro("obter faltas", response.status);
          }
        );
    },

    trataData(data) {
      var horaEdata = data.split("T");

      var data = horaEdata[0].split("-").reverse();

      return data[0] + "/" + data[1] + "/" + data[2];
    },

    trataHora(hora) {
      var horaEdata = hora.split("T");

      var hora = horaEdata[0].split("-").reverse();

      return horaEdata[1];
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

<style src="./../../assets/css/aluno/MinhasDisciplinasAluno.css" scoped></style>
