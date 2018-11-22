import Vue from 'vue'
import Router from 'vue-router'
import Administrador from '@/components/administrador/DashBoardAdministrador.vue'
import Aluno from '@/components/aluno/DashBoardAluno.vue'
import GerenteCadastro from '@/components/gerenteCadastro/DashBoardGerenteCadastro.vue'
import GerenteGeral from '@/components/gerenteGeral/DashBoardGerenteGeral.vue'
import Professor from '@/components/professor/DashBoardProfessor.vue'
import MinhasDisciplinas from '@/components/professor/MinhasDisciplinas.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
    path: '/administrador',
    component: Administrador,
    children:[
      {
        path: '',
        name: 'MinhasDisciplinas',
        component: MinhasDisciplinas,
        meta: {
          breadcrumbs: [{ nome: 'Administrador' },
          { nome: 'Minhas Disciplinas' }]
      }
    }
    ]
  },
    {
      path: '/aluno',
      component: Aluno,
      children:[
        {
          path: '',
          name: 'MinhasDisciplinas',
          component: MinhasDisciplinas,
          meta: {
            breadcrumbs: [{ nome: 'Aluno' },
            { nome: 'Minhas Disciplinas' }]
        }
      }
      ]
    },
    {
      path: '/gerentecadastro',
      component: GerenteCadastro,
      children:[
        {
          path: '',
          name: 'MinhasDisciplinas2',
          component: MinhasDisciplinas,
          meta: {
            breadcrumbs: [{ nome: 'Gerente de Cadastro' },
            { nome: 'Minhas Disciplinas' }]
        }
      }
      ]
    },
    {
      path: '/gerentegeral',
      component: GerenteGeral,
      children:[
        {
          path: '',
          name: 'MinhasDisciplinas2',
          component: MinhasDisciplinas,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
            { nome: 'Minhas Disciplinas' }]
        }
      }
      ]
    },
    {
      path: '/professor',
      component: Professor,
      children:[
        {
          path: '',
          name: 'MinhasDisciplinas2',
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
