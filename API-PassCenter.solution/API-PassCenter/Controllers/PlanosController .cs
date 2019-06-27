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
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            int retorno = PlanosDB.Insert(planos);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }

        }


        [HttpGet, Route("api/Planos")]
        // GET: api/Instituicoes
        public IHttpActionResult Get()
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 1);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(PlanosDB.Select().Tables[0]);
        }

        [HttpPut, Route("api/Planos")]
        // POST: api/Instituicoes
        public IHttpActionResult PutAtivar([FromBody]Planos planos)
        {

            if (autenticar.autenticacao(Request, 1) == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            int retorno = PlanosDB.UpdateAtivar(planos);

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
