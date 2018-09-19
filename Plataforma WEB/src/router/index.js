import Vue from 'vue'
import Router from 'vue-router'
import MinhasDisciplinas from '@/components/professores/MinhasDisciplinas.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'MinhasDisciplinas',
      component: MinhasDisciplinas,
      meta:{
        breadcrumbs: [{nome: 'Auditor'},
      				        {nome: 'Minhas Disciplinas'}]
      }
    }
  ]
})
