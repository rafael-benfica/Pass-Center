<template>
  <div>
    <div class="ajuste base grey lighten-3">  
        <a href="#" class="brand-logo center-align"><span class="brand-logo-pass">PASS</span> CENTER</a>
    </div>

    <nav class="transparent">
      <div class="nav-wrapper">
          <div class="ajuste col s12">
            <a v-for="(breadcrumbs, indice) in breadcrumbsLista" :key="indice" @click="levarPara(indice)" class="breadcrumb">
              {{ breadcrumbs.nome }}
            </a>
          </div>
        </div>
    </nav>
     

  <ul id="slide-out" class="sidenav sidenav-fixed">
    <li><div class="user-view">
      <div class="background">
        <img src="./assets/02.jpg">
      </div>
      <a href="#user"><img class="circle" src="./assets/01.jpg"></a>
      <a href="#name"><span class="white-text name">Rafael A. B. Silva</span></a>
      <a href="#email"><span class="white-text email">ID #9999999</span></a>
    </div></li>
    <li><a class="waves-effect" href="#!"><i class="material-icons">assignment</i>Minhas Disciplinas</a></li>
    <li><a class="waves-effect" href="#!"><i class="material-icons">assignment_ind</i>Meus dados</a></li>
    <li class="center-align sair"><a class="waves-effect waves-light btn red darken-4">Sair</a></li>
  </ul>
  <a href="#" data-target="slide-out" class="sidenav-trigger show-on-small"><i class="material-icons">menu</i></a>
    <router-view class="ajuste"/>
  </div>
</template>

<style scoped>
    .base{
      width: 100%;
      height: 64px;
      line-height: 64px;
      display: block;
      box-shadow: 0 2px 2px 0 rgba(0,0,0,0.14),0 3px 1px -2px rgba(0,0,0,0.12),0 1px 5px 0 rgba(0,0,0,0.2);
      font-size: 32px;
      text-align: center;
    }
    .sair{
      bottom: 4rem;
      left: 27%;
      position: absolute;
      display: inline;
    }
    
    .brand-logo-pass{
      color: black;
      font-weight: 900 !important;
    }

    .brand-logo{
      color: black;
      font-weight: 100 !important;
       
    }
    .breadcrumb::before{
      color: black;
    }
    .breadcrumb{
      color: black;
    }
    .ajuste {
      padding-left: 300px;
    }
    .transparent{
      padding-left: 20px;
      box-shadow: none !important;
    }

    @media only screen and (max-width : 992px) {
      .ajuste {
        padding-left: 0;
      }
    }

</style>

<script src="./assets/meujs.js"></script>


