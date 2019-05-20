using API_PassCenter.Models.PasetoToken;
using API_PassCenter.Models.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
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
        
        public IHttpActionResult Post([FromBody]LoginCredenciais login)
        {
            DataSet retorno = LoginCredenciaisDB.Select(login);

            if (retorno.Tables[0].Rows.Count == 0) {
                return Content(HttpStatusCode.Unauthorized, "Combinação de login e senha inválidos!");
            } else {
                string tipoUser;

                if (retorno.Tables[0].Rows[0]["usu_redefinir_senha"].ToString().Equals("1")){
                    tipoUser = "6";
                }
                else
                {
                    tipoUser = retorno.Tables[0].Rows[0]["tus_codigo"].ToString();
                }

                //return Ok(Token.GerarToken(retorno));
                return Ok(new string[] { Token.GerarToken(retorno), tipoUser });
            }


        }

    }
}
