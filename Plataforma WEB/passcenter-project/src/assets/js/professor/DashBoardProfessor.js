export default {
    name: 'DashBoardProfessor',
    data () {
        return {
            breadcrumbsLista: [],
            nome: "",
            matricula: ""
        }
    },
  
    mounted (){
        this.atualizarListaBreadcrumbs()

        $(document).ready(function () {
            $('.sidenav').sidenav();
        });
        
        this.$http.get('Pessoas').then(response => {

            this.$store.commit('INSERIRMEUSDADOS',response.body);
            var dados = this.$store.state.meusDados.Table[0];

            this.nome = dados.pes_nome + " " + dados.pes_sobrenomes;
            this.matricula = dados.pes_matricula;

          }, response => {
            console.log("ERRO! Código de resposta (HTTP) do servidor: " + response.status);
          });
    },
  
    watch:{
        '$route'(){
            this.atualizarListaBreadcrumbs()
        }
    },
  
    methods: {
        atualizarListaBreadcrumbs(){
            this.breadcrumbsLista = this.$route.meta.breadcrumbs
        },
  
        levarPara(indice){
           if(this.breadcrumbsLista[indice].link) this.$router.push(this.breadcrumbsLista[indice].link)
        }
    }
}  

