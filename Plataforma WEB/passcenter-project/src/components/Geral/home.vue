<template>
    <div id="base">
        <div class="navbar-fixed">
            <nav>
                <div class="nav-wrapper ">
                    <a data-target="mobile-demo" class="sidenav-trigger"><i class="material-icons">menu</i></a>
                    <ul id="nav-mobile" class="right hide-on-med-and-down">
                        <li><a href="#Home">Home</a></li>
                        <li><a href="#QuemSomos">Quem Somos</a></li>
                        <li><a href="#NossosValores">Nossos Valores</a></li>
                        <li><router-link :to="{ name: 'Login' }" class="waves-effect waves-light btn">Login</router-link></li>
                    </ul>
                </div>
            </nav>
            
        </div>
        <ul class="sidenav" id="mobile-demo">
                <li><a href="#Home">Home</a></li>
                <li><a href="#QuemSomos">Quem Somos</a></li>
                <li><a href="#NossosValores">Nossos Valores</a></li>
                <li><router-link :to="{ name: 'Login' }" class="waves-effect waves-light btn">Login</router-link></li>
            </ul>
        <a name="Home"></a>
        <div class="row tamanho">
            <div class="row">
                <div class="col m12 s12 center-align">
                    <img id="logo1" src="../../assets/img/logo-home.png"> 
                </div>
            </div>
            <div class="row">
                <div class="col m12 s12 center-align">
                    <a href="#QuemSomos"><img id="botao" src="../../assets/img/botao-home.png"></a> 
                </div>
            </div>
        </div>

        <div class="row tamanho">
            <div class="row">
                <div class="col m12 s12 center-align">
                    <h1><a name="QuemSomos">Quem Somos</a></h1>
                </div>
            </div>

            <div class="row">
                <div class="col m6 s12 center-align">
                    <img id="logo2" src="../../assets/img/logo-vertical-home.png"> 
                </div>
                <div class="col m5 center-align sobreNos">
                    <p class="sobreNosTexto">O PassCenter é uma solução que visa gerenciar a entrada e saída de pessoas em determinado local ou área.</p>
                    <p class="sobreNosTexto">Contando com um módulo acadêmico exclusivo e extremamente completo; 
                        tornando-se assim a melhor solução para subistituir a utrapassa “chamada”. </p>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="row">
                <div class="col m12 s12 center-align">
                    <h1><a name="NossosValores">Nossos Valores</a></h1>
                </div>
            </div>
            <div class="row">
                <div class="col m4 s12 center-align">
                    <div class="row">
                        <div class="col m12 s12">
                            <i class="icone material-icons">brightness_4</i>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col m12 s12">
                            <h3>24/7/12/360 <br /><br /></h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col m12 text-center">
                            <p class="nossosValores">Um dos nosso pilares é a Disponibilidade!
                            A nossa missão é garantir que a plataforma esteja on-line sempre.</p>
                        </div>
                    </div>
                </div>

                <div class="col m4 s12 center-align">
                    <div class="row">
                        <div class="col m12 s12">
                            <i class="icone material-icons">cloud_queue</i>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col m12 s12">
                            <h3>Olhando para o futuro... <br />PARA CIMA</h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col m12 text-center">
                            <p class="nossosValores">Buscamos entregar Desempenho!
                            Nossa plataforma está nas Nuvens, garantindo o maximo de performance.</p>
                        </div>
                    </div>
                </div>

                <div class="col m4 s12 center-align">
                    <div class="row">
                        <div class="col m12 s12">
                            <i class="icone material-icons">lock_outline</i>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col m12 s12">
                            <h3>Trancado a 7 CHAVES <br /><br /></h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col m12 text-center">
                            <p class="nossosValores">Segurança é o nosso lema!
                            Construimos o PassCenter com enfoque na segurança e integridade dos dados.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
		name: "Home",
        
    }
    $(document).ready(function(){
        $('.sidenav').sidenav();
        
    })
    
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
    margin-top: 20vh;
    width: 55vmax;
}

#logo2{
    width: 90%;
}

#botao{
    position: relative;
    z-index: 1;
    margin-top: 15vh;
    width: 10rem;
}

.sobreNosTexto{
    font-size: 1.8rem;
    text-align: left;
}

.sobreNos{
    margin-top: 15vh;
}

i{
    font-size: 6rem;
}

.icone{
    text-align: center;
}

h3{
    font-size: 2rem;
    font-weight: 900; 
    text-align: center;
}

h1{
    padding: 0vw 0vw 6vw 0vw;
}

.nossosValores{
    font-size: 2rem;
    padding: 0vw 3vw 10vw 3vw;
}

.tamanho{
    padding: 0vw 0vw 10vw 0vw;

}

a{
    text-decoration: none;
    color: white;
}
</style>