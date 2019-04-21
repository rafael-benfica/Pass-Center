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
        public IHttpActionResult Presencas([FromBody]PresencasProcedure presencas) {

            Indentificacao credenciais = autenticar.autenticacao(Request, 6);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            presencas.vPes_codigo.Pes_codigo = Convert.ToInt32(credenciais.Pes_codigo);

            int retorno = PresencasDB.Insert(presencas);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }

        }
    }
}
