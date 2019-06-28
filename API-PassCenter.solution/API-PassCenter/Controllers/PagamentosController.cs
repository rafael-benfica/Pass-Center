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
    public class PagamentosController : ApiController {
        [HttpPost, Route("api/Pagamentos")]
        // POST: api/Endereco
        public IHttpActionResult Pagamentos([FromBody]Pagamentos pagamentos) {

            if (autenticar.autenticacao(Request, 1) == null) {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            Planos pla = new Planos();
            pla.Pla_codigo = Convert.ToInt32(PlanosDB.SelectAtivo(pagamentos.Ins_codigo.Ins_codigo).Tables[0].Rows[0]["pla_codigo"]);

            pagamentos.Pla_codigo = pla;

            int retorno = PagamentosDB.Insert(pagamentos);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }

        }


        [HttpGet, Route("api/Pagamentos")]
        // GET: api/Instituicoes
        public IHttpActionResult Get()
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 2);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(PagamentosDB.Select(Convert.ToInt32(credenciais.Ins_codigo)).Tables[0]);
        }

        [HttpGet, Route("api/Pagamentos/ADM")]
        // GET: api/Instituicoes
        public IHttpActionResult GetADM()
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 1);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(PagamentosDB.SelectADM().Tables[0]);
        }


        [HttpPut, Route("api/Pagamentos")]
        // POST: api/Instituicoes
        public IHttpActionResult PutAtivar([FromBody]Pagamentos pagamentos)
        {

            if (autenticar.autenticacao(Request, 1) == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            int retorno = PagamentosDB.UpdateAtivar(pagamentos);

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
