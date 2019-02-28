<template>
    <div>
        <div class="row area-exibicao">
            <div class="col s12 m3 l3 espacamento" v-for="item in 7" :key="item.id">
                <!-- {{ item }} -->
                <div class="card">
                    <div class="card-content">
                        <span class="card-title cardDisciplina">Interação Humano Computador</span>
                        <p class="cardTurmaCarga">4º ADS - 40h</p>
                        <p class="cardFaltasPresencas">23 presenças em 25 aulas</p>
                        <a class="waves-effect waves-light btn modal-trigger botaoVerMais" href="#modal1">Ver mais</a>
                    </div>
                </div>
            </div>
        </div>
        <!-- Modal Structure -->
        <div id="modal1" class="modal bottom-sheet">
            <div class="modal-content">
                <h4 class="col s10 m12 l12 historico">Histórico de Faltas</h4>
                <p>Esses são os dias que você faltou:</p>
                <div class="row">
                    <div class="col s4 m1 l1" v-for="item in 24" :key="item.id">
                        <div class="waves-effect waves-teal btn-large botaoDatas">22/11</div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <a href="#!" class="modal-close waves-effect waves-green btn-flat">Fechar</a>
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
