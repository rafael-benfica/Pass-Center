<template>
    <div>
        <form onsubmit="return false">
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
                <div class="chips chips-autocomplete"></div>

				
					</div>
	
		            	<div class="modal-footer row col s12 m12 l12 ">
						    <a href="#!" class="col s12 m4 l4 modal-close waves-effect waves-teal btn red">Cancelar</a>
					
						    <p class="col s12 m4 l4"></p>
					
						    <a href="#!" class="col s12 m4 l4 modal-close waves-effect waves-teal btn green" @click="confirmação()">Confirmar</a>
		            	</div>
		            </div>
                </div>
                </form>
        </div>
			
    
</template>

<script>
	export default {
		name: "TurmasGeral",

		mounted: function () {
			$(document).ready(function () {
                $('.modal').modal();
                 $('.chips').chips();
 
  
                $('.chips-autocomplete').chips({
                autocompleteOptions: {
                data: {
                    'Apple': null,
                    'Microsoft': null,
                    'Google': null
                         },
                        limit: Infinity,
                        minLength: 1
                    }
                });
			});
        },
        methods: {
        confirmação() {
            const swalWithBootstrapButtons = swal.mixin({
                confirmButtonClass: 'btn green sepraracaoBotoes',
                cancelButtonClass: 'btn red sepraracaoBotoes',
                buttonsStyling: false,
            })

            swalWithBootstrapButtons({
                title: 'Você tem certeza?',
                type: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Sim, faça!',
                cancelButtonText: 'Não, cancele!',
                reverseButtons: true
            }).then((result) => {
                if (result.value) {
                    swalWithBootstrapButtons(
                        'Alterado!',
                        'As alterações foram salvas.',
                        'success'
                    )
                } else if (
                    // Read more about handling dismissals
                    result.dismiss === swal.DismissReason.cancel
                ) {
                    swalWithBootstrapButtons(
                        'Cancelado!',
                        'Alterações descartadas!',
                        'error'
                    )
                }
            })
        }
    }
        
		
	}

</script>


<style src="./../../assets/css/aluno/MinhasDisciplinasAluno.css" scoped></style>
