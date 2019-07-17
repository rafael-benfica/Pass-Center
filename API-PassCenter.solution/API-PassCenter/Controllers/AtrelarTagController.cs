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

        [HttpPost, Route("api/AtrelarTag")]
        public IHttpActionResult post([FromBody]AtrelarTag ata)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 3);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }
            Instituicoes ins = new Instituicoes();
            ins.Ins_codigo = Convert.ToInt32(credenciais.Ins_codigo);
            ata.Ins_codigo = ins;

            if (AtrelarTagDB.Insert(ata) == 0)
            {
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }

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

        [HttpGet, Route("api/AtrelarTag/ADM")]
        public IHttpActionResult getADM(int ins_codigo)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 1);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }


            return Ok(AtrelarTagDB.Select(ins_codigo).Tables[0]);
        }
    }
}
