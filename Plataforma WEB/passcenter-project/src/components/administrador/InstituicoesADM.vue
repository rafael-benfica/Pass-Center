<template>
  <div class="row area-exibicao">
    <form class="col s12 card data2" onsubmit="return false">
      <div class="row topo">
        <div class="col s12 m12 l12">
          <h3 class="col s12 m12 l12 centro">Lista de Instituições</h3>

          <table>
            <thead class="centro">
              <tr>
                <th>Nome fantasia da Instituição</th>
                <th>C.N.PJ.</th>
                <th>I.E.</th>
                <th>Telefone</th>
                <th>Ação</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(item, index) in instituicoes" :key="item.id" @click="verDados(index)">
                <td>{{ item.ins_nome_fantasia}}</td>
                <td>{{ item.ins_cnpj }}</td>
                <td>{{ item.ins_inscricao_estadual }}</td>
                <td>{{ item.ins_telefone }}</td>
                <td v-if="item.ins_estado">
                  <a
                    class="waves-effect waves-light btn red"
                    @click="ativarDesativar(item.ins_codigo, false)"
                  >Desativar</a>
                </td>
                <td v-else>
                  <a
                    class="waves-effect waves-light btn green"
                    @click="ativarDesativar(item.ins_codigo, true)"
                  >Ativar</a>
                </td>
                <td>
                  <a class="waves-effect waves-light btn modal-trigger" href="#modalVer">ver</a>
                </td>
              </tr>
            </tbody>
          </table>

          <a
            class="col s12 m12 l12 centro waves-effect waves-light btn modal-trigger botaoVerMais"
            href="#modalAdd"
            @click="addDados()"
          >Adicionar instituição</a>

          <div id="modalVer" class="modal">
            <div class="modal-content">
              <h4 class="centro">Instituição</h4>
              <hr>

              <div class="row">
                <div class="col s12">
                  <div class="row">
                    <div class="input-field col s12 m12">
                      <input id="nomeFantasia" type="text" class="validate" v-model="nomeFantasia">
                      <label for="nomeFantasia">Nome Fantasia</label>
                    </div>
                  </div>

                  <div class="row">
                    <div class="input-field col s12 m12">
                      <input id="razaoSocial" type="text" class="validate" v-model="razaoSocial">
                      <label for="razaoSocial">Razão Social</label>
                    </div>
                  </div>
                </div>
              </div>

              <div class="row">
                <div class="input-field col s12 m4">
                  <input id="cnpj" type="text" class="validate" v-model="CNPJ">
                  <label for="cnpj">C.N.P.J.</label>
                </div>

                <div class="input-field col s12 m3">
                  <input id="ie" type="text" class="validate" v-model="IE">
                  <label for="ie">I.E.</label>
                </div>

                <div class="input-field col s12 m3">
                  <input id="telefone" type="text" class="validate" v-model="telefone">
                  <label for="telefone">Telefone</label>
                </div>

                <div class="input-field col s12 m2">
                  <input id="recorrencia" type="number" class="validate" v-model="recorrencia">
                  <label for="recorrencia">Recorrência</label>
                </div>
              </div>

              <div class="row">
                <div class="input-field col s12 m3">
                  <input id="bairro" type="text" class="validate" v-model="bairro">
                  <label for="bairro">Bairro</label>
                </div>

                <div class="input-field col s12 m5">
                  <input id="rua" type="text" class="validate" v-model="logradouro">
                  <label for="rua">Rua</label>
                </div>

                <div class="input-field col s12 m2">
                  <input id="numero" type="text" class="validate" v-model="numero">
                  <label for="numero">Número</label>
                </div>

                <div class="input-field col s12 m2">
                  <input id="cep" type="text" class="validate" v-model="CEP">
                  <label for="cep">CEP</label>
                </div>
              </div>

              <div class="row">
                <div class="input-field col s12 m5">
                  <input id="municipio" type="text" class="validate" v-model="municipio">
                  <label for="municipio">Município</label>
                </div>

                <div class="input-field col s12 m3">
                  <select v-model="estado">
                    <option value disabled>Selecione um estado</option>
                    <option value="AC">Acre</option>
                    <option value="AL">Alagoas</option>
                    <option value="AP">Amapá</option>
                    <option value="AM">Amazonas</option>
                    <option value="BA">Bahia</option>
                    <option value="CE">Ceará</option>
                    <option value="DF">Distrito Federal</option>
                    <option value="ES">Espírito Santo</option>
                    <option value="GO">Goiás</option>
                    <option value="MA">Maranhão</option>
                    <option value="MT">Mato Grosso</option>
                    <option value="MS">Mato Grosso do Sul</option>
                    <option value="MG">Minas Gerais</option>
                    <option value="PA">Pará</option>
                    <option value="PB">Paraíba</option>
                    <option value="PR">Paraná</option>
                    <option value="PE">Pernambuco</option>
                    <option value="PI">Piauí</option>
                    <option value="RJ">Rio de Janeiro</option>
                    <option value="RN">Rio Grande do Norte</option>
                    <option value="RS">Rio Grande do Sul</option>
                    <option value="RO">Rondônia</option>
                    <option value="RR">Roraima</option>
                    <option value="SC">Santa Catarina</option>
                    <option value="SP">São Paulo</option>
                    <option value="SE">Sergipe</option>
                    <option value="TO">Tocantins</option>
                  </select>
                  <label>Estado:</label>
                </div>

                <div class="input-field col s12 m4">
                  <input id="Complemento" type="text" class="validate" v-model="complemento">
                  <label for="Complemento">Complemento</label>
                </div>
              </div>

              <div class="modal-footer row col s12 m12 l12">
                <div class="col s12 m6 center-align">
                  <a class="modal-close waves-effect waves-teal btn red">Fechar</a>
                </div>
                <div class="col s12 m6 center-align">
                  <a class="waves-effect waves-teal btn green" @click="confirmacaoUpdate()">Salvar</a>
                </div>
              </div>
            </div>
          </div>

          <div id="modalAdd" class="modal">
            <div class="modal-content">
              <h4 class="centro">Cadastrar Instituição</h4>
              <hr>

              <div class="row">
                <div class="col s12">
                  <div class="row">
                    <div class="input-field col s12 m12">
                      <input
                        id="nomeFantasiaadd"
                        type="text"
                        class="validate"
                        v-model="nomeFantasia"
                      >
                      <label for="nomeFantasiaadd">Nome Fantasia</label>
                    </div>
                  </div>

                  <div class="row">
                    <div class="input-field col s12 m12">
                      <input id="razaoSocialadd" type="text" class="validate" v-model="razaoSocial">
                      <label for="razaoSocialadd">Razão Social</label>
                    </div>
                  </div>
                </div>
              </div>

              <div class="row">
                <div class="input-field col s12 m4">
                  <input id="cnpjadd" type="text" class="validate" v-model="CNPJ">
                  <label for="cnpjadd">C.N.P.J.</label>
                </div>

                <div class="input-field col s12 m3">
                  <input id="ieadd" type="text" class="validate" v-model="IE">
                  <label for="ieadd">I.E.</label>
                </div>

                <div class="input-field col s12 m3">
                  <input id="telefoneadd" type="text" class="validate" v-model="telefone">
                  <label for="telefoneadd">Telefone</label>
                </div>

                <div class="input-field col s12 m2">
                  <input id="recorrenciaadd" type="number" class="validate" v-model="recorrencia">
                  <label for="recorrenciaadd">Recorrência</label>
                </div>
              </div>

              <div class="row">
                <div class="input-field col s12 m3">
                  <input id="bairroadd" type="text" class="validate" v-model="bairro">
                  <label for="bairroadd">Bairro</label>
                </div>

                <div class="input-field col s12 m5">
                  <input id="ruaadd" type="text" class="validate" v-model="logradouro">
                  <label for="ruaadd">Rua</label>
                </div>

                <div class="input-field col s12 m2">
                  <input id="numeroadd" type="text" class="validate" v-model="numero">
                  <label for="numeroadd">Número</label>
                </div>

                <div class="input-field col s12 m2">
                  <input id="cepadd" type="text" class="validate" v-model="CEP">
                  <label for="cepadd">CEP</label>
                </div>
              </div>

              <div class="row">
                <div class="input-field col s12 m5">
                  <input id="municipioadd" type="text" class="validate" v-model="municipio">
                  <label for="municipioadd">Município</label>
                </div>

                <div class="input-field col s12 m3">
                  <select v-model="estado">
                    <option value disabled>Selecione um estado</option>
                    <option value="AC">Acre</option>
                    <option value="AL">Alagoas</option>
                    <option value="AP">Amapá</option>
                    <option value="AM">Amazonas</option>
                    <option value="BA">Bahia</option>
                    <option value="CE">Ceará</option>
                    <option value="DF">Distrito Federal</option>
                    <option value="ES">Espírito Santo</option>
                    <option value="GO">Goiás</option>
                    <option value="MA">Maranhão</option>
                    <option value="MT">Mato Grosso</option>
                    <option value="MS">Mato Grosso do Sul</option>
                    <option value="MG">Minas Gerais</option>
                    <option value="PA">Pará</option>
                    <option value="PB">Paraíba</option>
                    <option value="PR">Paraná</option>
                    <option value="PE">Pernambuco</option>
                    <option value="PI">Piauí</option>
                    <option value="RJ">Rio de Janeiro</option>
                    <option value="RN">Rio Grande do Norte</option>
                    <option value="RS">Rio Grande do Sul</option>
                    <option value="RO">Rondônia</option>
                    <option value="RR">Roraima</option>
                    <option value="SC">Santa Catarina</option>
                    <option value="SP">São Paulo</option>
                    <option value="SE">Sergipe</option>
                    <option value="TO">Tocantins</option>
                  </select>
                  <label>Estado:</label>
                </div>

                <div class="input-field col s12 m4">
                  <input id="Complemento" type="text" class="validate" v-model="complemento">
                  <label for="Complemento">Complemento</label>
                </div>
              </div>

              <div class="modal-footer row col s12 m12 l12">
                <a
                  href="#!"
                  class="col s12 m4 l4 modal-close waves-effect waves-teal btn red"
                >Cancelar</a>
                <p class="col s12 m4 l4"></p>
                <a
                  class="col s12 m4 l4 waves-effect waves-teal btn green"
                  @click="confirmacaoCriar()"
                >Confirmar</a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
export default {
  name: "instituicoes",
  data() {
    return {
      instituicoes: [],
      instituicao: "",
      endereco_codigo: "",
      nomeFantasia: "",
      razaoSocial: "",
      CNPJ: "",
      IE: "",
      telefone: "",
      recorrencia: "",
      logradouro: "",
      numero: "",
      bairro: "",
      CEP: "",
      municipio: "",
      estado: "",
      complemento: ""
    };
  },

  mounted() {
    $(document).ready(function() {
      $(".modal").modal();
      M.updateTextFields();
      $("select").formSelect();
    });

    this.carregarDados();
  },
  methods: {
    ativarDesativar(ins, tipo) {
      const swalWithBootstrapButtons = swal.mixin({
        confirmButtonClass: "btn green sepraracaoBotoes",
        cancelButtonClass: "btn red sepraracaoBotoes",
        buttonsStyling: false
      });

      swalWithBootstrapButtons({
        title: "Você tem certeza?",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Sim, faça!",
        cancelButtonText: "Não, cancele!",
        reverseButtons: true
      }).then(result => {
        if (result.value) {
          var dodosInstituicao = {
            ins_codigo: ins,
            ins_estado: false
          };

          if (tipo) {
            dodosInstituicao = {
              ins_codigo: ins,
              ins_estado: true
            };
          }

          this.$http.put("Instituicoes/ativarDesativar", dodosInstituicao).then(
            response => {
              this.carregarDados();
              swalWithBootstrapButtons(
                "Alterado!",
                "As alterações foram salvas.",
                "success"
              );
            },
            response => {
              this.erro("Ativar ou Desativar uma instituição", response.status);
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

    carregarDados() {
      this.$http.get("Instituicoes/Endereco").then(
        response => {
          this.instituicoes = response.body;
        },
        response => {
          this.erro("Dados do Usuário", response.status);
        }
      );
    },

    verDados(index) {
      var dados = this.instituicoes[index];

      this.instituicao = dados.ins_codigo;
      this.nomeFantasia = dados.ins_nome_fantasia;
      this.razaoSocial = dados.ins_razao_social;
      this.CNPJ = dados.ins_cnpj;
      this.IE = dados.ins_inscricao_estadual;
      this.telefone = dados.ins_telefone;
      this.recorrencia = dados.ins_periodo_renovacao_dias;
      this.logradouro = dados.end_logradouro;
      this.numero = dados.end_numero;
      this.bairro = dados.end_bairro;
      this.CEP = dados.end_cep;
      this.municipio = dados.end_municipio;
      this.estado = dados.end_estado;
      this.complemento = dados.end_complemento;

      $(document).ready(function() {
        M.updateTextFields();
        $("select").formSelect();
      });
    },

    addDados() {
      this.instituicao = "";
      this.nomeFantasia = "";
      this.razaoSocial = "";
      this.CNPJ = "";
      this.IE = "";
      this.telefone = "";
      this.recorrencia = "";
      this.logradouro = "";
      this.numero = "";
      this.bairro = "";
      this.CEP = "";
      this.municipio = "";
      this.estado = "";
      this.complemento = "";

      $(document).ready(function() {
        M.updateTextFields();
        $("select").formSelect();
      });
    },

    confirmacaoUpdate() {
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
          const dodosInstituicao = {
            ins_codigo: this.instituicao,
            ins_nome_fantasia: this.nomeFantasia,
            ins_razao_social: this.razaoSocial,
            ins_cnpj: this.CNPJ,
            ins_inscricao_estadual: this.IE,
            ins_telefone: this.telefone,
            ins_periodo_renovacao_dias: this.recorrencia
          };

          var dodosEndereco = {
            end_codigo: this.endereco_codigo,
            end_logradouro: this.logradouro,
            end_numero: this.numero,
            end_bairro: this.bairro,
            end_municipio: this.municipio,
            end_cep: this.CEP,
            end_estado: this.estado,
            end_complemento: this.complemento
          };

          this.$http.put("Instituicoes", dodosInstituicao).then(
            response => {
              this.$http.put("Enderecos", dodosEndereco).then(
                response => {
                  this.carregarDados();
                  swalWithBootstrapButtons(
                    "Alterado!",
                    "As alterações foram salvas.",
                    "success"
                  );
                },
                response => {
                  this.erro("Endereço", response.status);
                }
              );
            },
            response => {
              this.erro("Dados da instituição", response.status);
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
          var dodosEndereco = {
            end_codigo: this.endereco_codigo,
            end_logradouro: this.logradouro,
            end_numero: this.numero,
            end_bairro: this.bairro,
            end_municipio: this.municipio,
            end_cep: this.CEP,
            end_estado: this.estado,
            end_complemento: this.complemento,
            end_pais: "BR"
          };

          this.$http.post("Enderecos", dodosEndereco).then(
            response => {
              const dodosInstituicao = {
                ins_nome_fantasia: this.nomeFantasia,
                ins_razao_social: this.razaoSocial,
                ins_cnpj: this.CNPJ,
                ins_inscricao_estadual: this.IE,
                ins_telefone: this.telefone,
                ins_periodo_renovacao_dias: this.recorrencia,
                end_codigo: {
                  end_codigo: response.body
                }
              };

              this.$http.post("Instituicoes", dodosInstituicao).then(
                response => {
                  this.carregarDados();
                  swalWithBootstrapButtons(
                    "Salvo!",
                    "Todas as informações foram salvas.",
                    "success"
                  );
                },
                response => {
                  this.erro("Dados da instituição", response.status);
                }
              );
            },
            response => {
              this.erro("Endereço", response.status);
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
  }
};
</script>

<style src="./../../assets/css/gerenteGeral/Financeiro.css" scoped></style>
<style src="./../../assets/css/gerenteGeral/tables.css" scoped></style>
   
