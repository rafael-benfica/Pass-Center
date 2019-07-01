using API_PassCenter.Models.Classes;
using API_PassCenter.Models.PasetoToken;
using API_PassCenter.Models.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_PassCenter.Controllers
{
    public class AtrelarTagController : ApiController
    {
        // POST: Adiciona Tipo de Usuário 
        [HttpPost, Route("api/AtrelarTag")]
        public IHttpActionResult post([FromBody]AtrelarTag ata)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 3);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }


            if (AtrelarTagDB.Insert(ata) == 0)
            {
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }

        // POST: Adiciona Tipo de Usuário 
        [HttpGet, Route("api/AtrelarTag")]
        public IHttpActionResult get()
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 3);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }


            return Ok(AtrelarTagDB.Select(Convert.ToInt32(credenciais.Ins_codigo)).Tables[0]);
        }
    }
}
