using API_PassCenter.Models.Classes;
using API_PassCenter.Models.PasetoToken;
using API_PassCenter.Models.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_PassCenter.Controllers {
    public class TotensController : ApiController {

        [HttpPost, Route("api/Totens")]
        // POST: api/Instituicoes
        public IHttpActionResult Post([FromBody]Totens totens) {

            if (autenticar.autenticacao(Request, 2) == null) {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }
            
            Totens tot = new Totens();

            tot.Tot_numero_serie = totens.Tot_numero_serie;
            tot.Tot_estado = totens.Tot_estado;
            tot.Tot_operacao = totens.Tot_operacao;
            tot.Ins_codigo = totens.Ins_codigo;

            int retorno = TotensDB.Insert(tot);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }
        }
        [HttpGet, Route("api/Totens/Disciplinas")]
        // POST: api/Instituicoes
        public IHttpActionResult Disciplinas()
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 4);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(TotensDB.getDisciplinas(Convert.ToInt32(credenciais.Pes_codigo)).Tables[0]);

        }
        [HttpPost, Route("api/Totens/Sessoes")]
        public IHttpActionResult Sessoes([FromBody]Sessoes sessao)
        {

            if (autenticar.autenticacao(Request, 4) == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            Sessoes ses = new Sessoes();

            ses.Eau_codigo = sessao.Eau_codigo;
            ses.Ses_horario_inicio = DateTime.Now;
            //ses.Tot_codigo = sessoes.Tot_codigo;
            ses.Hev_codigo = sessao.Hev_codigo;
            ses.Ses_sessao_automatico = true;
            ses.Tot_codigo = sessao.Tot_codigo;

            int retorno = SessoesDB.Insert(ses);

            if (retorno == -2)
            {
                return BadRequest();
            }
            else
            {
                return Ok(retorno);
            }

        }

    }
}
