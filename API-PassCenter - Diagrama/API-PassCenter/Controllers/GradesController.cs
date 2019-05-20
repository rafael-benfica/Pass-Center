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
    public class GradesController : ApiController {

        [HttpPost, Route("api/Grades")]
        // POST: api/Instituicoes
        public IHttpActionResult Post([FromBody]Grades grades) {

            Indentificacao credenciais = autenticar.autenticacao(Request, 3);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            Grades gra = new Grades();

            gra.Gra_nome = grades.Gra_nome;
            gra.Ins_codigo.Ins_codigo = Convert.ToInt32(credenciais.Ins_codigo);

            int retorno = GradesDB.Insert(gra);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }
        }
    }
}
