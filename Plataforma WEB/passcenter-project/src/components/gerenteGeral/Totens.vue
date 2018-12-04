<template>
    <div>
        <div class="row area-exibicao">
            <div class="col s12 m3 l3 espacamento" v-for="item in 4" :key="item.id">
                
                <div class="card">
                    <div class="card-content">
                        <span class="card-title cardDisciplina">Sala - 0{{ item }}</span>
                        <p class="card-title cardDisciplina">Totem - 0{{ item }}</p>
                        <p class="card-title cardDisciplina">Ativo</p>
                        
                    </div>
                </div>
                <div class="card">
                    <div class="card-content">
                        <span class="card-title cardDisciplina">Sala - 0{{ item+4 }}</span>
                        <p class="card-title cardDisciplina">Totem - 0{{ item+4 }}</p>
                        <p class="card-title cardDisciplina">Inativo</p>
                        
                    </div>
                </div>
                <div class="card">
                    <div class="card-content">
                        <span class="card-title cardDisciplina">Sala - 0{{ item+8 }}</span>
                        <p class="card-title cardDisciplina">Totem - 0{{ item+8 }}</p>
                        <p class="card-title cardDisciplina">Erro</p>
                        
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
