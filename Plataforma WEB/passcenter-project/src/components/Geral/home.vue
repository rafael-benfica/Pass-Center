<template>
    <div id="base">

        <nav>
            <div class="nav-wrapper ">
            <ul id="nav-mobile" class="right hide-on-med-and-down">
                <li><a href="sass.html">Home</a></li>
                <li><a href="badges.html">Quem Somos</a></li>
                <li><a href="badges.html">Nossos Valores</a></li>
                <li><a class="waves-effect waves-light btn">Login</a></li>
            </ul>
            </div>
        </nav>
        <div class="row">
            <div class="row">
                <div class="col m12 center-align">
                    <img id="logo1" src="../../assets/img/logo-home.png"> 
                </div>
            </div>
            <div class="row">
                <div class="col m12 center-align">
                    <img id="botao" src="../../assets/img/botao-home.png"> 
                </div>
            </div>
        </div>
        <div class="row">
            <div class="row">
                <div class="col m12 center-align">
                    <h1>Quem Somos</h1>
                </div>
            </div>

            <div class="row">
                <div class="col m6 center-align">
                    <img id="logo2" src="../../assets/img/logo-vertical-home.png"> 
                </div>
                <div class="col m6 center-align">
                    <p>O PassCenter é uma solução que visa gerenciar a entrada e saída de pessoas em determinado local ou área.</p>
                    <p>Contando com um módulo acadêmico exclusivo e extremamente completo; 
                        tornando-se assim a melhor solução para subistituir a utrapassa “chamada”. </p>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
		name: "Home",
        
    }
</script>

<style scoped>

#base{
    color:white; 
}

nav{
    background: transparent;
    box-shadow: none;
}

#logo1{
    margin-top: 25vh;
    width: 40%;
}

#logo2{
    width: 40%;
}

#botao{
    position: relative;
    z-index: 1;
    margin-top: 20vh;
    width: 8%;
}

p{
    font-size: 1.2rem;
    text-align: left;
}
</style>