<template>
    <div class="row area-exibicao">
        <form class="col s12 card">
            <div class="row topo">
                <span class="card-title">Meus Dados</span>
            </div>
            <div class="row">
                <div class="input-field col s6">
                    <input id="nome" type="text" class="validate">
                    <label for="nome">Nome</label>
                </div>
                <div class="input-field col s6">
                    <input id="sobrenome" type="text" class="validate">
                    <label for="sobrenome">Sobrenome</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s4">
                    <input id="cpf" type="text" class="validate">
                    <label for="cpf">CPF</label>
                </div>
                <div class="input-field col s4">
                    <input id="rg" type="text" class="validate">
                    <label for="rg">RG</label>
                </div>
                <div class="input-field col s4">
                    <select>
                        <option value="1">Masculino</option>
                        <option value="2">Feminino</option>
                        <option value="3">Outros</option>
                    </select>
                    <label>Sexo:</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s4">
                    <input id="rua" type="text" class="validate">
                    <label for="rua">Rua</label>
                </div>
                <div class="input-field col s4">
                    <input id="numero" type="text" class="validate">
                    <label for="numero">Número</label>
                </div>
                <div class="input-field col s4">
                    <input id="bairro" type="text" class="validate">
                    <label for="bairro">Bairro</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s4">
                    <input id="cep" type="text" class="validate">
                    <label for="cep">CEP</label>
                </div>
                <div class="input-field col s6">
                    <input id="municipio" type="text" class="validate">
                    <label for="municipio">Município</label>
                </div>
                <div class="input-field col s2">
                    <input id="estado" type="text" class="validate">
                    <label for="estado">Estado</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s6">
                    <input id="email" type="email" class="validate">
                    <label for="email">Email</label>
                </div>
                <div class="input-field col s6">
                    <input id="password" type="password" class="validate">
                    <label for="password">Senha</label>
                </div>
            </div>
            <div class="row">
                <div class="col s12">
                     <a class="waves-effect waves-teal btn">Alterar Dados</a>
                </div>
            </div>
        </form>
    </div>
</template>

<script>
    export default {
        nome:"MeusDados"
    }
    
  $(document).ready(function() {
    M.updateTextFields();
    $('select').formSelect();
  });

</script>

<style src="./../../assets/css/geral/MeusDados.css" scoped></style>