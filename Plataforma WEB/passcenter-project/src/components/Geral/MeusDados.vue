<template>
    <div class="row area-exibicao">
        <form class="col s12 card">
            <div class="row topo">
                <span class="card-title">Meus Dados</span>
            </div>
            <div class="row">
                <div class="input-field col s12 m6">
                    <input id="nome" type="text" class="validate" v-model="nome">
                    <label for="nome">Nome</label>
                </div>
                <div class="input-field col s12 m6">
                    <input id="sobrenome" type="text" class="validate" v-model="sobrenome">
                    <label for="sobrenome">Sobrenome</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12 m4">
                    <input id="cpf" type="text" class="validate" v-model="CPF">
                    <label for="cpf">CPF</label>
                </div>
                <div class="input-field col s12 m4">
                    <input id="rg" type="text" class="validate" v-model="RG">
                    <label for="rg">RG</label>
                </div>
                <div class="input-field col s12 m4">
                    <select v-model="sexo">
                        <option value="1">Masculino</option>
                        <option value="2">Feminino</option>
                        <option value="3">Outros</option>
                    </select>
                    <label>Sexo:</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12 m4">
                    <input id="rua" type="text" class="validate" v-model="rua">
                    <label for="rua">Rua</label>
                </div>
                <div class="input-field col s12 m4">
                    <input id="numero" type="text" class="validate" v-model="numero">
                    <label for="numero">Número</label>
                </div>
                <div class="input-field col s12 m4">
                    <input id="bairro" type="text" class="validate"  v-model="bairro">
                    <label for="bairro">Bairro</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12 m4">
                    <input id="cep" type="text" class="validate" v-model="CEP">
                    <label for="cep">CEP</label>
                </div>
                <div class="input-field col s12 m6">
                    <input id="municipio" type="text" class="validate" v-model="municipio">
                    <label for="municipio">Município</label>
                </div>
                <div class="input-field col s12 m2">
                    <select v-model="estado">
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
            </div>
            <div class="row">
                <div class="input-field col s12 m6">
                    <input id="email" type="email" class="validate" v-model="email">
                    <label for="email">Email</label>
                </div>
                <div class="input-field col s12 m6">
                    <input id="password" type="password" class="validate" v-model="senha">
                    <label for="password">Senha</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12 m6">
                    <input id="tel_residencial" type="text" class="validate" v-model="tel_residencial">
                    <label for="tel_residencial">Telefone Residencial:</label>
                </div>
                <div class="input-field col s12 m6">
                    <input id="tel_celular" type="text" class="validate" v-model="tel_celular">
                    <label for="tel_celular">Telefone Celular:</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12 m12">
                    <textarea id="infoadd" class="materialize-textarea" v-model="infoadd"></textarea>
                     <label for="infoadd">Informações Adicionais</label>
                </div>
            </div>
            <div class="row">
                <div class="col s12">
                     <a class="waves-effect waves-teal btn" @click="confirmação()">Alterar Dados</a>
                </div>
            </div>
        </form>
    </div>
</template>

<script>
    export default {
        nome: 'MeusDados',
        data() {
            return {         
                nome : "",           
                sobrenome : "",
                CPF : "",
                RG : "",
                sexo : "",
                rua : "",
                numero : "",
                bairro : "",
                CEP : "",
                municipio : "",
                estado : "",
                email : "",
                senha : "",
                tel_residencial: "",
                tel_celular : "",
                infoadd : "",
            }
        },

        mounted (){
            this.$http.get('Pessoas').then(response => {
                var dados = response.body[0];

                this.nome = dados.pes_nome;
                this.sobrenome = dados.pes_sobrenomes;
                this.CPF = dados.pes_cpf;
                this.RG = dados.pes_rg;
                this.sexo = dados.pes_sexo;
                this.rua = dados.end_logradouro;
                this.numero = dados.end_numero;
                this.bairro = dados.end_bairro;
                this.CEP = dados.end_cep;
                this.municipio = dados.end_municipio;
                this.estado = dados.end_estado;
                this.email = dados.usu_login;
                this.senha = dados.usu_senha;
                this.tel_residencial = dados.pes_tel_residencial;
                this.tel_celular = dados.pes_tel_celular;
                this.infoadd = dados.pes_info_adicionais;

                $(document).ready(function() {
                    M.updateTextFields();
                    $('select').formSelect();
                }) 
            }, response => {
                console.log("ERRO! Código de resposta (HTTP) do servidor: " + response.status);
            });
        },


        methods: {
            confirmação() {
                const swalWithBootstrapButtons = swal.mixin({
                confirmButtonClass: 'btn green sepraracaoBotoes',
                cancelButtonClass: 'btn red sepraracaoBotoes',
                buttonsStyling: false,
                })

                swalWithBootstrapButtons({
                title: 'Você tem certeza?',
                text: "Você não poderá reverter essa ação!",
                type: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Sim, faça!',
                cancelButtonText: 'Não, cancele!',
                reverseButtons: true
                }).then((result) => {
                if (result.value) {
                    swalWithBootstrapButtons(
                    'Alterado!',
                    'As alterações foram salvas.',
                    'success'
                    )
                } else if (
                    // Read more about handling dismissals
                    result.dismiss === swal.DismissReason.cancel
                ) {
                    swalWithBootstrapButtons(
                    'Cancelado!',
                    'Alterações descartadas!',
                    'error'
                    )
                }
                })
            }
        },
    }
    
</script>

<style src="./../../assets/css/geral/MeusDados.css" scoped></style>