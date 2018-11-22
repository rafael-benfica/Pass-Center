import Vue from 'vue'
import Router from 'vue-router'

//DashBoards
import Administrador from '@/components/administrador/DashBoardAdministrador.vue'
import Aluno from '@/components/aluno/DashBoardAluno.vue'
import GerenteCadastro from '@/components/gerenteCadastro/DashBoardGerenteCadastro.vue'
import GerenteGeral from '@/components/gerenteGeral/DashBoardGerenteGeral.vue'
import Professor from '@/components/professor/DashBoardProfessor.vue'

//Geral
import MeusDados from '@/components/geral/MeusDados.vue'

// Aluno
import MinhasDisciplinasAluno from '@/components/aluno/MinhasDisciplinasAluno.vue'

//Professor
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
        },
        {
          path: 'meusdados',
          name: 'MeusDadosAdministrador',
          component: MeusDados,
          meta: {
            breadcrumbs: [{ nome: 'Administrador' },
            { nome: 'Meus Dados' }]
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
          name: 'MinhasDisciplinasAluno',
          component: MinhasDisciplinasAluno,
          meta: {
            breadcrumbs: [{ nome: 'Aluno' },
            { nome: 'Minhas Disciplinas' }]
          }
        },
        {
          path: 'meusdados',
          name: 'MeusDadosAluno',
          component: MeusDados,
          meta: {
            breadcrumbs: [{ nome: 'Aluno' },
            { nome: 'Meus Dados' }]
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
        },
        {
          path: 'meusdados',
          name: 'MeusDadosGerenteCadastro',
          component: MeusDados,
          meta: {
            breadcrumbs: [{ nome: 'Gerente de Cadastro' },
            { nome: 'Meus Dados' }]
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
        },
        {
          path: 'meusdados',
          name: 'MeusDadosGerenteGeral',
          component: MeusDados,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
            { nome: 'Meus Dados' }]
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
        },
        {
          path: 'meusdados',
          name: 'MeusDadosProfessor',
          component: MeusDados,
          meta: {
            breadcrumbs: [{ nome: 'Professor' },
            { nome: 'Meus Dados' }]
          }
        }
      ]
    }
  ]
})
