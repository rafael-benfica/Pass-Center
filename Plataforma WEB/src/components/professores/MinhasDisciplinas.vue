<template>
    <div>
        <div class="row tamanho">
            <div class="col s12 m3 l3" v-for="item in 6" :key="item.id">
                {{ item }}
                <div class="card">
                    <div class="card-image">        
                        <a class="btn-floating halfway-fab waves-effect waves-light blue darken-1"><i class="material-icons">history</i></a>
                    </div>
                    <div class="card-content">
                        <span class="card-title tituloCard">Interação Humano Computador</span>
                        <p class="turmaCard">Turma: 4º ADS</p>
                        <p class="horarioCard">19:00 - 20:40h</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: "MinhasDisciplinas",
    }
</script>

<style scoped>
    .tamanho{
        width: 90%;
    }
    .tituloCard{
        font-weight: 900 !important;
    }
    .turmaCard{
        font-weight: 400 !important;
    }
    .horarioCard{
        font-weight: 100 !important;
    }
    .card-content{
        text-align: center;
    }
</style>