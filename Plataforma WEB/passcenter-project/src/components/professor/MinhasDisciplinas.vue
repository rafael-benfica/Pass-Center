<template>
  <div class="fonte">
    <div class="row area-exibicao">
      <div
        class="col s12 m3 l3 espacamento"
        v-for="itemDisciplinas in disciplinas"
        :key="itemDisciplinas.id"
      >
        <div class="card" :class="{ pulse: itemDisciplinas.eau_operacao}">
          <div class="card-image">
            <a class="btn-floating halfway-fab waves-effect waves-light blue darken-1 btn botao">
              <i
                class="material-icons"
                @click="carregarSessoes(itemDisciplinas.eau_codigo); nomeHistorico = itemDisciplinas.eve_nome; eau_codigo=itemDisciplinas.eau_codigo;"
              >history</i>
            </a>
          </div>
          <div class="card-content" @click="modalDisciplinaAtiva(itemDisciplinas)">
            <span class="card-title tituloCard">{{ itemDisciplinas.eve_nome }}</span>
            <p class="turmaCard">{{ itemDisciplinas.eve_sigla }}</p>
          </div>
          <div class="card-action center-align">
            <div class="row linha" v-if="itemDisciplinas.eau_operacao">
              <div class="col s12 m6">
                <a
                  class="waves-effect waves-light btn"
                  @click="carregarRelatorio(itemDisciplinas.eau_codigo); nomeHistorico = itemDisciplinas.eve_nome;"
                >Ver mais</a>
              </div>
              <div class="col s12 m6">
                <a
                  class="waves-effect waves-light btn red"
                  @click="modalDisciplinaAtiva(itemDisciplinas)"
                >Ao Vivo</a>
              </div>
            </div>
            <a
              v-else
              class="waves-effect waves-light btn"
              @click="carregarRelatorio(itemDisciplinas.eau_codigo); nomeHistorico = itemDisciplinas.eve_nome;"
            >Ver mais</a>
          </div>
        </div>
      </div>
    </div>

    <!-- Modal Sessões -->
    <div id="modalSessoes" class="modal bottom-sheet modal-fixed-footer">
      <div class="modal-content">
        <div class="row">
          <div class="col offset-m3 m6 s12">
            <h4 class="historico">{{ nomeHistorico }}</h4>
            <br>
            <h5 class="historico" v-if="verTodas">Todas as Aulas</h5>
            <h5 class="historico" v-else>Últimas Aulas</h5>
          </div>
          <div class="col offset-m2 m1 s12">
            <div class="row historico" v-show="!carregandoVerTodas">
              <div class="col s12">
                <h6>
                  Ver todas
                  <br>as Aulas
                </h6>
              </div>
            </div>
            <div class="row center-align">
              <div class="switch col s12" v-show="!carregandoVerTodas">
                <label v-if="!verTodas">
                  <input type="checkbox" disabled>
                  <span class="lever" @click="carregarTodasSessoes();"></span>
                </label>
                <label v-else>
                  <input type="checkbox" checked disabled>
                  <span class="lever" @click="carregarTodasSessoes();"></span>
                </label>
              </div>
              <div v-show="carregandoVerTodas" class="preloader-wrapper active">
                <div class="spinner-layer spinner-blue-only">
                  <div class="circle-clipper left">
                    <div class="circle"></div>
                  </div>
                  <div class="gap-patch">
                    <div class="circle"></div>
                  </div>
                  <div class="circle-clipper right">
                    <div class="circle"></div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div class="row">
          <div
            class="col s12 m3 l3 espacamento"
            v-for="itemSessoes in sessoes"
            :key="itemSessoes.id"
          >
            <div
              class="card modal-trigger"
              href="#modalHistorico"
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
      </div>
      <div class="modal-footer">
        <a class="modal-close waves-effect waves-green btn-flat">Fechar</a>
      </div>
    </div>

    <!-- Modal Historico -->
    <div id="modalHistorico" class="modal modal-fixed-footer">
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
        <a class="modal-close waves-effect waves-green btn-flat">Fechar</a>
      </div>
    </div>

    <!-- Modal Live -->
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
        <a
          class="modal-close waves-effect waves-green btn"
          @click="fechaSessao(disciplinasSelecionada.eau_codigo)"
        >Encerrar Sessão</a>
        <a class="modal-close waves-effect waves-green btn-flat">Fechar</a>
      </div>
    </div>

    <!-- Modal Relatório -->
    <div id="modalRelatorio" class="modal modal-fixed-footer">
      <div class="modal-content">
        <div class="row">
          <div class="col s12 center-align">
            <h4>{{ nomeHistorico }}</h4>
          </div>
          <div class="col s12 center-align">
            <h5>Relatório Geral</h5>
          </div>
        </div>

        <table v-if="existeSessoes == true">
          <thead class="centro">
            <tr>
              <th>Nome do Aluno</th>
              <th>Presenças/Aulas</th>
              <th>% Presenças/Aulas</th>
              <th>% Faltas/Aulas</th>
              <th>Faltas</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="item in relatorio" :key="item.id">
              <td>{{ item.nome }}</td>
              <td>{{ item.presencas + "/"+ item.sessoes }}</td>
              <td>{{ ((item.presencas / item.sessoes)*100).toFixed(2) + "%" }}</td>
              <td>{{ (((item.sessoes-item.presencas) / item.sessoes)*100).toFixed(2) + "%" }}</td>
              <td>{{ item.sessoes - item.presencas }}</td>
            </tr>
          </tbody>
        </table>

        <div class="row center-align" v-else>
          <div class="col s12">
            <p>Ainda não existem dados para esta disciplina.</p>
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
  name: "MinhasDisciplinas",
  data() {
    return {
      disciplinas: [],
      sessoes: [],
      lista: [],
      intervalo: {},
      alunosLive: [],
      relatorio: [],
      disciplinasSelecionada: {},
      sessaoHistoricoObj: {},
      dataHistorico: "",
      nomeHistorico: "",
      eau_codigo: 0,
      verTodas: false,
      carregandoVerTodas: false,
      existeSessoes: false
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
        this.erro("Disciplinas", response.status);
      }
    );
  },

  beforeDestroy() {
    this.para();
  },

  methods: {
    carregarRelatorio(eau) {
      var self = this;

      this.para();

      var modal = document.querySelector("#modalRelatorio");
      var instance = M.Modal.init(modal, {
        dismissible: false,
        onCloseStart: function() {
          clearInterval(self.intervalo);
          self.obtemDados();
        }
      });
      instance.open();

      this.$http
        .get("Presencas/Relatorio", { params: { eau_codigo: eau } })
        .then(
          response => {
            this.relatorio = response.body;

            if (this.relatorio["0"].sessoes != 0) {
              this.existeSessoes = true;
            } else {
              this.existeSessoes = false;
            }

            console.log("Obteve relatorio!");
          },
          response => {
            this.erro("Disciplinas Ao vivo", response.status);
          }
        );
    },

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
                "ERRO ao carregar os Alunos ao vivo! Código de resposta (HTTP) do servidor: " +
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
                "ERRO ao carregar os Alunos ao vivo! Código de resposta (HTTP) do servidor: " +
                  response.status
              );
                instance.close();
              }
            );
        }, 500);
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
            this.erro("Disciplinas Ao vivo", response.status);
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
      var self = this;

      this.para();

      var modal = document.querySelector("#modalSessoes");

      var instance = M.Modal.init(modal, {
        dismissible: false,
        onCloseStart: function() {
          clearInterval(self.intervalo);
          self.obtemDados();
        }
      });

      this.verTodas = false;

      instance.open();

      this.$http.get("Sessoes", { params: { eau_codigo: id } }).then(
        response => {
          this.sessoes = response.body;
        },
        response => {
          this.erro("Últimas Sessões", response.status);
        }
      );
    },

    carregarTodasSessoes() {
      if (!this.verTodas) {
        this.verTodas = !this.verTodas;
        this.carregandoVerTodas = true;
        this.$http
          .get("Sessoes/Historico", { params: { eau_codigo: this.eau_codigo } })
          .then(
            response => {
              this.sessoes = response.body;
              this.carregandoVerTodas = false;
            },
            response => {
              this.erro("Todas as Sessões", response.status);
              this.carregandoVerTodas = false;
            }
          );
      } else {
        this.carregandoVerTodas = true;
        this.verTodas = !this.verTodas;
        this.$http
          .get("Sessoes", { params: { eau_codigo: this.eau_codigo } })
          .then(
            response => {
              this.sessoes = response.body;
              this.carregandoVerTodas = false;
            },
            response => {
              this.erro("Últimas Sessões", response.status);
              this.carregandoVerTodas = false;
            }
          );
      }
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
            this.erro("Lista", response.status);
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
          "ERRO ao atualizar " +
            msg +
            "! Código de resposta (HTTP) do servidor: " +
            code
        );
      this.$store.commit("LOGOUT");
      this.$router.push("/login");
    }
  }
};
</script>

<style src="./../../assets/css/professor/MinhasDisciplinas.css" scoped=""></style>
