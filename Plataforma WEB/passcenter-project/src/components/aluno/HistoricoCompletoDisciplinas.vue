<template>
  <div>
    <div class="row area-exibicao">
      <div class="col s12 m3 l3 espacamento" v-for="item in 1" :key="item.id">
        <!-- {{ item }} -->
        <!-- Dropdown Trigger -->
        <a class='dropdown-trigger btn' href='#' data-target='dropdown1'>20XX</a>

        <!-- Dropdown Structure -->
        <ul id='dropdown1' class='dropdown-content'>
          <li  v-for="item in 3" :key="item.id">
            
            <a>20XX</a>
          </li>
          
          
        </ul>
        
        
        
      </div>
    </div>
    
  </div>
</template>


<script src="./../../assets/js/aluno/HistoricoCompleto.js"></script>
<style src="./../../assets/css/aluno/MinhasDisciplinasAluno.css" scoped></style>
