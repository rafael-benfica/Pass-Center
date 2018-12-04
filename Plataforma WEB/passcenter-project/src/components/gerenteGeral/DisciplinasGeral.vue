<template>
    <div>
        <div class="row area-exibicao">
            <div class="col s12 m4 l4 espacamento" v-for="item in 6" :key="item.id">
                <div class="card">
                    <div class="card-content">
                        <h2 class="card-title cardDisciplina">Engenharia de Softwares {{ item }}</h2>
                    </div>
                </div>
            </div>
        </div>
        
    </div>
</template>



<style src="./../../assets/css/aluno/MinhasDisciplinasAluno.css" scoped></style>
