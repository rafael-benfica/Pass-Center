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
    public class TiposInsercoesController : ApiController {
        [HttpPost, Route("api/TiposInsercoes")]
        // POST: api/Endereco
        public IHttpActionResult TiposInsercoes([FromBody]TiposInsercoes tiposInsercoes) {

            if (autenticar.autenticacao(Request, 1) == null) {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            TiposInsercoes tin = new TiposInsercoes();

            tin.Tin_titulo = tiposInsercoes.Tin_titulo;

            int retorno = TiposInsercoesDB.Insert(tin);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok();
            }

        }
    }
}
