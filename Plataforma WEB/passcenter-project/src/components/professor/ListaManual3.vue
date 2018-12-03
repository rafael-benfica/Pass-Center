<template>
    <div class="row area-exibicao">
        <form class="col s12 card data2">
            <div class="row topo">
                <div class="col s12 m12 l12">

                    <table>
                        <tbody>
                             <tr>
                                <td>Nome do Aluno</td>
                                <td><a class="btn botao green"><i class="material-icons">check</i></a></td>
                                <td><a class="btn botao red"><i class="material-icons">close</i></a></td>
                                <td><a class="botaofe waves-effect btn-flat">Desfazer</a></td>
                            </tr>
                            <tr>
                                <td>Nome do Aluno</td>
                                <td><a class="btn botao green"><i class="material-icons">check</i></a></td>
                                <td><a class="btn botao red"><i class="material-icons">close</i></a></td>
                                <td><a class="botaofe waves-effect btn-flat">Desfazer</a></td>
                            </tr>
                            <tr>
                                <td>Nome do Aluno</td>
                                <td><a class="btn botao green"><i class="material-icons">check</i></a></td>
                                <td><a class="btn botao red"><i class="material-icons">close</i></a></td>
                                <td><a class="botaofe waves-effect btn-flat">Desfazer</a></td>
                            </tr>
                            <tr>
                                <td>Nome do Aluno</td>
                                <td><a class="btn botao green"><i class="material-icons">check</i></a></td>
                                <td><a class="btn botao red"><i class="material-icons">close</i></a></td>
                                <td><a class="botaofe waves-effect btn-flat">Desfazer</a></td>
                            </tr>
                            <tr>
                                <td>Nome do Aluno</td>
                                <td><a class="btn botao green"><i class="material-icons">check</i></a></td>
                                <td><a class="btn botao red"><i class="material-icons">close</i></a></td>
                                <td><a class="botaofe waves-effect btn-flat">Desfazer</a></td>
                            </tr>
                            <tr>
                                <td>Nome do Aluno</td>
                                <td><a class="btn botao green"><i class="material-icons">check</i></a></td>
                                <td><a class="btn botao red"><i class="material-icons">close</i></a></td>
                                <td><a class="botaofe waves-effect btn-flat">Desfazer</a></td>
                            </tr>
                            
                            
                                                    
                        </tbody>
                    </table>
                        <div class="col s12 m12 l12 historico data">
                            <button class="waves-effect waves-light btn modal-trigger botaoSalvar" href="#modal1" type="submit" name="action">Salvar</button>               
                         <router-link :to="{ name: 'ListaManual2' }" class=" waves-effect">             
                             <button class="btn waves-effect waves-light" type="submit" name="action">Cancelar</button>
                         </router-link>
	
                        </div>
                        <div id="modal1" class="modal modalzao">
			                 <div class="modal-content">
                                  <h2 class="modalex">Você tem Certeza?</h2>
                             </div>
                    
		                    <div class="modal-footer row col s12 m12 l12 ">
					

						
						        <a href="#!" class="col s12 m5 l5 modal-close waves-effect waves-teal btn red">Cancelar</a>
					
						        <p class="col s12 m2 l2"></p>
					
						        <a href="#!" class="col s12 m5 l5 modal-close waves-effect waves-teal btn green">Confirmar</a>
						
					
					
			                </div>
                         </div>
            
	            </div>
            </div>
        </form>
    </div>
</template>

<script>
	export default {
		name: "ListaManual3",

		mounted: function () {
			$(document).ready(function () {
				$('.modal').modal();
			});
		},
		
	}

</script>

<style src="./../../assets/css/professor/MinhasDisciplinas.css" scoped></style>
   
