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
    public class EnventosAuditoresController : ApiController {

        [HttpPost, Route("api/EnventosAuditores")]
        // POST: api/Instituicoes
        public IHttpActionResult Post([FromBody]EnventosAuditores enventosAuditores) {

            Indentificacao credenciais = autenticar.autenticacao(Request, 3);

            if (credenciais == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            EnventosAuditores eau = new EnventosAuditores();

            eau.Eau_periodo_identificacao = enventosAuditores.Eau_periodo_identificacao;
            eau.Eau_data_abertura = enventosAuditores.Eau_data_abertura;
            eau.Eau_estado = true;

            Instituicoes ins = new Instituicoes();
            ins.Ins_codigo = Convert.ToInt32(credenciais.Ins_codigo);

            eau.Ins_codigo = ins;
            eau.Eve_codigo = enventosAuditores.Eve_codigo;
            eau.Pes_codigo = enventosAuditores.Pes_codigo;

            int retorno = EnventosAuditoresDB.Insert(eau);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }
        }

        [HttpGet, Route("api/EnventosAuditores")]
        // GET: api/Instituicoes
        public IHttpActionResult Get() {

            Indentificacao credenciais = autenticar.autenticacao(Request, 5);

            if (credenciais == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            return Ok(EnventosAuditoresDB.Select(Convert.ToInt32(credenciais.Ins_codigo)).Tables[0]);
        }
    }
}
