export default {
    name: 'DashBoardGerenteGeral',
    data () {
        return {
            breadcrumbsLista: []
        }
    },
  
    mounted (){
        this.atualizarListaBreadcrumbs()
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

$(document).ready(function () {
    $('.sidenav').sidenav();
});