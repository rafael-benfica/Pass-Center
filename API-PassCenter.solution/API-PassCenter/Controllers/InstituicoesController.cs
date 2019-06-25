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
    public class InstituicoesController : ApiController {

        [HttpPost, Route("api/Instituicoes")]
        // POST: api/Instituicoes
        public IHttpActionResult Post([FromBody]Instituicoes instituicoes)
        {

            if (autenticar.autenticacao(Request, 1) == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            int retorno = InstituicoesDB.Insert(instituicoes);

            if (retorno == -2)
            {
                return BadRequest();
            }
            else
            {
                return Ok(retorno);
            }
        }

        [HttpPut, Route("api/Instituicoes")]
        // POST: api/Instituicoes
        public IHttpActionResult Put([FromBody]Instituicoes instituicoes)
        {

            if (autenticar.autenticacao(Request, 1) == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            int retorno = InstituicoesDB.Update(instituicoes);

            if (retorno == -2)
            {
                return BadRequest();
            }
            else
            {
                return Ok(retorno);
            }
        }


        [HttpGet, Route("api/Instituicoes")]
        // GET: api/Instituicoes
        public IHttpActionResult Get()
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 1);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(InstituicoesDB.Select().Tables[0]);
        }

        [HttpGet, Route("api/Instituicoes/Endereco")]
        // GET: api/Instituicoes
        public IHttpActionResult GetInstituicaoEndereco()
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 1);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(InstituicoesDB.SelectInstituicaoEndereco().Tables[0]);
        }

    }
}
