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
    public class EventosGradesController : ApiController {

        [HttpPost, Route("api/EventosGrades")]
        // POST: api/Instituicoes
        public IHttpActionResult Post([FromBody]EventosGrades eventosGrades) {

            if (autenticar.autenticacao(Request, 3) == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            EventosGrades era = new EventosGrades();

            era.Gra_codigo = eventosGrades.Gra_codigo;
            era.Eau_codigo = eventosGrades.Eau_codigo;

            int retorno = EventosGradesDB.Insert(era);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }
        }
    }
}
