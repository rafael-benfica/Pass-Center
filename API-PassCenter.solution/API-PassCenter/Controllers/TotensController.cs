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

            if (autenticar.autenticacao(Request, 1) == null) {
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
    }
}
