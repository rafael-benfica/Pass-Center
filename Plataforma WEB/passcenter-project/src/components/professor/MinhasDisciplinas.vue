<template>
    <div>
        <div class="row area-exibicao">
            <div class="col s12 m3 l3 espacamento" v-for="item in 7" :key="item.id">
                <!-- {{ item }} -->
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

<style src="./../../assets/css/professor/MinhasDisciplinas.css" scoped></style>
