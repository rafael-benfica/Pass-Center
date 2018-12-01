<template>
	<div>
		<div class="row area-exibicao">
			<div class="col s12 m3 l3 espacamento" v-for="item in 7" :key="item.id">
				<!-- {{ item }} -->
				<div class="card">
					<div class="card-content">
						<span class="card-title cardDisciplina">Interação Humano Computador</span>
						<p class="cardTurmaCarga">4º ADS - 40h</p>
						<p class="cardFaltasPresencas">23 prenseças em 25 aulas</p>
						<a class="waves-effect waves-light btn modal-trigger botaoVerMais" href="#modal">Ver mais</a>
					</div>
				</div>
			</div>
		</div>
		<!-- Modal Structure -->
		<div id="modal" class="modal">
			<div class="modal-content">
				<h4>Modal Header</h4>
				<p>A bunch of text</p>
			</div>
			<div class="modal-footer">
				<a href="#!" class="modal-close waves-effect waves-green btn-flat">Agree</a>
			</div>
		</div>
		
		
	</div>
</template>

<script>
	export default {
		name: "GerenteCadastroMateria",

		mounted: function () {
			$(document).ready(function () {
				$('.modal').modal();
			});
		},
		
	}

</script>


<style src="./../../assets/css/aluno/MinhasDisciplinasAluno.css" scoped></style>

