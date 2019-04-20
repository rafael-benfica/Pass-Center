<template>
  <div class="fonte">
    <div class="row area-exibicao">
      <div class="col s12 m3 l3 espacamento" v-for="item in disciplinas" :key="item.id">
        <!-- {{ item }} -->
        <div class="card">
          <div class="card-image">
            <a
              class="btn-floating halfway-fab waves-effect waves-light blue darken-1 btn modal-trigger botao"
              href="#modal1"
            >
              <i class="material-icons">history</i>
            </a>
          </div>
          <div class="card-content">
            <span class="card-title tituloCard">{{ item.eve_nome }}</span>
            <p class="turmaCard">{{ item.eve_sigla }}</p>
            <p class="horarioCard">{{ item.eau_periodo_identificacao }}</p>
          </div>
        </div>
      </div>
    </div>
    <div id="modal1" class="modal bottom-sheet">
      <div class="modal-content">
        <h4 class="col s10 m12 l12 historico">Histórico</h4>

        <div class="row">
          <div class="data col s4 m1 l1" v-for="item in 24" :key="item.id">
            <div class="waves-effect waves-teal btn-large botaoDatas">22/11</div>
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
  name: "MinhasDisciplinas",
  data() {
    return {
      disciplinas: []
    };
  },
  mounted: function() {
    $(document).ready(function() {
      $(".modal").modal();
    });

    this.$http.get("EventosAuditores/Disciplinas").then(
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
  }
};
</script>

<style src="./../../assets/css/professor/MinhasDisciplinas.css" scoped></style>
