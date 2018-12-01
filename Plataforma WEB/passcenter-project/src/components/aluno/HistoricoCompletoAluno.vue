<template>
    <div>
        <div class="row area-exibicao">
            <div class="col s12 m3 l3 espacamento" v-for="item in 1" :key="item.id">
                <!-- {{ item }} -->
                <!-- Dropdown Trigger -->
                      <a class='dropdown-trigger btn' href='#' data-target='dropdown1'><i class="icone material-icons">insert_invitation</i>Selecione o ano:</a>

  <!-- Dropdown Structure -->
                      <ul id='dropdown1' class='dropdown-content'>
                      <li  v-for="item in 3" :key="item.id">
                        
                          <router-link :to="{ name: 'HistoricoCompletoDisciplinas' }" class=" waves-effect">20XX</router-link>
                      </li>
                           
                     
    </ul>
        
                    
              
            </div>
        </div>
          
    </div>
</template>


<script src="./../../assets/js/aluno/HistoricoCompleto.js"></script>

