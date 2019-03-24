import Vue from 'vue'
import Router from 'vue-router'
import store from './../assets/js/store/store.js'

//DashBoards
import Administrador from '@/components/administrador/DashBoardAdministrador.vue'
import Aluno from '@/components/aluno/DashBoardAluno.vue'
import GerenteCadastro from '@/components/gerenteCadastro/DashBoardGerenteCadastro.vue'
import GerenteGeral from '@/components/gerenteGeral/DashBoardGerenteGeral.vue'
import Professor from '@/components/professor/DashBoardProfessor.vue'

//Gerente Geral
import AlunoGeral from '@/components/gerentes/AlunosGeral.vue'
import DisciplinasGeral from '@/components/gerentes/DisciplinasGeral.vue'
import Financeiro from '@/components/gerenteGeral/Financeiro.vue'
import ProfessoresGeral from '@/components/gerentes/ProfessoresGeral.vue'
import Totens from '@/components/gerenteGeral/Totens.vue'
import TurmasGeral from '@/components/gerentes/TurmasGeral.vue'

//Cadastro
import GerenteCadastroProfessores from '@/components/gerentes/ProfessoresGeral.vue'
import GerenteCadastroTurma from '@/components/gerentes/TurmasGeral.vue'
import GerenteCadastroMateria from '@/components/gerentes/DisciplinasGeral.vue'
import FormularioAluno from '@/components/gerentes/AlunosGeral.vue'

//Geral
import Login from '@/components/geral/Login.vue'
import RedefinirSenha from '@/components/geral/RedefinirSenha.vue'
import EsqueciMinhaSenha from '@/components/geral/EsqueciMinhaSenha.vue'
import Home from '@/components/geral/Home.vue'
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


//Administrador
import AlunoADM from '@/components/gerentes/AlunosGeral.vue'
import DisciplinasADM from '@/components/gerentes/DisciplinasGeral.vue'
import FinanceiroADM from '@/components/gerenteGeral/Financeiro.vue'
import InstituicoesADM from '@/components/administrador/InstituicoesADM.vue'
import ProfessoresADM from '@/components/gerentes/ProfessoresGeral.vue'
import TotensADM from '@/components/gerenteGeral/Totens.vue'
import TurmasADM from '@/components/gerentes/TurmasGeral.vue'


Vue.use(Router)

const rotas = new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/login',
      name: 'Login',
      component: Login
    },
    {
      path: '/EsqueciMinhaSenha',
      name: 'EsqueciMinhaSenha',
      component: EsqueciMinhaSenha
    },
    {
      path: '/RedefinirSenha',
      name: 'RedefinirSenha',
      component: RedefinirSenha,
    },

    //Administrador
    {
      path: '/administrador',
      component: Administrador,
      children: [
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
            { nome: 'Meus nivel' }]
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

    //Gerente Geral
    {
      path: '/gerentegeral',
      component: GerenteGeral,
      children: [
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
          path: 'MeusDadosGerenteGeral',
          name: 'MeusDadosGerenteGeral',
          component: MeusDados,
          meta: {
            breadcrumbs: [{ nome: 'Gerente Geral' },
            { nome: 'Meus nivel' }]
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

    //Gerente Cadastro
    {
      path: '/gerentecadastro',
      component: GerenteCadastro,
      children: [
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
          path: 'MeusDadosGerenteCadastro',
          name: 'MeusDadosGerenteCadastro',
          component: MeusDados,
          meta: {
            breadcrumbs: [{ nome: 'Gerente de Cadastro' },
            { nome: 'Meus nivel' }]
          }
        },
        {
          path: 'GerenteCadastroProfessores',
          name: 'GerenteCadastroProfessores',
          component: ProfessoresGeral,
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

            { nome: 'Turmas' }]
          }
        },
        {
          path: 'GerenteCadastroMateria',
          name: 'GerenteCadastroMateria',
          component: GerenteCadastroMateria,
          meta: {
            breadcrumbs: [{ nome: 'Gerente de Cadastro' },

            { nome: 'Disciplinas' }]
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

    //Professor
    {
      path: '/professor',
      component: Professor,
      children: [
        {
          path: 'MinhasDisciplinasProfessor',
          name: 'MinhasDisciplinasProfessor',
          component: MinhasDisciplinas,
          meta: {
            breadcrumbs: [{ nome: 'Professor' },
            { nome: 'Minhas Disciplinas' }]
          }
        },
        {
          path: 'MeusDados',
          name: 'MeusDadosProfessor',
          component: MeusDados,
          meta: {
            breadcrumbs: [{ nome: 'Professor' },
            { nome: 'Meus nivel' }]
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
    },

    //Aluno
    {
      path: '/aluno',
      component: Aluno,
      children: [
        {
          path: 'MinhasDisciplinasAluno',
          name: 'MinhasDisciplinasAluno',
          component: MinhasDisciplinasAluno,
          meta: {
            breadcrumbs: [{ nome: 'Aluno' },
            { nome: 'Minhas Disciplinas' }]
          }
        },
        {
          path: 'MeusDados',
          name: 'MeusDadosAluno',
          component: MeusDados,
          meta: {
            breadcrumbs: [{ nome: 'Aluno' },
            { nome: 'Meus nivel' }]
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
    }
  ]
})

function encaminhar(nivel, destino) {
  if (nivel == 6) {
    if (destino == "/REDEFINIRSENHA") {
      return true;
    } else {
      return "/redefinirSenha";
    };
  } else if (nivel == 5) {
    if (destino == "/ALUNO") {
      return true;
    } else {
      return "/aluno";
    };
  } else if (nivel == 4) {
    if (destino == "/PROFESSOR") {
      return true;
    } else {
      return "/professor";
    };
  } else if (nivel == 3) {
    if (destino == "/GERENTECADASTRO") {
      return true;
    } else {
      return "/gerenteCadastro";
    };
  } else if (nivel == 2) {
    if (destino == "/GERENTEGERAL") {
      return true;
    } else {
      return "/gerenteGeral";
    };
  } else if (nivel == 1) {
    if (destino == "/ADMINISTRADOR") {
      return true;
    } else {
      return "/administrador";
    };
  } else {
    return true;
  };
}

function getCookie(cname) {
  var name = cname + "=";
  var decodedCookie = decodeURIComponent(document.cookie);
  var ca = decodedCookie.split(";");
  for (var i = 0; i < ca.length; i++) {
    var c = ca[i];
    while (c.charAt(0) == " ") {
      c = c.substring(1);
    }
    if (c.indexOf(name) == 0) {
      return c.substring(name.length, c.length);
    }
  }
  return "/";
}

rotas.beforeEach((to, from, next) => {
  var dest = to.matched[0].path.toUpperCase();

  if (dest != "/" && dest != "" && dest != "/LOGIN" && dest != "/ESQUECIMINHASENHA") {
    if (getCookie("Token") != "/") {
      store.commit("INSERIRTOKEN", getCookie("Token"));
      store.commit("INSERIRTIPOUSER", getCookie("TipoUser"));
      store.commit("CARREGARTOKEN");

      next(encaminhar(parseInt(getCookie("TipoUser")), to.matched[0].path.toUpperCase()));
    } else {

      if(from.matched.length != 0){
        var reme = from.matched[0].path.toUpperCase();
        if (reme != "/" && reme != "" && reme != "/LOGIN" && reme != "/ESQUECIMINHASENHA") {
          store.commit("LOGOUT");
          swal({
            title: "Tempo Esgotado!",
            text:  "A sua sessão de 30 minutos esgotou! Por favor, faça login novamente.",
            type: "info"
          });
        }
      }
      next("/Login");
    }
  } else {
    
    

    next(true);
  }


})

export default rotas;