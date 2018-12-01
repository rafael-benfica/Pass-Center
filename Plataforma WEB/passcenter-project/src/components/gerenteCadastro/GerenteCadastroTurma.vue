<template>
    <div>
        <div class="row area-exibicao">
            <div class="col s12 m3 l3 espacamento" v-for="item in 3" :key="item.id">
                
                <div class="card">
                    <div class="card-content">
                     <router-link :to="{ name: 'GerenteCadastroMateria' }" class=" waves-effect"><span class="card-title cardDisciplina">4º ADS</span></router-link>
                     
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


