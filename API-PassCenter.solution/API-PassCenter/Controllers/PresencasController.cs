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
    public class PresencasController : ApiController {
        [HttpPost, Route("api/Presencas")]
        // POST: api/Endereco
        public IHttpActionResult Presencas([FromBody]Presencas presencas) {

            if (autenticar.autenticacao(Request, 5) == null) {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            Presencas pre = new Presencas();

            pre.Pre_horario_entrada = presencas.Pre_horario_entrada;
            pre.Pre_horario_saida = presencas.Pre_horario_saida;
            pre.Ide_codigo = presencas.Ide_codigo;
            pre.Ses_codigo = presencas.Ses_codigo;
            pre.Eve_codigo = presencas.Eve_codigo;
            pre.Pre_sessao_automatico = presencas.Pre_sessao_automatico;

            int retorno = PresencasDB.Insert(pre);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }

        }
    }
}
