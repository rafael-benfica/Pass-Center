export default {
    name: 'DashBoardGerenteCadastro',
    data () {
        return {
            breadcrumbsLista: [],
            disciplinas:[{nome: "ADS"}, {nome: "GTI"}, {nome: "LOG"}, {nome: "GFIN"}, {nome: "GCOM"}, {nome: "GEMP"}]
        }
    },
  
    mounted (){
        this.atualizarListaBreadcrumbs()
        $(document).ready(function () {
            $('.sidenav').sidenav();
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
