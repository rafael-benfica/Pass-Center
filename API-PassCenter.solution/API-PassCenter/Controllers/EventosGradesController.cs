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

            int retorno = EventosGradesDB.Insert(eventosGrades);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }
        }

        [HttpGet, Route("api/EventosGrades")]
        // GET: api/Instituicoes
        public IHttpActionResult Get(int gra_codigo)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 3);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(EventosGradesDB.Select(Convert.ToInt32(credenciais.Ins_codigo), gra_codigo).Tables[0]);
        }

        [HttpDelete, Route("api/EventosGrades")]
        // POST: api/Instituicoes
        public IHttpActionResult Delete(int eau_codigo, int gra_codigo)
        {

            if (autenticar.autenticacao(Request, 3) == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            int retorno = EventosGradesDB.Delete(eau_codigo, gra_codigo);

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
