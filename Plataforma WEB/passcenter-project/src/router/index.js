import Vue from 'vue'
import Router from 'vue-router'

//DashBoards
import Administrador from '@/components/administrador/DashBoardAdministrador.vue'
import Aluno from '@/components/aluno/DashBoardAluno.vue'
import GerenteCadastro from '@/components/gerenteCadastro/DashBoardGerenteCadastro.vue'
import GerenteGeral from '@/components/gerenteGeral/DashBoardGerenteGeral.vue'
import Professor from '@/components/professor/DashBoardProfessor.vue'

//Gerente Geral
import AlunoGeral from '@/components/gerenteGeral/AlunoGeral.vue'
import DisciplinasGeral from '@/components/gerenteGeral/DisciplinasGeral.vue'
import Financeiro from '@/components/gerenteGeral/Financeiro.vue'
import ProfessoresGeral from '@/components/gerenteGeral/ProfessoresGeral.vue'
import Totens from '@/components/gerenteGeral/Totens.vue'
import TurmasGeral from '@/components/gerenteGeral/TurmasGeral.vue'

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
import GerenteCadastroProfessores from '@/components/gerenteGeral/ProfessoresGeral.vue'
import GerenteCadastroTurma from '@/components/gerenteGeral/TurmasGeral.vue'
import GerenteCadastroMateria from '@/components/gerenteGeral/DisciplinasGeral.vue'
import FormularioAluno from '@/components/gerenteGeral/AlunoGeral.vue'

//Administrador
import  AlunoADM from '@/components/gerenteGeral/AlunoGeral.vue'
import DisciplinasADM from '@/components/gerenteGeral/DisciplinasGeral.vue'
import FinanceiroADM from '@/components/gerenteGeral/Financeiro.vue'
import InstituicoesADM from '@/components/administrador/InstituicoesADM.vue'
import ProfessoresADM from '@/components/gerenteGeral/ProfessoresGeral.vue'
import TotensADM from '@/components/gerenteGeral/Totens.vue'
import TurmasADM from '@/components/gerenteGeral/TurmasGeral.vue'

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
          path: 'AlunoADM',
          name: 'AlunoADM',
          component: AlunoADM,
          meta: {
            breadcrumbs: [{ nome: 'Administrador' },
              { nome: 'Alunos' }]
            }
        },
        {
          path: 'DisciplinasADM',
          name: 'DisciplinasADM',
          component: DisciplinasADM,
          meta: {
            breadcrumbs: [{ nome: 'Administrador' },
              { nome: 'Disciplinas' }]
          }
        },
        {
          path: 'MeusDados',
          name: 'MeusDadosAdministrador',
          component: MeusDados,
          meta: {
            breadcrumbs: [{ nome: 'Administrador' },
            { nome: 'Meus Dados' }]
          }
        },
        {
          path: 'FinanceiroADM',
          name: 'FinanceiroADM',
          component: FinanceiroADM,
          meta: {
            breadcrumbs: [{ nome: 'Administrador' },
              { nome: 'Financeiro' }]
          }
        },
        {
          path: 'InstituicoesADM',
          name: 'InstituicoesADM',
          component: InstituicoesADM,
          meta: {
            breadcrumbs: [{ nome: 'Administrador' },
              { nome: 'Instituições' }]
          }
        },
        {
          path: 'ProfessoresADM',
          name: 'ProfessoresADM',
          component: ProfessoresADM,
          meta: {
            breadcrumbs: [{ nome: 'Administrador' },
              { nome: 'Professores' }]
          }
        },
        {
          path: 'TotensADM',
          name: 'TotensADM',
          component: TotensADM,
          meta: {
            breadcrumbs: [{ nome: 'Administrador' },
              { nome: 'Totens' }]
          }
        },
        {
          path: 'TurmasADM',
          name: 'TurmasADM',
          component: TurmasADM,
          meta: {
            breadcrumbs: [{ nome: 'Administrador' },
              { nome: 'Turmas' }]
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
          path: 'GerenteCadastroProfessores',
          name: 'GerenteCadastroProfessores',
          component: GerenteCadastroProfessores,
          meta: {
            breadcrumbs: [{ nome: 'Gerente de Cadastro' },
            { nome: 'Professores' }]
          }
        },
        {
          path: 'GerenteCadastroTurma',
          name: 'GerenteCadastroTurma',
          component: GerenteCadastroTurma,
          meta: {
            breadcrumbs: [{ nome: 'Gerente de Cadastro' },
            
              {nome:'Turmas'}]
          }
        },
        {
          path: 'GerenteCadastroMateria',
          name: 'GerenteCadastroMateria',
          component: GerenteCadastroMateria,
          meta: {
            breadcrumbs: [{ nome: 'Gerente de Cadastro' },
            
              { nome:'Disciplinas'}]
          }
        },
        {
          path: 'FormularioAluno',
          name: 'FormularioAluno',
          component: FormularioAluno,
          meta: {
            breadcrumbs: [{ nome: 'Gerente de Cadastro' },
            
            { nome: 'Alunos' },
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
        },
        {
          path: 'AlunoGeral',
          name: 'AlunoGeral',
          component: AlunoGeral,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
              { nome: 'Aluno' }]
          }
        },
        {
          path: 'DisciplinasGeral',
          name: 'DisciplinasGeral',
          component: DisciplinasGeral,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
              { nome: 'Disciplinas' }]
          }
        },
        {
          path: 'Financeiro',
          name: 'Financeiro',
          component: Financeiro,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
              { nome: 'Financeiro' }]
          }
        },
        {
          path: 'ProfessoresGeral',
          name: 'ProfessoresGeral',
          component: ProfessoresGeral,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
              { nome: 'Professores' }]
          }
        },
        {
          path: 'Totens',
          name: 'Totens',
          component: Totens,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
              { nome: 'Totens' }]
          }
        },
        {
          path: 'TurmasGeral',
          name: 'TurmasGeral',
          component: TurmasGeral,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
              { nome: 'Turmas' }]
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
