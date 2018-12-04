<template>
    <div class="row area-exibicao">
        <form class="col s12 card data2" onsubmit="return false">
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
                            <button class="btn waves-effect waves-light" @click="confirmação()">Salvar</button>               
                         <router-link :to="{ name: 'ListaManual2' }" class=" waves-effect">             
                             <button class="btn waves-effect waves-light" type="submit" name="action">Cancelar</button>
                         </router-link>
	
                        </div>
                        
            
	            </div>
            </div>
        </form>
    </div>
</template>

<script>
	export default {
		name: "ListaManual3",

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
    },
	}

</script>

<style src="./../../assets/css/professor/MinhasDisciplinas.css" scoped></style>
   
