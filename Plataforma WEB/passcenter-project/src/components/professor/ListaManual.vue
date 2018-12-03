<template>
    <div>
        <div class="row area-exibicao">
            <div class="col s12 m4 l4 espacamento" v-for="item in 3" :key="item.id">
                <!-- {{ item }} -->
                <div class="card">
                    <div class="card-content">
                       <router-link :to="{ name: 'ListaManual2' }" class=" waves-effect"> <a class="waves-effect waves-light">

                             <span class="card-title cardDisciplina">Interação Humano Computador</span>
                        </a>
                        </router-link>
                        
                    </div>
                </div>
            </div>
        </div>
        <!-- Modal Structure -->
        
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
