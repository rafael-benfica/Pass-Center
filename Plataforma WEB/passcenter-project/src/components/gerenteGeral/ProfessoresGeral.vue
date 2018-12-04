<template>
    <div class="row area-exibicao">
        <form class="col s12 card data2" onsubmit="return false">
            <div class="row topo">
                <div class="col s12 m12 l12">
                    
                    <h3 class="col s12 m12 l12 centro">Lista de Professores</h3>
                    
                    <table>
                        <thead class="centro">
                                 <tr>
                                    <th>Nome do Professor</th>
                                    <th>Matrícula do Professor</th>
                                    <th>Telefone Residencial do Professor</th>
                                    <th>Telefone Celular do Professor</th>
                                    <th></th>
                                 </tr>
                        </thead>
                        <tbody>
                            <tr v-for="(item, index) in professores" :key="item.id" @click="teste(index)">
                                <td>{{ item.pes_nome +" "+ item.pes_sobrenomes }}</td>
                                <td>{{ item.pes_matricula }}</td>
                                <td>{{ item.pes_tel_residencial  }}</td>
                                <td>{{ item.pes_tel_celular }}</td>
                                <td><a class="waves-effect waves-light btn modal-trigger" href="#modal2">ver</a></td>
                            </tr> 
                        </tbody>
                    </table>
                
                        <a class="col s12 m12 l12 centro waves-effect waves-light btn modal-trigger botaoVerMais" href="#modal2">Adicionar Professores</a>

                        <div id="modal2" class="modal">
			<div class="modal-content">
				<h4 class="centro">Cadastro Professor</h4>
				<hr>
					<div class="row col s12 m12 l12">
       					 <div class="input-field col s12 m4 l4">
          						<input id="matricula" type="text" class="validate" v-model="matricula">
          						<label for="matricula">Matrícula:</label>
        				</div>

						<div class="input-field col s12 m4 l4">
          						<input id="nome" type="text" class="validate" v-model="nome">
          						<label for="nome">Nome:</label>
        				</div>

						<div class="input-field col s12 m4 l4">
          						<input id="sobrenome" type="text" class="validate" v-model="sobrenomes">
          						<label for="sobrenome">Sobrenome:</label>
        				</div>

						<div class="input-field col s12 m4 l4">
          						<input id="datanas" type="text" class="validate" v-model="datanas">
          						<label for="datanas">Data de Nascimento:</label>
        				</div>

						<div class="input-field col s12 m4 l4">
          						<input id="cpf" type="text" class="validate" v-model="CPF">
          						<label for="cpf">CPF:</label>
        				</div>

						<div class="input-field col s12 m4 l4">
          						<input id="rg" type="text" class="validate" v-model="RG">
          						<label for="rg">RG:</label>
        				</div>

						<div class="input-field col s12 m4 l4">
          						<input id="rua" type="text" class="validate" v-model="rua">
          						<label for="rua">Rua:</label>
        				</div>

						<div class="input-field col s12 m4 l4">
          						<input id="num" type="text" class="validate" v-model="num">
          						<label for="num">Número:</label>
        				</div>

						<div class="input-field col s12 m4 l4">
          						<input id="bairro" type="text" class="validate" v-model="bairro">
          						<label for="bairrio">Bairro:</label>
        				</div>

						<div class="input-field col s12 m3 l3">
                    <select v-model="estado">
                        <option value="AC">Acre</option>
                        <option value="AL">Alagoas</option>
                        <option value="AP">Amapá</option>
                        <option value="AM">Amazonas</option>
                        <option value="BA">Bahia</option>
                        <option value="CE">Ceará</option>
                        <option value="DF">Distrito Federal</option>
                        <option value="ES">Espírito Santo</option>
                        <option value="GO">Goiás</option>
                        <option value="MA">Maranhão</option>
                        <option value="MT">Mato Grosso</option>
                        <option value="MS">Mato Grosso do Sul</option>
                        <option value="MG">Minas Gerais</option>
                        <option value="PA">Pará</option>
                        <option value="PB">Paraíba</option>
                        <option value="PR">Paraná</option>
                        <option value="PE">Pernambuco</option>
                        <option value="PI">Piauí</option>
                        <option value="RJ">Rio de Janeiro</option>
                        <option value="RN">Rio Grande do Norte</option>
                        <option value="RS">Rio Grande do Sul</option>
                        <option value="RO">Rondônia</option>
                        <option value="RR">Roraima</option>
                        <option value="SC">Santa Catarina</option>
                        <option value="SP">São Paulo</option>
                        <option value="SE">Sergipe</option>
                        <option value="TO">Tocantins</option>
                    </select>
                    <label>Estado:</label>
                </div>

						<div class="input-field col s12 m3 l3">
          						<input id="cidade" type="text" class="validate" v-model="cidade">
          						<label for="cidade">Cidade:</label>
        				</div>

						<div class="input-field col s12 m3 l3">
          						<input id="cep" type="text" class="validate" v-model="CEP">
          						<label for="cep">CEP:</label>
        				</div>

						<div class="input-field col s12 m3 l3">
          						<input id="comple" type="text" class="validate" v-model="comple">
          						<label for="comple">Complemento:</label>
        				</div>

							
								
        							<div class="input-field col s12 m12 l12">
          								<textarea id="textarea1" class="materialize-textarea" v-model="infoadd"></textarea>
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
		name: "Professores",
        data() {
            return { 
                professores: [],
                estado: "",
                sobrenomes : ""
            }
        },

		mounted: function () {
			$(document).ready(function () {
                $('.modal').modal();
               
            });
            this.$http.get('Usuarios/porTipo').then(response => {
                this.professores = response.body;

            }, response => {
                console.log("ERRO! Código de resposta (HTTP) do servidor: " + response.status);
            });

		},
		methods: {
            teste(oi){
                    console.log(this.professores[oi]);
                    this.sobrenomes = this.professores[oi].pes_sobrenomes;
                    $(document).ready(function () {
               
                M.updateTextFields();
                $('select').formSelect();
            });
            }
        }
	}

</script>

<style src="./../../assets/css/professor/MinhasDisciplinas.css" scoped></style>
<style src="./../../assets/css/gerenteGeral/tables.css" scoped></style>
   
