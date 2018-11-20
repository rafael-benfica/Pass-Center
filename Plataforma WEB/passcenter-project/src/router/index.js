import Vue from 'vue'
import Router from 'vue-router'
import Professor from '@/components/professores/DashBoardProfessor.vue'
import MinhasDisciplinas from '@/components/professores/MinhasDisciplinas.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      component: Professor,
      children:[
        {
          path: '',
          name: 'MinhasDisciplinas',
          component: MinhasDisciplinas,
          meta: {
            breadcrumbs: [{ nome: 'Professor' },
            { nome: 'Minhas Disciplinas' }]
        }
      }
      ]
    }
  ]
})
