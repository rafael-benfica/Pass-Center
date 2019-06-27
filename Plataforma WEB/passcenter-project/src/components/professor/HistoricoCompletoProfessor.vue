<template>
  <div>
    <div class="row area-exibicao" v-show="!clicou">
      <div class="col offset-m3 m5 s12 card ajuste espacamento">
        <div class="row">
          <div class="col offset-m1 m10 s12">
            <div class="row">
            <h3 class="col s11 m11 l11 center">Qual Período você deseja buscar?</h3>
            <div class="helpButton col s1 right-align">
              <a onclick="M.toast({html: 'Aqui é onde se seleciona o periodo para seu historico completo.'})" class="btn-floating">
                <i class="icone material-icons">help_outline</i>
                </a>
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
          <div class="card">
            <div
              class="card-content modal-trigger"
              href="#modalSessoes"
              @click="carregarSessoes(itemDisciplinas.eau_codigo); nomeHistorico = itemDisciplinas.eve_nome+' - '+ itemDisciplinas.eau_periodo_identificacao ;"
            >
              <span class="card-title tituloCard">{{ itemDisciplinas.eve_nome }}</span>
              <p
                class="turmaCard"
              >{{ itemDisciplinas.eve_sigla +" | "+ itemDisciplinas.eau_periodo_identificacao}}</p>
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

    <!-- Modal Sessões -->
    <div id="modalSessoes" class="modal bottom-sheet modal-fixed-footer">
      <div class="modal-content">
        <div class="row">
          <div class="col s12">
            <h4 class="historico">Histórico de Aulas</h4>
          </div>
        </div>

        <div class="row">
          <div class="col s12">
            <p>Esses são os dias registrados:</p>
          </div>
        </div>

        <div class="row center-align">
          <div class="col s12 m2 espacamento" v-for="item in sessoes" :key="item.id">
            <a
              class="waves-effect waves-light btn-large modal-trigger"
              href="#modalLista"
              @click="carregarlista(item); dataHistorico = sessaoHistoricoObj.ses_horario_inicio;"
            >{{ recebeData(item.ses_horario_inicio) }}</a>
          </div>
        </div>
      </div>

      <div class="modal-footer">
        <a href="#!" class="modal-close waves-effect waves-green btn-flat">Fechar</a>
      </div>
    </div>

    <!-- Modal Historico -->
    <div id="modalLista" class="modal modal-fixed-footer">
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
              </tr>
            </thead>
            <tbody>
              <tr v-for="item in lista" :key="item.id">
                <td>{{ item.nomes_concatenados }}</td>
                <td>{{ item.pes_matricula }}</td>
                <td v-if="item.ses_codigo != null">{{ item.pre_horario_entrada.substr(11,5) }}</td>
                <td v-else>Aluno Ausente</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
      <div class="modal-footer">
        <a href="#!" class="modal-close waves-effect waves-green btn-flat">Fechar</a>
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
  name: "HistoricoCompletoProfessor",
  data() {
    return {
      periodos: {},
      disciplinas: [],
      sessoes: [],
      lista: [],
      sessaoHistoricoObj: [],
      nomeHistorico: "",
      dataHistorico: "",
      clicou: false,
      existeSessoes: false
    };
  },
  mounted: function() {
    $(document).ready(function() {
      $(".modal").modal();
      $(".dropdown-trigger1").dropdown();
      $(".dropdown-trigger2").dropdown();
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
    carregarRelatorio(eau) {
      var modal = document.querySelector("#modalRelatorio");
      var instance = M.Modal.init(modal, {
        dismissible: false
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
    recebeData(data) {
      var horaEdata = data.split("T");

      var data = horaEdata[0].split("-").reverse();

      return data[0] + "/" + data[1] + "/" + data[2] + " - " + horaEdata[1];
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
    }
  }
};
</script>
<style src="./../../assets/css/professor/HistoricoCompletoProfessor.css" scoped></style>