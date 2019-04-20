<template>
  <div>
    <div class="row area-exibicao">
      <!-- Etapa 01 -->
      <div v-if="etapa==1">
        <div class="col s12 m4 l4 espacamento" v-for="item in disciplinas" :key="item.id">
          <div class="card" @click="carregarlista(item.eau_codigo); etapa++">
            <div class="card-content">
              <span class="card-title cardDisciplina">{{ item.eve_nome }}</span>
            </div>
          </div>
        </div>
      </div>

      <!-- Etapa 02 -->
      <form
        class="col offset-m3 m5 s12 card ajuste espacamento"
        onsubmit="return false"
        v-show="etapa==2"
      >
        <div class="row">
          <div class="col offset-m1 m10 s12">
            <div class="row">
              <div class="col s12 m12 l12">
                <h3 class="center-align">Entre com a data e a hora de início da aula</h3>
              </div>
            </div>

            <div class="row">
              <div class="input-field col s12 m12 l12">
                <input id="data" type="text" class="datepicker" v-model="data">
                <label for="data">Data:</label>
              </div>
            </div>

            <div class="row">
              <div class="input-field col s12 m12 l12">
                <input id="hora" type="text" class="timepicker" v-model="hora">
                <label for="hora">Horário:</label>
              </div>
            </div>

            <div class="row">
              <div class="col s12 m12 l12 historico center-align">
                <button
                  class="btn waves-effect waves-light"
                  type="submit"
                  name="action"
                  @click="etapa++"
                >
                  Search
                  <i class="material-icons right">send</i>
                </button>
              </div>
            </div>
          </div>
        </div>
      </form>
      <!-- Etapa 03 -->

      <form class="col s12 card data2" onsubmit="return false" v-if="etapa==3">
        <div class="row topo">
          <div class="col s12 m12 l12">
            <table>
              <thead class="centro">
                <tr>
                  <th></th>
                  <th>Nome do Aluno</th>
                  <th>Matrícula do do Aluno</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="item in lista" :key="item.id">
                  <td>
                    <label>
                      <input type="checkbox" checked="checked" @click="addAsentes(item.usu_codigo)">
                      <span></span>
                    </label>
                  </td>
                  <td>{{ item.nomes_concatenados }}</td>
                  <td>{{ item.pes_matricula }}</td>
                </tr>
              </tbody>
            </table>
            <div class="col s12 m12 l12 historico data">
              <button class="btn waves-effect waves-light" @click="confirmação()">Salvar</button>

              <button class="btn waves-effect waves-light" type="submit" name="action">Cancelar</button>
            </div>
          </div>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  name: "MinhasDisciplinasAluno",
  data() {
    return {
      disciplinas: [],
      lista: [],
      ausentes: [],
      hora: "",
      data: "",
      etapa: 1
    };
  },
  mounted: function() {
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

    var ano = new Date().getFullYear();

    var self = this;

    $(".datepicker").datepicker({
      format: "dd/mm/yyyy",
      yearRange: [ano - 100, ano],
      maxDate: new Date(),
      defaultDate: new Date(),
      setDefaultDate: true,
      onClose: function(params) {
        self.atualizaData();
      },
      i18n: {
        months: [
          "Janeiro",
          "Fevereiro",
          "Março",
          "Abril",
          "Maio",
          "Junho",
          "Julho",
          "Agosto",
          "Setembro",
          "Outubro",
          "Novembro",
          "Dezembro"
        ],
        monthsShort: [
          "Jan",
          "Fev",
          "Mar",
          "Abr",
          "Mai",
          "Jun",
          "Jul",
          "Ago",
          "Set",
          "Out",
          "Nov",
          "Dez"
        ],
        weekdays: [
          "Domingo",
          "Segunda",
          "Terça",
          "Quarta",
          "Quinta",
          "Sexta",
          "Sabádo"
        ],
        weekdaysShort: ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sab"],
        weekdaysAbbrev: ["D", "S", "T", "Q", "Q", "S", "S"],
        today: "Hoje",
        clear: "Limpar",
        close: "Pronto",
        labelMonthNext: "Próximo mês",
        labelMonthPrev: "Mês anterior",
        labelMonthSelect: "Selecione um mês",
        labelYearSelect: "Selecione um ano",
        selectMonths: true,
        cancel: "Fechar",
        clear: "Limpar"
      }
    });

    $(".timepicker").timepicker({
      twelveHour: false,
      onCloseEnd: function(params) {
        self.atualizaHora();
      },
      i18n: {
        done: "Pronto",
        cancel: "Fechar"
      }
    });
  },

  methods: {
    atualizaData() {
      var data = $("#data").val();
      this.data = data;
    },

    atualizaHora() {
      this.hora = $("#hora").val();
    },

    carregarlista(id) {
      this.$http.get("Turmas", { params: { eau_codigo: id } }).then(
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
    },

    addAsentes(usu_codigo) {
      this.ausentes.push(usu_codigo);
    }
  }
};
</script>

<style src="./../../assets/css/professor/GeralProfessores.css" scoped></style>
