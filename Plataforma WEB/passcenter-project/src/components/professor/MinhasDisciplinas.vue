<template>
  <div class="fonte">
    <div class="row area-exibicao">
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
    <div id="modal1" class="modal bottom-sheet">
      <div class="modal-content">
        <h4 class="col s10 m12 l12 historico">{{ nomeHistorico }}</h4>
        <h5 class="col s10 m12 l12 historico">Últimas Aulas</h5>
        <div class="row">
          <div
            class="col s12 m3 l3 espacamento"
            v-for="itemSessoes in sessoes"
            :key="itemSessoes.id"
          >
            <div
              class="card modal-trigger"
              href="#modal2"
              @click="carregarlista(itemSessoes); dataHistorico = sessaoHistoricoObj.ses_horario_inicio;"
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
        <div class="row">
          <div class="col s12 center-align">
            <h3>{{ nomeHistorico }}</h3>
            <h4>{{ this.recebeData(dataHistorico) }}</h4>
          </div>
        </div>
        <div class="col s12 m12 l12">
          <table>
            <thead class="centro">
              <tr>
                <th>Nome do Aluno</th>
                <th>Matrícula do Aluno</th>
                <th>Horário de entrada</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="item in lista" :key="item.id">
                <td>{{ item.nomes_concatenados }}</td>
                <td>{{ item.pes_matricula }}</td>
                <td v-if="item.ses_codigo != null">{{ item.pre_horario_entrada.substr(11,5) }}</td>
                <td v-else>Aluno Ausente</td>
                <td v-if="item.ses_codigo != null">
                  <a
                    class="waves-effect waves-light btn red accent-4"
                    @click="removeAlunoHistorico( item.ses_codigo, item.ide_codigo);"
                  >
                    <i class="material-icons left">close</i>Remover presença
                  </a>
                </td>
                <td v-else>
                  <a
                    class="waves-effect waves-light btn green accent-4"
                    @click="adicionaAlunoHistorico( sessaoHistoricoObj.ses_codigo, item.ide_codigo);"
                  >
                    <i class="material-icons left">check_circle</i>Adicionar presença
                  </a>
                </td>
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
              <th>Horário de entrada</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="item in alunosLive" :key="item.id">
              <td>{{ item.nomes_concatenados }}</td>
              <td>{{ item.pes_matricula }}</td>
              <td v-if="item.ses_codigo != null">{{ item.pre_horario_entrada.substr(11,5) }}</td>
              <td v-else>Aluno Ausente</td>
              <td v-if="item.ses_codigo != null">
                <a
                  class="waves-effect waves-light btn red accent-4"
                  @click="removeAluno( item.ses_codigo, item.ide_codigo)"
                >
                  <i class="material-icons left">close</i>Remover presença
                </a>
              </td>
              <td v-else>
                <a
                  class="waves-effect waves-light btn green accent-4"
                  @click="adicionaAluno( item.ide_codigo, disciplinasSelecionada.eau_codigo)"
                >
                  <i class="material-icons left">check_circle</i>Adicionar presença
                </a>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      <div class="modal-footer">
        <a class="modal-close waves-effect waves-green btn" @click="fechaSessao(disciplinasSelecionada.eau_codigo)">Encerrar Sessão</a>
        <a class="modal-close waves-effect waves-green btn-flat">Fechar</a>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "MinhasDisciplinas",
  data() {
    return {
      sessaoHistoricoObj: {},
      dataHistorico: "",
      nomeHistorico: "",
      disciplinas: [],
      sessoes: [],
      lista: [],
      intervalo: {},
      alunosLive: [],
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
    this.para();
  },

  methods: {
    fechaSessao(eau) {
      this.$http.get("Sessao/Live", { params: { eau_codigo: eau } }).then(
        response => {
          var dados = {
            ses_codigo: response.body,
            eau_codigo: {
              eau_codigo: eau
            }
          };

          this.$http.post("Totens/Sessoes/fechar", dados).then(
            response => {
              swal({
                title: "Tudo feito!",
                text: "O Encerramento da disciplina foi realizado com sucesso!",
                type: "success"
              });
            },
            response => {
              this.erro("Dados de Adição de Participante", response.status);
            }
          );
        },
        response => {
          this.erro("Sessão in Live", response.status);
        }
      );
    },
    adicionaAluno(ide, eau) {
      this.$http.get("Sessao/Live", { params: { eau_codigo: eau } }).then(
        response => {
          var dados = {
            ses_codigo: {
              ses_codigo: response.body
            },
            ide_codigo: {
              ide_codigo: ide
            }
          };

          this.$http.post("Presencas/Manuais", dados).then(
            response => {},
            response => {
              this.erro("Dados de Adição de Participante", response.status);
            }
          );
        },
        response => {
          this.erro("Sessão in Live", response.status);
        }
      );
    },

    adicionaAlunoHistorico(ses, ide) {
      var dados = {
        ses_codigo: {
          ses_codigo: ses
        },
        ide_codigo: {
          ide_codigo: ide
        }
      };

      this.$http.post("Presencas/Manuais", dados).then(
        response => {
          this.carregarlista(this.sessaoHistoricoObj);
        },
        response => {
          this.erro("Dados de Adição de Participante", response.status);
        }
      );
    },
    removeAluno(ses, ide) {
      var dados = {
        ses_codigo: {
          ses_codigo: ses
        },
        ide_codigo: ide
      };

      this.$http
        .delete("Presencas/Manuais", {
          params: { ses_codigo: ses, ide_codigo: ide }
        })
        .then(
          response => {},
          response => {
            this.erro("Dados de Remoção de Participante", response.status);
          }
        );
    },
    removeAlunoHistorico(ses, ide) {
      var dados = {
        ses_codigo: {
          ses_codigo: ses
        },
        ide_codigo: ide
      };

      this.$http
        .delete("Presencas/Manuais", {
          params: { ses_codigo: ses, ide_codigo: ide }
        })
        .then(
          response => {
            this.carregarlista(this.sessaoHistoricoObj);
          },
          response => {
            this.erro("Dados de Remoção de Participante", response.status);
          }
        );
    },
    para() {
      clearInterval(this.intervalo);
    },
    modalDisciplinaAtiva(item) {
      if (item.eau_operacao == true) {
        var self = this;

        this.para();

        console.log(item);
        this.disciplinasSelecionada = item;
        var modal = document.querySelector("#modalDisciplinaAtiva");
        var instance = M.Modal.init(modal, {
          dismissible: false,
          onCloseStart: function() {
            clearInterval(self.intervalo);
            self.obtemDados();
          }
        });
        instance.open();
        this.$http
          .get("Presencas/live", { params: { eau_codigo: item.eau_codigo } })
          .then(
            response => {
              this.alunosLive = response.body;
              console.log("Obteve Alunos!");
            },
            response => {
              console.log(
                "ERRO ao carregar os Dados! Código de resposta (HTTP) do servidor: " +
                  response.status
              );
            }
          );

        this.intervalo = setInterval(() => {
          this.$http
            .get("Presencas/live", { params: { eau_codigo: item.eau_codigo } })
            .then(
              response => {
                this.alunosLive = response.body;
                console.log("Obteve Alunos!");
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
      }
    },
    obtemDados: function() {
      console.log("Obtendo dados...");

      this.intervalo = setInterval(() => {
        this.$http.get("EventosAuditores/Disciplinas").then(
          response => {
            this.disciplinas = response.body;
            console.log("Obteve Disciplinas!");
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
    carregarlista(item) {
      this.sessaoHistoricoObj = item;

      this.$http
        .get("Presencas", {
          params: {
            ses_codigo: this.sessaoHistoricoObj.ses_codigo,
            eau_codigo: this.sessaoHistoricoObj.eau_codigo
          }
        })
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

<style src="./../../assets/css/professor/MinhasDisciplinas.css" scoped=""></style>
