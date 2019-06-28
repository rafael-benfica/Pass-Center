<template>
  <div class="row area-exibicao">
    <form class="col s12 card data2" onsubmit="return false">
      <div class="row topo">
        <div class="col s12 m12 l12">
          <h3 class="col s12 m12 l12 centro">Financeiro</h3>

          <table>
            <thead class="centro">
              <tr>
                <th>Nome da Instituição</th>
                <th>Valor total</th>
                <th>Data da Cobrança</th>
                <th>Data do Vencimento</th>
                <th>Data do Pagamento</th>
                <th>Ação</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="item in financeiro" :key="item.id">
                <td>{{ item.ins_nome_fantasia}}</td>
                <td>{{ "R$ "+((item.pla_qtd_tags * item.pla_preco_tags) + (item.pla_qtd_totens * item.pla_preco_totens)) }}</td>
                <td>{{ recebeData(item.pag_data_criacao) }}</td>
                <td>{{ recebeData(item.pag_data_vencimento) }}</td>
                <td v-if="item.pag_data_pagamento != null">{{ recebeData(item.pag_data_pagamento) }}</td>
                <td v-else>Em aberto</td>
                <td v-if="item.pag_data_pagamento != null">
                  <a class="waves-effect waves-light btn disabled">Pago</a>
                </td>
                <td v-else>
                  <a
                    class="waves-effect waves-light btn green"
                    @click="confirmacaoUpdate(item.pag_codigo)"
                  >Pago</a>
                </td>
              </tr>
            </tbody>
          </table>

          <a
            class="col s12 m12 l12 centro waves-effect waves-light btn botaoVerMais"
            @click="addDados()"
          >Adicionar Cobrança</a>

          <div id="modalAdd" class="modal margem">
            <div class="modal-content">
              <h4 class="centro">Cadastro Plano</h4>
              <hr>

              <div class="row correcao">
                <div class="col s6">
                  <div class="row">
                    <div class="input-field col s12">
                      <select v-model="instituicao">
                        <option value disabled selected>Selecione a Instituição</option>
                        <option
                          :value="item"
                          v-for="item in instituicoes"
                          :key="item.id"
                        >{{ item.ins_nome_fantasia }}</option>
                      </select>
                      <label>Instituição</label>
                    </div>
                  </div>

                  <div class="row correcao" v-show="selecionou">
                    <div class="input-field col s12">
                      <select v-model="estado">
                        <option value disabled selected>Selecione o Estado</option>
                        <option value="true">Pago</option>
                        <option value="false">Pendente</option>
                      </select>
                      <label>Estado</label>
                    </div>
                  </div>
                </div>

                <div class="col s6 correcao" v-show="selecionou">
                  <div class="row">
                    <div class="col s12 m12 l12">
                      <div class="input-field col s12 m6">
                        <input
                          id="dataCriacao"
                          type="text"
                          class="datepicker"
                          v-model="dataCriacao"
                        >
                        <label for="dataCriacao">Data da Cobrança:</label>
                      </div>

                      <div class="input-field col s12 m6">
                        <input
                          id="dataVencimento"
                          type="text"
                          class="datepicker"
                          v-model="dataVencimento"
                        >
                        <label for="dataVencimento">Data do Vencimento:</label>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <div class="modal-footer row col s12 m12 l12">
              <a class="col s12 m4 l4 modal-close waves-effect waves-teal btn red">Cancelar</a>
              <p class="col s12 m4 l4"></p>
              <a
                class="col s12 m4 l4 waves-effect waves-teal btn green"
                @click="confirmacaoCriar()"
                v-if="selecionou"
              >Confirmar</a>
            </div>
          </div>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
export default {
  name: "financeiro",
  data() {
    return {
      financeiro: [],
      instituicoes: [],
      estado: true,
      instituicao: 0,
      dataCriacao: "",
      dataVencimento: "",
      selecionou: false
    };
  },

  mounted() {
    $(document).ready(function() {
      $(".modal").modal();
      M.updateTextFields();
      $("select").formSelect();
    });

    this.carregarDados();

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
    recebeData(data) {
      var array = data
        .replace("T00:00:00", "")
        .split("-")
        .reverse();
      return array[0] + "/" + array[1] + "/" + array[2];
    },
    enviaData(ele) {
      var data = ele.split("/").reverse();
      return data[0] + "-" + data[1] + "-" + data[2];
    },
    carregarDados() {
      this.$http.get("Pagamentos/ADM").then(
        response => {
          this.financeiro = response.body;
        },
        response => {
          this.erro("Pagamentos", response.status);
        }
      );
    },

    addDados() {
      var self = this;

      var modal = document.querySelector("#modalAdd");
      var instance = M.Modal.init(modal, {
        dismissible: false,
        onCloseStart: function() {
          clearInterval(self.intervalo);
          self.instituicao = "";
        }
      });
      instance.open();

      this.instituicao = "";

      $(document).ready(function() {
        M.updateTextFields();
        $("select").formSelect();
      });
    },

    atualizaDataCriacao() {
      var data = $("#dataCriacao").val();
      this.dataCriacao = data;
    },

    atualizaDataVencimento() {
      var data = $("#dataVencimento").val();
      this.dataVencimento = data;
    },

    confirmacaoUpdate(codigo) {
      const swalWithBootstrapButtons = swal.mixin({
        confirmButtonClass: "btn green sepraracaoBotoes",
        cancelButtonClass: "btn red sepraracaoBotoes",
        buttonsStyling: false
      });

      swalWithBootstrapButtons({
        title: "Você tem certeza?",
        text: "Você não poderá reverter essa ação!",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sim, faça!",
        cancelButtonText: "Não, cancele!",
        reverseButtons: true
      }).then(result => {
        if (result.value) {
          var today = new Date();
          var dd = String(today.getDate()).padStart(2, "0");
          var mm = String(today.getMonth() + 1).padStart(2, "0"); //January is 0!
          var yyyy = today.getFullYear();

          const dadosFinanceiro = {
            pag_codigo: codigo,
            pag_data_pagamento: yyyy + "-" + mm + "-" + dd
          };

          this.$http.put("Pagamentos", dadosFinanceiro).then(
            response => {
              this.carregarDados();
              swalWithBootstrapButtons(
                "Alterado!",
                "As alterações foram salvas.",
                "success"
              );
            },
            response => {
              this.erro("financeiro", response.status);
            }
          );
        } else if (
          // Read more about handling dismissals
          result.dismiss === swal.DismissReason.cancel
        ) {
          this.carregarDados();
          swalWithBootstrapButtons(
            "Cancelado!",
            "Alterações não enviadas!",
            "error"
          );
        }
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
          var dadosFinanceiro = {
            pag_data_criacao: this.enviaData(this.dataCriacao),
            pag_data_vencimento: this.enviaData(this.dataVencimento),
            pag_data_pagamento: null,
            ins_codigo: {
              ins_codigo: this.instituicao.ins_codigo
            }
          };

          if (this.estado) {
            dadosFinanceiro = {
              pag_data_criacao: this.enviaData(this.dataCriacao),
              pag_data_vencimento: this.enviaData(this.dataVencimento),
              pag_data_pagamento: this.enviaData(this.dataCriacao),
              ins_codigo: {
                ins_codigo: this.instituicao.ins_codigo
              }
            };
          }
          this.$http.post("Pagamentos", dadosFinanceiro).then(
            response => {
              this.carregarDados();
              swalWithBootstrapButtons(
                "Salvo!",
                "Todas as informações foram salvas.",
                "success"
              );
            },
            response => {
              this.erro("Dados dos Pagamentos", response.status);
            }
          );
        } else if (
          // Read more about handling dismissals
          result.dismiss === swal.DismissReason.cancel
        ) {
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
        text: "Algo deu errado! Entre em contato com os Administradores!",
        type: "error"
      }),
        console.log(
          "ERRO em " + msg + "! Código de resposta (HTTP) do servidor: " + code
        );
    }
  },

  watch: {
    instituicao(value) {
      if (value != "") {
        this.selecionou = true;

        var self = this;

        var ano = new Date().getFullYear();

        var today = new Date();
        var dd = String(today.getDate()).padStart(2, "0");
        var mm = String(today.getMonth() + 1).padStart(2, "0"); //January is 0!
        var yyyy = today.getFullYear();

        this.dataCriacao = dd + "/" + mm + "/" + yyyy;

        var outraData = new Date();
        outraData.setDate(today.getDate() + value.ins_periodo_renovacao_dias); // Adiciona 3 dias

        dd = String(outraData.getDate()).padStart(2, "0");
        mm = String(outraData.getMonth() + 1).padStart(2, "0"); //January is 0!
        yyyy = outraData.getFullYear();

        this.dataVencimento = dd + "/" + mm + "/" + yyyy;

        $("#dataCriacao").datepicker({
          format: "dd/mm/yyyy",
          yearRange: [ano - 100, ano],
          maxDate: new Date(),
          defaultDate: new Date(),
          onClose: function(params) {
            self.atualizaDataCriacao();
          },
          setDefaultDate: true,
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

        $("#dataVencimento").datepicker({
          format: "dd/mm/yyyy",
          yearRange: [ano - 100, ano],
          defaultDate: outraData,
          setDefaultDate: true,
          onClose: function(params) {
            self.atualizaDataVencimento();
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

        $(document).ready(function() {
          M.updateTextFields();
        });
      } else {
        this.selecionou = false;
        this.estado = false;
        this.dataCriacao = "";
        this.dataVencimento = "";
      }
    }
  }
};
</script>

<style src="./../../assets/css/gerenteGeral/Financeiro.css" scoped></style>
<style src="./../../assets/css/gerenteGeral/tables.css" scoped></style>
   
