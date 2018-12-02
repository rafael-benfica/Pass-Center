<template>
    <div>
        <div class="grey lighten-3 menu-superior">  
            <a href="#" class="center-align">
                <img src="./../../assets/img/logo.png">
            </a>
        </div>

        
    <div class="container">
        <div class="row">
            <div class="col offset-m4 m4 s12 ajuste">
                <div class="card">
                    <div class="row">
                        <h1 class="login">Login</h1>
                    </div>
                    <form onsubmit="return false">
                        <div class="formulario">
                            <div class="row">
                                <div class="input-field col s12">
                                    <input id="email" v-model="login" type="email" class="validate">
                                    <label for="email">Email</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s12">
                                    <input id="password" v-model="senha" type="password" class="validate">
                                    <label for="password">Senha</label>
                                </div>
                            </div>
                        
                        </div>

                        <div class="card-content">
                            <button class="waves-effect waves-light btn-large" @click="logar()">Entrar</button>
                        </div>
                    </form>
                    
                    <div class="card-action">
                        <a class="esqueciSenha" href="#">Esqueci minha senha</a>
                    </div>
                </div>  
            </div>
        </div>
    </div>     


    </div>
</template>

<script>
    export default {
        name: 'Login',
        data() {
            return {
                login: "",
                senha:""
            }
        },
        methods: {
            vai() {
                if(this.login=="aluno@fatec.com"){
                    this.$router.push("aluno");
                }else if(this.login=="prof@fatec.com"){
                    this.$router.push("professor");
                }else if(this.login=="gg@fatec.com"){
                    this.$router.push("gerenteGeral");
                }else if(this.login=="gc@fatec.com"){
                    this.$router.push("gerenteCadastro");
                }else if(this.login=="adm@fatec.com"){
                    this.$router.push("administrador");
                }
            },
            logar(){
                this.$http.post('https://localhost:51474/api/Tokens', {headers: { 'Access-Control-Allow-Origin' : '*' }, usu_login:this.login , usu_senha:this.senha}).then(response => {

					    // get status
					    console.log(response.status);

					    // get status text
					    console.log(response.statusText);

					    // get 'Expires' header
					    console.log(response.headers.get('Expires'));
					    console.log(response.body);

					    // get body data
					    console.log(response.body);

					}, response => {
					    console.log(response.status);
					});
            }
        },
    }
</script>

<style src="./../../assets/css/geral/Login.css" scoped></style>



