<template>
  <div class="fonte">
    
    <div class="grey lighten-3 ajuste menu-superior">  
      <a href="#" class="center-align">
        <img src="./../../assets/img/logo.png">
      </a>
    </div>

    <nav class="grupo-breadcrumb">
      <div class="nav-wrapper">
        <div class="ajuste col s12">
          <a v-for="(breadcrumbs, indice) in breadcrumbsLista" :key="indice" @click="levarPara(indice)" class="breadcrumb">
            {{ breadcrumbs.nome }}
          </a>
        </div>
      </div>
    </nav>   

    <ul id="slide-out" class=" sidenav sidenav-fixed">
      <li><div class="user-view">
        <div class="background">
         <!-- <img src="./assets/02.jpg"> -->
       </div>
       <a href="#user"><img class="circle" src="./../../assets/img/01.jpg"></a>
       <a href="#name"><span class="white-text name">{{ nome }}</span></a>
       <a href="#email"><span class="white-text email">ID #{{ matricula }}</span></a>
     </div></li>
     <li><router-link :to="{ name: 'MinhasDisciplinasAluno' }" class=" waves-effect"><i class="icone material-icons">view_comfy</i>Minhas Disciplinas</router-link></li>
     <li><router-link :to="{ name: 'MeusDadosAluno' }" class=" waves-effect"><i class="icone material-icons">account_circle</i>Meus dados</router-link></li>
     <li><router-link :to="{ name: 'HistoricoCompletoAluno' }" class=" waves-effect"><i class="icone material-icons">chrome_reader_mode</i>Histórico Completo</router-link></li>
     <li class="center-align botao-sair"><router-link :to="{ name: 'Login' }" class="waves-effect waves-light btn red darken-4">Sair</router-link></li>
   </ul>

   <a data-target="slide-out" class="sidenav-trigger show-on-small "><i class="material-icons gatilho-mobile">menu</i></a>
   
   <router-view class="ajuste"/>
   
 </div>
</template>

<script src="./../../assets/js/aluno/DashBoardAluno.js"></script>

<style src="./../../assets/css/aluno/DashBoardAluno.css" scoped></style>



