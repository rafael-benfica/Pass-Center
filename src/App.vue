<template>
  <div>
    <nav class="grey lighten-3">  
        <a href="#" class="ajuste brand-logo center"><span class="brand-logo-pass">PASS</span> CENTER</a>
    </nav>

    <nav class="transparent">
      <div class="nav-wrapper">
          <div class="ajuste col s12">
            <a href="#!" class="breadcrumb">First</a>
            <a href="#!" class="breadcrumb">Second</a>
            <a href="#!" class="breadcrumb">Third</a>
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
  <a href="#" data-target="slide-out" class="sidenav-trigger hide-on-med-and-up"><i class="material-icons">menu</i></a>
    <router-view/>
  </div>
</template>

<script>
export default {
  name: "app"
};
</script>

<style scoped>
    .sair{
      bottom: 4rem;
      left: 27%;
      position: absolute;
      display: inline;
    }
    
    .brand-logo-pass{
      color: black;
      font-weight:900 !important;
    }

    .brand-logo{
      color: black;
      font-weight:100 !important;
       
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


