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
                            <tr v-for="(item, index) in professores" :key="item.id" @click="verDados(index)">
                                <td>{{ item.pes_nome +" "+ item.pes_sobrenomes }}</td>
                                <td>{{ "#"+item.pes_matricula }}</td>
                                <td>{{ item.pes_tel_residencial  }}</td>
                                <td>{{ item.pes_tel_celular }}</td>
                                <td><a class="waves-effect waves-light btn modal-trigger" href="#modalVer">ver</a></td>
                            </tr> 
                        </tbody>
                    </table>
                
                        <a class="col s12 m12 l12 centro waves-effect waves-light btn modal-trigger botaoVerMais" href="#modalAdd" @click="addDados()">Adicionar Professores</a>

                        <div id="modalVer" class="modal">
                            <div class="modal-content">
                                <h4 class="centro">Professor</h4>
                                <hr>
                                <div class="row col s12 m12 l12">
                                    <div class="row">
                                        <div class="input-field col s12 m4">
                                            <input id="nome" type="text" class="validate" v-model="nome">
                                            <label for="nome">Nome</label>
                                        </div>
                                        <div class="input-field col s12 m6">
                                            <input id="sobrenome" type="text" class="validate" v-model="sobrenomes">
                                            <label for="sobrenome">Sobrenome</label>
                                        </div>
                                        <div class="input-field col s12 m2">
                                            <input id="data_nascimento" type="text" class="validate" v-model="data_nascimento">
                                            <label for="data_nascimento">Data de Nascimento</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="input-field col s12 m4">
                                            <input id="cpf" type="text" class="validate" v-model="CPF">
                                            <label for="cpf">CPF</label>
                                        </div>
                                        <div class="input-field col s12 m4">
                                            <input id="rg" type="text" class="validate" v-model="RG">
                                            <label for="rg">RG</label>
                                        </div>
                                        <div class="input-field col s12 m4">
                                            <select v-model="sexo">
                                                <option value="1">Masculino</option>
                                                <option value="2">Feminino</option>
                                                <option value="3">Outros</option>
                                            </select>
                                            <label>Sexo:</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="input-field col s12 m4">
                                            <input id="rua" type="text" class="validate" v-model="logradouro">
                                            <label for="rua">Rua</label>
                                        </div>
                                        <div class="input-field col s12 m4">
                                            <input id="numero" type="text" class="validate" v-model="numero">
                                            <label for="numero">Número</label>
                                        </div>
                                        <div class="input-field col s12 m4">
                                            <input id="bairro" type="text" class="validate"  v-model="bairro">
                                            <label for="bairro">Bairro</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="input-field col s12 m4">
                                            <input id="cep" type="text" class="validate" v-model="CEP">
                                            <label for="cep">CEP</label>
                                        </div>
                                        <div class="input-field col s12 m6">
                                            <input id="municipio" type="text" class="validate" v-model="municipio">
                                            <label for="municipio">Município</label>
                                        </div>
                                        <div class="input-field col s12 m2">
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
                                    </div>
                                    <div class="row">
                                        <div class="input-field col s12 m6">
                                            <input id="email" type="email" class="validate" v-model="login">
                                            <label for="email">Email</label>
                                        </div>
                                        <div class="input-field col s12 m6">
                                            <input id="password" type="password" class="validate" autocomplete="no" v-model="senha">
                                            <label for="password">Senha</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="input-field col s12 m6">
                                            <input id="tel_residencial" type="text" class="validate" v-model="tel_residencial">
                                            <label for="tel_residencial">Telefone Residencial:</label>
                                        </div>
                                        <div class="input-field col s12 m6">
                                            <input id="tel_celular" type="text" class="validate" v-model="tel_celular">
                                            <label for="tel_celular">Telefone Celular:</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="input-field col s12 m12">
                                            <textarea id="infoadd" class="materialize-textarea" v-model="infoadd"></textarea>
                                            <label for="infoadd">Informações Adicionais</label>
                                        </div>
                                    </div>
                                                
                                </div>
                    
                                <div class="modal-footer row col s12 m12 l12 ">
                                    <a href="#!" class="col s12 m4 l4 modal-close waves-effect waves-teal btn red">Fechar</a>
                                    <p class="col s12 m4 l4"></p>
                                    <a class="col s12 m4 l4 waves-effect waves-teal btn green" @click="confirmacaoUpdate()">Salvar</a>
                                </div>
                            </div>
                        </div>

                        <div id="modalAdd" class="modal">
                            <div class="modal-content">
                                <h4 class="centro">Cadastro Professor</h4>
                                <hr>
                                <div class="row col s12 m12 l12">
                                    <div class="row">
                                        <div class="input-field col s12 m2">
                                            <input id="matriculaModalAdd" type="text" class="validate" v-model="matricula">
                                            <label for="matriculalAdd">Matrícula</label>
                                        </div>
                                        <div class="input-field col s12 m4">
                                            <input id="nomeModalAdd" type="text" class="validate" v-model="nome">
                                            <label for="nomeModalAdd">Nome</label>
                                        </div>
                                        <div class="input-field col s12 m6">
                                            <input id="sobrenomeModalAdd" type="text" class="validate" v-model="sobrenomes">
                                            <label for="sobrenomeModalAdd">Sobrenome</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="input-field col s12 m3">
                                            <input id="data_nascimentoModalAdd" type="text" class="datepicker validate" v-model="data_nascimento">
                                            <label for="data_nascimentoModalAdd">Data de Nascimento</label>
                                        </div>  
                                        <div class="input-field col s12 m3">
                                            <input id="cpfModalAdd" type="text" class="validate" v-model="CPF">
                                            <label for="cpfModalAdd">CPF</label>
                                        </div>
                                        <div class="input-field col s12 m3">
                                            <input id="rgModalAdd" type="text" class="validate" v-model="RG">
                                            <label for="rgModalAdd">RG</label>
                                        </div>
                                        <div class="input-field col s12 m3">
                                            <select v-model="sexo">
                                                <option value="" disabled>Selecione um sexo</option>
                                                <option value="1">Masculino</option>
                                                <option value="2">Feminino</option>
                                                <option value="3">Outros</option>
                                            </select>
                                            <label>Sexo:</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                         <div class="input-field col s12 m3">
                                            <input id="bairroModalAdd" type="text" class="validate"  v-model="bairro">
                                            <label for="bairroModalAdd">Bairro</label>
                                        </div>
                                        <div class="input-field col s12 m5">
                                            <input id="ruaModalAdd" type="text" class="validate" v-model="logradouro">
                                            <label for="ruaModalAdd">Rua</label>
                                        </div>
                                        <div class="input-field col s12 m2">
                                            <input id="numeroModalAdd" type="text" class="validate" v-model="numero">
                                            <label for="numeroModalAdd">Número</label>
                                        </div>
                                        <div class="input-field col s12 m2">
                                            <input id="cepModalAdd" type="text" class="validate" v-model="CEP">
                                            <label for="cepModalAdd">CEP</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="input-field col s12 m5">
                                            <input id="municipioModalAdd" type="text" class="validate" v-model="municipio">
                                            <label for="municipioModalAdd">Município</label>
                                        </div>
                                        <div class="input-field col s12 m3">
                                            <select v-model="estado">
                                                <option value="" disabled>Selecione um estado</option>
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
                                        <div class="input-field col s12 m4">
                                            <input id="ComplementoModalAdd" type="text" class="validate" v-model="complemento">
                                            <label for="ComplementoModalAdd">Complemento</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="input-field col s12 m6">
                                            <input id="emailModalAdd" type="email" class="validate" v-model="login">
                                            <label for="emailModalAdd">Email</label>
                                        </div>
                                        <div class="input-field col s12 m6">
                                            <input id="passwordModalAdd" type="password" class="validate" autocomplete="no" v-model="senha">
                                            <label for="passwordModalAdd">Senha</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="input-field col s12 m6">
                                            <input id="tel_residencialModalAdd" type="text" class="validate" v-model="tel_residencial">
                                            <label for="tel_residencialModalAdd">Telefone Residencial:</label>
                                        </div>
                                        <div class="input-field col s12 m6">
                                            <input id="tel_celularModalAdd" type="text" class="validate" v-model="tel_celular">
                                            <label for="tel_celularModalAdd">Telefone Celular:</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="input-field col s12 m12">
                                            <textarea id="infoaddModalAdd" class="materialize-textarea" v-model="infoadd"></textarea>
                                            <label for="infoaddModalAdd">Informações Adicionais</label>
                                        </div>
                                    </div>
                                                
                                </div>
                    
                            <div class="modal-footer row col s12 m12 l12 ">
                                <a href="#!" class="col s12 m4 l4 modal-close waves-effect waves-teal btn red">Cancelar</a>
                                <p class="col s12 m4 l4"></p>
                                <a class="col s12 m4 l4 waves-effect waves-teal btn green" @click="confirmacaoCriar()">Confirmar</a>
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
                pessoa_codigo : "",
                endereco_codigo : "",
                usuario_codigo : "",
                matricula : "",
                nome : "",           
                sobrenomes : "",
                data_nascimento : "",
                CPF : "",
                RG : "",
                sexo : "",
                logradouro : "",
                numero : "",
                bairro : "",
                CEP : "",
                municipio : "",
                estado : "",
                complemento : "",
                login : "",
                senha : "",
                tel_residencial: "",
                tel_celular : "",
                infoadd : "",
            }
        },

		mounted() {
			$(document).ready(function () {
                $('.modal').modal();
            });

            this.carregarDados();

		},
		methods: {
            carregarDados(){
                this.$http.get('Usuarios/porTipo', {params: {tipo: 4}}).then(response => {
                    this.professores = response.body;
                }, response => {
                    console.log("ERRO ao carregar os Dados! Código de resposta (HTTP) do servidor: " + response.status);
                });
            },

            verDados(index){
                var dados = this.professores[index];

                this.usuario_codigo = dados.usu_codigo;
                this.pessoa_codigo = dados.pes_codigo;
                this.endereco_codigo = dados.end_codigo;
                this.nome = dados.pes_nome;
                this.sobrenomes = dados.pes_sobrenomes;
                this.data_nascimento = dados.pes_data_nascimento.replace("T00:00:00","");
                this.CPF = dados.pes_cpf;
                this.RG = dados.pes_rg;
                this.sexo = dados.pes_sexo;
                this.logradouro = dados.end_logradouro;
                this.numero = dados.end_numero;
                this.bairro = dados.end_bairro;
                this.CEP = dados.end_cep;
                this.municipio = dados.end_municipio;
                this.estado = dados.end_estado;
                this.complemento = dados.end_complemento;
                this.login = dados.usu_login;
                this.senha = dados.usu_senha;
                this.tel_residencial = dados.pes_tel_residencial;
                this.tel_celular = dados.pes_tel_celular;
                this.infoadd = dados.pes_info_adicionais;


                $(document).ready(function () {              
                    M.updateTextFields();
                    $('select').formSelect();
                    $('.datepicker').datepicker();
                });
            },

            addDados(){
                this.matricula = "";
                this.nome = "";
                this.sobrenomes = "";
                this.data_nascimento = "";
                this.CPF = "";
                this.RG = "";
                this.sexo = "";
                this.logradouro= "";
                this.numero = "";
                this.bairro = "";
                this.CEP = "";
                this.municipio = "";
                this.estado = "";
                this.complemento = "";
                this.login = "";
                this.senha = "";
                this.tel_residencial = "";
                this.tel_celular = "";
                this.infoadd = "";


                $(document).ready(function () {              
                    M.updateTextFields();
                    $('select').formSelect();
                });
            },

            confirmacaoUpdate() {
				const swalWithBootstrapButtons = swal.mixin({
					confirmButtonClass: 'btn green sepraracaoBotoes',
					cancelButtonClass: 'btn red sepraracaoBotoes',
					buttonsStyling: false,
				})

				swalWithBootstrapButtons({
					title: 'Você tem certeza?',
					text: "Você não poderá reverter essa ação!",
					type: 'warning',
					showCancelButton: true,
					confirmButtonText: 'Sim, faça!',
					cancelButtonText: 'Não, cancele!',
					reverseButtons: true
				}).then((result) => {
					if (result.value) {
						
						const dodosPessoais = {
							pes_codigo : this.pessoa_codigo,
							pes_nome : this.nome,
                            pes_sobrenomes : this.sobrenomes,
                            pes_data_nascimento: this.data_nascimento,                            
							pes_cpf : this.CPF,
							pes_rg : this.RG,
							pes_sexo : this.sexo,
							pes_tel_residencial : this.tel_residencial,
							pes_tel_celular : this.tel_celular,
							pes_info_adicionais: this.infoadd
						}
						
						var dodosEndereco = {
							end_codigo : this.endereco_codigo, 
							end_logradouro : this.logradouro, 
							end_numero : this.numero, 
							end_bairro : this.bairro, 
							end_municipio : this.municipio,
							end_cep : this.CEP,
							end_estado : this.estado,  
							end_complemento : this.complemento 
						}

						var dodosUsuario = {
							usu_codigo : this.usuario_codigo, 
							usu_login : this.login, 
							usu_senha : this.senha, 
						}

						this.$http.put('Pessoas', dodosPessoais).then(response => {
							this.$http.put('Enderecos', dodosEndereco).then(response => {
								this.$http.put('Usuarios', dodosUsuario).then(response => {
                                    this.carregarDados();
									swalWithBootstrapButtons(
										'Alterado!',
										'As alterações foram salvas.',
										'success'
										)
								}, response => {
									this.erro("Dados do Usuário", response.status);
								});
							}, response => {
								this.erro("Endereço", response.status);
							});
						}, response => {
							this.erro("Dados Pessoais", response.status);
						});

					} else if (
                    // Read more about handling dismissals
                    result.dismiss === swal.DismissReason.cancel
                    ) {
                        this.carregarDados();
						swalWithBootstrapButtons(
							'Cancelado!',
							'Alterações não enviadas!',
							'error'
							)
					}
                    
                })
            },

            confirmacaoCriar() {
				const swalWithBootstrapButtons = swal.mixin({
					confirmButtonClass: 'btn green sepraracaoBotoes',
					cancelButtonClass: 'btn red sepraracaoBotoes',
					buttonsStyling: false,
				})

				swalWithBootstrapButtons({
					title: 'Todos os dados estão corretos?',
					type: 'warning',
					showCancelButton: true,
					confirmButtonText: 'Sim, Crie!',
					cancelButtonText: 'Não, cancele!',
					reverseButtons: true
				}).then((result) => {
					if (result.value) {
					
						
						var dodosEndereco = {
							end_codigo : this.endereco_codigo, 
							end_logradouro : this.logradouro, 
							end_numero : this.numero, 
							end_bairro : this.bairro, 
							end_municipio : this.municipio,
							end_cep : this.CEP,
							end_estado : this.estado,  
                            end_complemento : this.complemento, 
                            end_pais : "BR",
                            ten_codigo : {
                                ten_codigo : "2"
                            }
						}

						this.$http.post('Enderecos', dodosEndereco).then(response => {

                            const dodosPessoais = {
                                pes_matricula : this.matricula,                            
                                pes_nome : this.nome,
                                pes_sobrenomes : this.sobrenomes,
                                pes_data_nascimento : this.data_nascimento,
                                pes_cpf : this.CPF,
                                pes_rg : this.RG,
                                pes_sexo : this.sexo,
                                pes_tel_residencial : this.tel_residencial,
                                pes_tel_celular : this.tel_celular,
                                pes_info_adicionais: this.infoadd,
                                end_codigo : {
                                    end_codigo : response.body
                                }
                            }

							this.$http.post('Pessoas', dodosPessoais).then(response => {
                                
                                var dodosUsuario = {
                                    usu_codigo : this.usuario_codigo, 
                                    usu_login : this.login, 
                                    usu_senha : this.senha, 
                                    pes_codigo : {
                                        pes_codigo : response.body
                                    },
                                    tus_codigo : {
                                        tus_codigo : 4
                                    }
                                }
                                
                                this.$http.post('Usuarios', dodosUsuario).then(response => {
                                    this.carregarDados();
									swalWithBootstrapButtons(
										'Salvo!',
										'Todas as informações foram salvas.',
										'success'
										)
								}, response => {
									this.erro("Dados do Usuário", response.status);
								});
							}, response => {
								this.erro("Dados Pessoais", response.status);
							});
						}, response => {
							this.erro("Endereço", response.status);
						});

					} else if (
                    // Read more about handling dismissals
                    result.dismiss === swal.DismissReason.cancel
                    ) {
                        this.carregarDados(),
						swalWithBootstrapButtons(
							'Okay!',
							'Revise/altere o que for necessário ;)',
							'info'
						)
					}
                })
            },

            erro(msg, code) {
				swal({
					title: 'Oops!',
					text: 'Algo deu errado! Os dados não foram salvos!',
					type: 'error'
                }),
                    
                console.log("ERRO ao atualizar "+msg+"! Código de resposta (HTTP) do servidor: " + code),
                
                this.carregarDados()
			}
        }
	}

</script>

<style src="./../../assets/css/professor/MinhasDisciplinas.css" scoped></style>
<style src="./../../assets/css/gerenteGeral/tables.css" scoped></style>
   
