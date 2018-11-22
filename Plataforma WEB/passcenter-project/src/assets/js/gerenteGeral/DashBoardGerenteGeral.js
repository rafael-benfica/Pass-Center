export default {
    name: 'DashBoardGerenteGeral',
    data () {
        return {
            breadcrumbsLista: []
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

