<template>
  <div class="row area-exibicao">
    <form class="col s12 card data2" onsubmit="return false">
      <div class="row topo">
        <div class="col s12 m12 l12">
          <h3 class="col s12 m12 l12 centro">Financeiro</h3>

          <table>
            <thead class="centro">
              <tr>
                
                <th>Qtd. Tags</th>
                <th>Qtd. Totens</th>
                <th>Valor por TAG</th>
                <th>Valor por Totem</th>
                <th>Valor total</th>
                <th>Data da Cobrança</th>
                <th>Data do Vencimento</th>
                <th>Data do Pagamento</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="item in financeiro" :key="item.id">
                
                <td>{{ item.pla_qtd_tags }}</td>
                <td>{{ item.pla_qtd_totens }}</td>
                <td>{{ "R$ "+item.pla_preco_tags }}</td>
                <td>{{ "R$ "+item.pla_preco_totens }}</td>
                <td>{{ "R$ "+((item.pla_qtd_tags * item.pla_preco_tags) + (item.pla_qtd_totens * item.pla_preco_totens)) }}</td>
                <td>{{ recebeData(item.pag_data_criacao) }}</td>
                <td>{{ recebeData(item.pag_data_vencimento) }}</td>
                <td v-if="item.pag_data_pagamento != null">{{ recebeData(item.pag_data_pagamento) }}</td>
                <td v-else>Em aberto</td>
              </tr>
            </tbody>
          </table>
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
      financeiro: []
    };
  },

  mounted() {
    this.carregarDados();
  },
  methods: {
    recebeData(data) {
      var array = data
        .replace("T00:00:00", "")
        .split("-")
        .reverse();
      return array[0] + "/" + array[1] + "/" + array[2];
    },

    carregarDados() {
      this.$http.get("Pagamentos").then(
        response => {
          this.financeiro = response.body;
        },
        response => {
          this.erro("Pagamentos", response.status);
        }
      );
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
   
