import Vue from 'vue'
import Router from 'vue-router'

//DashBoards
import Administrador from '@/components/administrador/DashBoardAdministrador.vue'
import Aluno from '@/components/aluno/DashBoardAluno.vue'
import GerenteCadastro from '@/components/gerenteCadastro/DashBoardGerenteCadastro.vue'
import GerenteGeral from '@/components/gerenteGeral/DashBoardGerenteGeral.vue'
import Professor from '@/components/professor/DashBoardProfessor.vue'

//Geral
import Login from '@/components/geral/Login.vue'
import MeusDados from '@/components/geral/MeusDados.vue'

// Aluno
import MinhasDisciplinasAluno from '@/components/aluno/MinhasDisciplinasAluno.vue'
import HistoricoCompletoAluno from '@/components/aluno/HistoricoCompletoAluno.vue'
import HistoricoCompletoDisciplinas from '@/components/aluno/HistoricoCompletoDisciplinas.vue'

//Professor
import MinhasDisciplinas from '@/components/professor/MinhasDisciplinas.vue'
import ListaManual from '@/components/professor/ListaManual.vue'
import ListaManual2 from '@/components/professor/ListaManual2.vue'
import ListaManual3 from '@/components/professor/ListaManual3.vue'

//Cadastro
import GerenteCadastroProfessores from '@/components/gerenteCadastro/GerenteCadastroProfessores.vue'
import GerenteCadastroTurma from '@/components/gerenteCadastro/GerenteCadastroTurma.vue'
import GerenteCadastroMateria from '@/components/gerenteCadastro/GerenteCadastroMateria.vue'
import FormularioAluno from '@/components/gerenteCadastro/FormularioAluno.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'Login',
      component: Login
    },
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
          path: '',
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
        },
        {
          path: 'HistoricoCompletoAluno',
          name: 'HistoricoCompletoAluno',
          component: HistoricoCompletoAluno,
          meta: {
            breadcrumbs: [{ nome: 'Aluno' },
              { nome: 'Histórico Completo' }]
          }
        },
        {
          path: 'HistoricoCompletoDisciplinas',
          name: 'HistoricoCompletoDisciplinas',
          component: HistoricoCompletoDisciplinas,
          meta: {
            breadcrumbs: [{ nome: 'Aluno' },
            { nome: 'Histórico Completo' },
              { nome: 'Disciplinas 20XX' }]
          }
        }
      ]
    },


    {
      path: '/gerentecadastro',
      component: GerenteCadastro,
      children:[
        {
          path: 'MinhasDisciplinas2',
          name: 'MinhasDisciplinas2',
          component: MinhasDisciplinas,
          meta: {
            breadcrumbs: [{ nome: 'Gerente de Cadastro' },
            { nome: 'Minhas Disciplinas' }]
          }
        },
        {
          path: '/',
          name: 'MeusDadosGerenteCadastro',
          component: MeusDados,
          meta: {
            breadcrumbs: [{ nome: 'Gerente de Cadastro' },
            { nome: 'Meus Dados' }]
          }
        },
        {
          path: 'Professores',
          name: 'Professores',
          component: GerenteCadastroProfessores,
          meta: {
            breadcrumbs: [{ nome: 'Gerente de Cadastro' },
            { nome: 'Professor' }]
          }
        },
        {
          path: 'GerenteCadastroTurma',
          name: 'GerenteCadastroTurma',
          component: GerenteCadastroTurma,
          meta: {
            breadcrumbs: [{ nome: 'Gerente de Cadastro' },
            { nome: 'Professor' },
              {nome:'Análise e Desenvolvimento de Sistemas'}]
          }
        },
        {
          path: 'GerenteCadastroMateria',
          name: 'GerenteCadastroMateria',
          component: GerenteCadastroMateria,
          meta: {
            breadcrumbs: [{ nome: 'Gerente de Cadastro' },
            { nome: 'Professor' },
            { nome: 'Análise e Desenvolvimento de Sistemas' },
              { nome:'4º ADS'}]
          }
        },
        {
          path: 'FormularioAluno',
          name: 'FormularioAluno',
          component: FormularioAluno,
          meta: {
            breadcrumbs: [{ nome: 'Gerente de Cadastro' },
            { nome: 'Aluno' },
            { nome: 'Análise e Desenvolvimento de Sistemas' },
           ]
          }
        }
       
      ]
    },


    {
      path: '/gerentegeral',
      component: GerenteGeral,
      children:[
        {
          path: 'MinhasDisciplinas3',
          name: 'MinhasDisciplinas3',
          component: MinhasDisciplinas,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
            { nome: 'Minhas Disciplinas' }]
          }
        },
        {
          path: '',
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
          name: 'MinhasDisciplinasProfessor',
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
        },
        {
          path: 'ListaManual',
          name: 'ListaManual',
          component: ListaManual,
          meta: {
            breadcrumbs: [{ nome: 'Professor' },
              { nome: 'Lista de Presença Manual' }]
          }
        },
        {
          path: 'ListaManual2',
          name: 'ListaManual2',
          component: ListaManual2,
          meta: {
            breadcrumbs: [{ nome: 'Professor' },
            { nome: 'Lista de Presença Manual > Interação Humano/Computador' }]
          }
        },
        {
          path: 'ListaManual3',
          name: 'ListaManual3',
          component: ListaManual3,
          meta: {
            breadcrumbs: [{ nome: 'Professor' },
            { nome: 'Lista de Presença Manual > Interação Humano/Computador' }]
          }
        }
      ]
    }
  ]
})
