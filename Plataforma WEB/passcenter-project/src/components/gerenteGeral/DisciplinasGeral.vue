<template>
	<div>
		<div class="row area-exibicao">
			<div class="col s12 m4 l4 espacamento" v-for="item in 6" :key="item.id">
				<div class="card">
					<div class="card-content">
						<h2 class="card-title cardDisciplina">Engenharia de Softwares {{ item }}</h2><br />
					</div>
				</div>
			</div>
		</div>
		<div class="row col s12 m12 l12 espacamento">
			<p class="col s12 m4 l4"></p>
			<a class="col s12 m4 l4 modal-trigger" href="#modal2">
				<div class="card">
					<div class="card-content">
						<span><i class="icone material-icons">add_circle_outline</i></span>
					</div>
				</div>
			</a>
			<p class="col s12 m4 l4"></p>
		</div>
		<div id="modal2" class="modal margem">
			<div class="modal-content">
				<h4 class="centro">Cadastro Disciplina</h4>
				<hr>

				<div class="row col s12 m12 l12">
					<div class="input-field col s12 m6 l6">
						<input id="nomeDis" type="text" class="validate">
						<label for="nomeDis">Nome:</label>
					</div>

					<div class="input-field col s12 m6 l6">
						<input id="sigla" type="text" class="validate">
						<label for="sigla">Sigla:</label>
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
</template>

<script>
	export default {
		name: "DisciplinasGeral",

		mounted: function () {
			$(document).ready(function () {
				$('.modal').modal();
			});
		},
		
	}

</script>


<style src="./../../assets/css/aluno/MinhasDisciplinasAluno.css" scoped></style>
