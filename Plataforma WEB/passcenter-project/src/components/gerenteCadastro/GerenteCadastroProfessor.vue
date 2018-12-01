<template>
    <div>
        <div class="row area-exibicao">
            <div class="col s12 m3 l3 espacamento" v-for="item in 8" :key="item.id">
            
                <div class="card">
                    <div class="card-content">
                       <router-link :to="{ name: 'GerenteCadastroTurma' }" class=" waves-effect"><span class="card-title cardDisciplina">Análise e Desenvolvimento de Sistemas</span></router-link>
                       
                    </div>
                </div>
            </div>
        </div>
    </div> 
</template>

<script>
    export default {
        name: "MinhasDisciplinasAluno",

        mounted: function () {
            $(document).ready(function(){
                $('.modal').modal();
            });
        },
    }
</script>

<style src="./../../assets/css/aluno/MinhasDisciplinasAluno.css" scoped></style>


