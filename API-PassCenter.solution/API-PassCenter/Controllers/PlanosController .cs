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
    public class PlanosController : ApiController {
        [HttpPost, Route("api/Planos")]
        // POST: api/Endereco
        public IHttpActionResult Planos([FromBody]Planos planos) {

            if (autenticar.autenticacao(Request, 1) == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            Planos pla = new Planos();

            pla.Pla_qtd_totens = planos.Pla_qtd_totens;
            pla.Pla_qtd_tags = planos.Pla_qtd_tags;
            pla.Pla_preco_totens = planos.Pla_preco_totens;
            pla.Pla_preco_tags = planos.Pla_preco_tags;
            pla.Pla_estado = pla.Pla_estado;

            int retorno = PlanosDB.Insert(pla);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }

        }
    }
}
