<template>
    <div>
        <div class="row area-exibicao">
            <div class="col s12 m4 l4 espacamento" v-for="item in 6" :key="item.id">
            <div class="modal-trigger" href="#modal">
                <div class="card">
                    <div class="card-content">
                        <h2 class="card-title cardDisciplina">Engenharia de Softwares {{ item }}</h2>
                        <h3 class="card-title cardDisciplina">Professor:</h3>
                         <p class="cardTurmaCarga">Claudemir</p><br />
                    </div>
                </div>
            </div>
            </div>
            <div id="modal" class="modal margem">
			<div class="modal-content">
				<h3 class="centro">Engenharia de Softwares</h3>
                <h4>Professor Claudemir</h4>

				
					</div>
	
		            	<div class="modal-footer row col s12 m12 l12 ">
					
                            <p class="col s12 m4 l4"></p>
						
						    <a href="#!" class="col s12 m4 l4 modal-close waves-effect waves-teal btn">Fechar</a>
					
					    	<p class="col s12 m4 l4"></p>
						
					
					
			            </div>
		    </div>
                </div>
        </div>
			
    
</template>

<script>
	export default {
		name: "TurmasGeral",

		mounted: function () {
			$(document).ready(function () {
				$('.modal').modal();
			});
		},
		
	}

</script>


<style src="./../../assets/css/aluno/MinhasDisciplinasAluno.css" scoped></style>
