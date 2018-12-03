<template>
    <div class="fonte">
        <div class="row area-exibicao">
            <div class="col s12 m3 l3 espacamento" v-for="item in 7" :key="item.id">
                <!-- {{ item }} -->
                <div class="card">
                    <div class="card-image">        
                        <a class="btn-floating halfway-fab waves-effect waves-light blue darken-1 btn modal-trigger botao" href="#modal1"><i class="material-icons">history</i></a>
                    </div>
                    <div class="card-content">
                        <span class="card-title tituloCard">Interação Humano Computador</span>
                        <p class="turmaCard">Turma: 4º ADS</p>
                        <p class="horarioCard">19:00 - 20:40h</p>
                    </div>
                </div>
            </div>
        </div>
            <div id="modal1" class="modal bottom-sheet">
                <div class="modal-content">
                
                    
                    <h4 class="col s10 m12 l12">Histórico</h4>
                    
              
                        <div class="row">
                            <div class="col s4 m1 l1" v-for="item in 12" :key="item.id">
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
        name: "MinhasDisciplinas",
         mounted: function () {
            $(document).ready(function(){
                $('.modal').modal();
            });
        },
    }
</script>

<style src="./../../assets/css/professor/MinhasDisciplinas.css" scoped></style>
