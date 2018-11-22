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
      <a href="#name"><span class="white-text name">Nome do Usuário</span></a>
      <a href="#email"><span class="white-text email">ID #9999999</span></a>
    </div></li>
    <li><a class=" waves-effect" href="#!"><i class="icone material-icons">assignment</i>Minhas Disciplinas</a></li>
    <li><a class=" waves-effect" href="#!"><i class="icone material-icons">assignment_ind</i>Meus dados</a></li>
    <li class="center-align botao-sair"><a class="waves-effect waves-light btn red darken-4">Sair</a></li>
  </ul>

  <a href="#" data-target="slide-out" class="sidenav-trigger show-on-small "><i class="material-icons gatilho-mobile">menu</i></a>
    
    <router-view class="ajuste"/>
  
  </div>
</template>

<script src="./../../assets/js/administrador/DashBoardAdministrador.js"></script>

<style src="./../../assets/css/administrador/DashBoardAdministrador.css" scoped></style>



