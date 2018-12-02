using API_PassCenter.Models.PasetoToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_PassCenter.Controllers
{
    public class TokensController : ApiController
    {
        /// <summary>
        /// Retorna um token para consumo da API.
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        // POST: api/Token
        public IHttpActionResult Post([FromBody]User us)
        {
            if (us.login.Equals("oi") && us.senha.Equals("piu")) {
                
                return Ok(Token.GerarToken());
            }
            return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!");

        }
    }
}
