<template>
  <div>
    <div class="row area-exibicao">
      <div class="col s12 m3 l3 espacamento" v-for="item in 1" :key="item.id">
        <a class="dropdown-trigger btn" href="#" data-target="dropdown1">
          <i class="material-icons left">insert_invitation</i>Selecione uma data:
        </a>

        <!-- Dropdown Structure -->
        <ul id="dropdown1" class="dropdown-content">
          <li v-for="item in periodos" :key="item.id">
            <router-link
              :to="{ name: 'HistoricoCompletoDisciplinas' }"
              class="waves-effect"
            >{{ item.eau_periodo_identificacao }}</router-link>
          </li>
        </ul>
      </div>

      <div
        class="col s12 m3 l3 espacamento"
        v-for="itemDisciplinas in disciplinas"
        :key="itemDisciplinas.id"
      >
        <!-- {{ item }} -->
        <div class="card" :class="{ pulse: itemDisciplinas.eau_operacao}">
          <div class="card-image">
            <a
              class="btn-floating halfway-fab waves-effect waves-light blue darken-1 btn modal-trigger botao"
              href="#modal1"
            >
              <i
                class="material-icons"
                @click="carregarSessoes(itemDisciplinas.eau_codigo); nomeHistorico = itemDisciplinas.eve_nome"
              >history</i>
            </a>
          </div>
          <div class="card-content" @click="modalDisciplinaAtiva(itemDisciplinas)">
            <span class="card-title tituloCard">{{ itemDisciplinas.eve_nome }}</span>
            <p class="turmaCard">{{ itemDisciplinas.eve_sigla }}</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "HistoricoCompletoProfessor",
  data() {
    return {
      periodos: {}
    };
  },
  mounted: function() {
    $(document).ready(function() {
      $(".dropdown-trigger").dropdown();
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

  methods: {}
};
</script>
<style src="./../../assets/css/professor/MinhasDisciplinas.css" scoped></style>