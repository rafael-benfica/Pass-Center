<template>
    <div>
        
        <div class="row area-exibicao">
            <div class="col s12 m4 l4 espacamento" v-for="(item, index) in enventosAuditores" :key="item.id">
                <div class="modal-trigger" href="#modal" @click="verDados(index)">
                    <div class="card">
                        <div class="card-content">
                            <h1 class="card-title cardDisciplina">{{ item.eve_nome }}</h1>
                            <h3 class="card-title cardDisciplina">Professor(a):</h3>
                            <h4 class="cardTurmaCarga">{{ item.pes_nome }}</h4><br />
                        </div>
                    </div>
                </div>
            </div>

            <div id="modal" class="modal margem">
                <div class="modal-content">
                    <h3 class="centro">{{nomeDisciplina}}</h3>
                    <h4>{{ nomeAuditor }}</h4>

                    <table>
                        <thead class="centro">
                                 <tr>
                                    <th>Nome do Aluno</th>
                                    <th>Matrícula do do Aluno</th>
                                    <th></th>
                                 </tr>
                        </thead>
                        <tbody>
                            <tr v-for="item in alunos" :key="item.id">
                                <td>{{ item.pes_nome +" "+ item.pes_sobrenomes }}</td>
                                <td>{{ "#"+item.pes_matricula }}</td>
                                <td><a class="waves-effect waves-light btn red modal-trigger" href="#modalVer">Remover</a></td>
                            </tr>
                            
                        </tbody>
                    </table>
                    
                    <a class="col s12 m12 l12 centro waves-effect waves-light btn modal-trigger botaoVerMais" href="#modalAdd" @click="addDados()">Adicionar alunos</a>
                    
                    <div class="modal-footer row col s12 m12 l12 ">
                        <a href="#!" class="col s12 m4 l4 modal-close waves-effect waves-teal btn red">Fechar</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
			
</template>

<script>
	export default {
		name: "TurmasGeral",
        data() {    
            return {
                alunos:[],
                enventosAuditores: [],
                evento_auditor:[],
                nomeDisciplina: "",
                nomeAuditor: ""
            }
        },
		mounted() {

            this.$http.get('EnventosAuditores').then(response => {
                    this.enventosAuditores = response.body;
            }, response => {
                    console.log("ERRO ao carregar os Dados! Código de resposta (HTTP) do servidor: " + response.status);
            });

            this.$http.get('Usuarios/porTipo', {params: {tipo: 5}}).then(response => {
                    this.alunos = response.body;
            }, response => {
                    console.log("ERRO ao carregar os Dados! Código de resposta (HTTP) do servidor: " + response.status);
            });


			$(document).ready(function () {
                $('.modal').modal();
            });
        
        },
        methods: {
            verDados(index){
                 var dados = this.enventosAuditores[index];
                this.nomeDisciplina = dados.eve_nome;
                this.nomeAuditor = dados.pes_nome;
            },
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


<style src="./../../assets/css/gerenteGeral/GeralGerenteGeral.css" scoped></style>
