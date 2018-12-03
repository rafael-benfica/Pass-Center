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
    public class SessoesController : ApiController {
        [HttpPost, Route("api/Sessoes")]
        // POST: api/Endereco
        public IHttpActionResult Sessoes([FromBody]Sessoes sessoes) {

            if (autenticar.autenticacao(Request, 4) == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            Sessoes ses = new Sessoes();

            ses.Ses_horario_inicio = sessoes.Ses_horario_inicio;
            ses.Ses_horario_fim = sessoes.Ses_horario_fim;
            ses.Tot_codigo = sessoes.Tot_codigo;
            ses.Eve_codigo = sessoes.Eve_codigo;
            ses.Hev_codigo = sessoes.Hev_codigo;
            ses.Tin_codigo = sessoes.Tin_codigo;

            int retorno = SessoesDB.Insert(ses);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }

        }
    }
}
