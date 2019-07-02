<template>
  <div>
    <div class="row area-exibicao">
      <!-- Etapa 01 -->
      <div v-if="etapa==1">
        <div class="col s12 m4 l4 espacamento" v-for="item in disciplinas" :key="item.id">
          <div class="card" @click="vEau_codigo = item.eau_codigo; etapa++">
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
                <h3 class="center-align">Entre com a data, a hora de início e a hora do fim da aula</h3>
              </div>
            </div>

            <div class="row">
              <div class="input-field col s12 m12 l12">
                <input
                  id="data"
                  type="text"
                  class="datepicker"
                  v-model="data"
                  placeholder="Entre com a data da Aula"
                />
                <label for="data">Data:</label>
              </div>
            </div>

            <div class="row">
              <div class="input-field col s12 m6 l6">
                <input id="horaEntrada" type="text" class="timepickerInicio" v-model="horaEntrada" />
                <label for="horaEntrada">Horário do Início:</label>
              </div>
              <div class="input-field col s12 m6 l6">
                <input id="horaFim" type="text" class="timepickerFim" v-model="horaFim" />
                <label for="horaFim">Horário do Fim:</label>
              </div>
            </div>

            <div class="row">
              <div class="col s12 m6 l6 historico center-align">
                <a class="waves-effect waves-light btn red" @click="etapa--">Voltar</a>
              </div>
              <div class="col s12 m6 l6 historico center-align">
                <a
                  class="waves-effect waves-light btn green"
                  @click="carregarlista(); etapa++"
                >Avançar</a>
              </div>
            </div>
          </div>
        </div>
      </form>
      <!-- Etapa 03 -->

      <form class="col offset-m3 m6 s12 card" onsubmit="return false" v-if="etapa==3">
        <div class="row topo">
          <div class="col s12 m12 l12">
            <table>
              <thead class="centro">
                <tr>
                  <th></th>
                  <th>Nome do Aluno</th>
                  <th>Matrícula do Aluno</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="item in lista" :key="item.id">
                  <td>
                    <label>
                      <input type="checkbox" checked="checked" @click="addAsentes(item.usu_codigo)" />
                      <span></span>
                    </label>
                  </td>
                  <td>{{ item.nomes_concatenados }}</td>
                  <td>{{ item.pes_matricula }}</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
        <div class="row">
          <div class="col s12 m12 l12">
            <a class="waves-effect waves-light btn red" @click="etapa--">Voltar</a>
            <a class="waves-effect waves-light btn green" @click="enviarLista();">Salvar</a>
          </div>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  name: "ListaManual",
  data() {
    return {
      disciplinas: [],
      lista: [],
      ausentes: ["(0)"],
      horaEntrada: "",
      horaFim: "",
      data: "",
      vEau_codigo: "",
      etapa: 1
    };
  },
  mounted: function() {
    this.obtemDados();

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

    $(".timepickerInicio").timepicker({
      twelveHour: false,
      onCloseEnd: function(params) {
        self.atualizahoraEntrada();
      },
      i18n: {
        done: "Pronto",
        cancel: "Fechar"
      }
    });

    $(".timepickerFim").timepicker({
      twelveHour: false,
      onCloseEnd: function(params) {
        self.atualizaHoraFim();
      },
      i18n: {
        done: "Pronto",
        cancel: "Fechar"
      }
    });
  },

  watch: {
    etapa(value) {
      if (value == 2) {

        this.horaEntrada = this.horaFim = this.data = "";

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

        $(".timepickerInicio").timepicker({
          twelveHour: false,
          onCloseEnd: function(params) {
            self.atualizahoraEntrada();
          },
          i18n: {
            done: "Pronto",
            cancel: "Fechar"
          }
        });

        $(".timepickerFim").timepicker({
          twelveHour: false,
          onCloseEnd: function(params) {
            self.atualizaHoraFim();
          },
          i18n: {
            done: "Pronto",
            cancel: "Fechar"
          }
        });
        $(document).ready(function() {
          M.updateTextFields();
        });
      }
    }
  },

  methods: {
    obtemDados() {
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
    },
    atualizaData() {
      var data = $("#data").val();
      this.data = data;
    },

    atualizahoraEntrada() {
      this.horaEntrada = $("#horaEntrada").val();
    },
    atualizaHoraFim() {
      this.horaFim = $("#horaFim").val();
    },

    carregarlista() {
      this.$http
        .get("Turmas", { params: { eau_codigo: this.vEau_codigo } })
        .then(
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
      var pos = this.ausentes.indexOf(usu_codigo);

      if (pos == -1) {
        this.ausentes.push(usu_codigo);
      } else {
        this.ausentes.splice(pos, 1);
      }
    },

    enviaHora(horaX) {
      var data = this.data.split("/").reverse();
      return data[0] + "-" + data[1] + "-" + data[2] + " " + horaX;
    },

    enviarLista() {
      const swalWithBootstrapButtons = swal.mixin({
        confirmButtonClass: "btn green sepraracaoBotoes",
        cancelButtonClass: "btn red sepraracaoBotoes",
        buttonsStyling: false
      });

      swalWithBootstrapButtons({
        title: "Todos os dados estão corretos?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sim, salve!",
        cancelButtonText: "Não, cancele!",
        reverseButtons: true
      }).then(result => {
        if (result.value) {
          var dadosPresencas = {
            vEau_codigo: {
              Eau_codigo: Number(this.vEau_codigo)
            },
            list_of_ids: this.ausentes.toString(),
            Pre_horario_entrada: this.enviaHora(this.horaEntrada),
            Pre_horario_saida: this.enviaHora(this.horaFim),
            Hev_codigo: {
              Hev_codigo: 1
            }
          };

          this.$http.post("Presencas", dadosPresencas).then(
            response => {
              swalWithBootstrapButtons(
                "Salvo!",
                "Todas as informações foram salvas.",
                "success"
              );

              
        this.etapa = 1;
            },
            response => {
              this.erro("Dados Evento", response.status);
            }
          );
        } else if (result.dismiss === swal.DismissReason.cancel) {
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

<style src="./../../assets/css/professor/GeralProfessores.css" scoped></style>
