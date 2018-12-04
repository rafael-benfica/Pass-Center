<template>
    <div class="row area-exibicao">
        <form class="col s12 card data2" onsubmit="return false">
            <div class="row topo">
                <div class="col s12 m12 l12">
                    
                    <h3 class="col s12 m12 l12 centro">Lista de Alunos</h3>
                    
                    <table>
                        <thead class="centro">
                                 <tr>
                                    <th>Nome do Aluno</th>
                                    <th>Telefone do Aluno</th>
                                    <th>Histórico do Aluno</th>
                                    <th>Endereço do Aluno</th>
                                 </tr>
                        </thead>
                        <tbody>
                                 <tr>
                                    <td>Asdf</td>
                                    <td>(12)9999-9999</td>
                                    <td><a>Histórico</a></td>
                                    <td>Rua Imaginaria</td>
                                 </tr> 
                                 <tr>
                                    <td>Asdf</td>
                                    <td>(12)9999-9999</td>
                                    <td><a>Histórico</a></td>
                                    <td>Rua Imaginaria</td>
                                </tr>
                                 <tr>
                                    <td>Asdf</td>
                                    <td>(12)9999-9999</td>
                                    <td><a>Histórico</a></td>
                                    <td>Rua Imaginaria</td>
                                 </tr>
                                 <tr>
                                    <td>Asdf</td>
                                    <td>(12)9999-9999</td>
                                    <td><a>Histórico</a></td>
                                    <td>Rua Imaginaria</td>
                                 </tr>
                                 <tr>
                                    <td>Asdf</td>
                                    <td>(12)9999-9999</td>
                                    <td><a >Histórico</a></td>
                                    <td>Rua Imaginaria</td>
                                 </tr> 
                        </tbody>
                    </table>
                
                        <a class="col s12 m12 l12 centro waves-effect waves-light btn modal-trigger botaoVerMais" href="#modal2">Adicionar Aluno</a>

                        <div id="modal2" class="modal">
			<div class="modal-content">
				<h4 class="centro">Cadastro Aluno</h4>
				<hr>
					<div class="row col s12 m12 l12">
       					 <div class="input-field col s12 m4 l4">
          						<input id="matricula" type="text" class="validate">
          						<label for="matricula">Matrícula:</label>
        				</div>

						<div class="input-field col s12 m4 l4">
          						<input id="nome" type="text" class="validate">
          						<label for="nome">Nome:</label>
        				</div>

						<div class="input-field col s12 m4 l4">
          						<input id="sobrenome" type="text" class="validate">
          						<label for="sobrenome">Sobrenome:</label>
        				</div>

						<div class="input-field col s12 m4 l4">
          						<input id="datanas" type="text" class="validate">
          						<label for="datanas">Data de Nascimento:</label>
        				</div>

						<div class="input-field col s12 m4 l4">
          						<input id="cpf" type="text" class="validate">
          						<label for="cpf">CPF:</label>
        				</div>

						<div class="input-field col s12 m4 l4">
          						<input id="rg" type="text" class="validate">
          						<label for="rg">RG:</label>
        				</div>

						<div class="input-field col s12 m4 l4">
          						<input id="rua" type="text" class="validate">
          						<label for="rua">Rua:</label>
        				</div>

						<div class="input-field col s12 m4 l4">
          						<input id="num" type="text" class="validate">
          						<label for="num">Número:</label>
        				</div>

						<div class="input-field col s12 m4 l4">
          						<input id="bairro" type="text" class="validate">
          						<label for="bairrio">Bairro:</label>
        				</div>

						<div class="input-field col s12 m3 l3">
          						<input id="estado" type="text" class="validate">
          						<label for="estado">Estado:</label>
        				</div>

						<div class="input-field col s12 m3 l3">
          						<input id="cidade" type="text" class="validate">
          						<label for="cidade">Cidade:</label>
        				</div>

						<div class="input-field col s12 m3 l3">
          						<input id="cep" type="text" class="validate">
          						<label for="cep">CEP:</label>
        				</div>

						<div class="input-field col s12 m3 l3">
          						<input id="comple" type="text" class="validate">
          						<label for="comple">Complemento:</label>
        				</div>

							
								
        							<div class="input-field col s12 m12 l12">
          								<textarea id="textarea1" class="materialize-textarea"></textarea>
          									<label for="textarea1">Informações Adicionais:</label>
        							</div>
      							


						

					</div>
	
		            	<div class="modal-footer row col s12 m12 l12 ">
					

						
						    <a href="#!" class="col s12 m4 l4 modal-close waves-effect waves-teal btn red">Cancelar</a>
					
					    	<p class="col s12 m4 l4"></p>
					
					    	<a href="#!" class="col s12 m4 l4 modal-close waves-effect waves-teal btn green">Confirmar</a>
						
					
					
			            </div>
		        	</div>
                </div>
                        
            
	            </div>
            </div>
        </form>
    </div>
</template>

<script>
	export default {
		name: "AlunoGeral",

		mounted: function () {
			$(document).ready(function () {
				$('.modal').modal();
			});
		},
		
	}

</script>

<style src="./../../assets/css/professor/MinhasDisciplinas.css" scoped></style>
<style src="./../../assets/css/gerenteGeral/tables.css" scoped></style>
   
