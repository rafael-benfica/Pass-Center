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

            if (autenticar.autenticacao(Request, 2) == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            Pagamentos pag = new Pagamentos();

            pag.Pag_data_criacao = pagamentos.Pag_data_criacao;
            pag.Pag_data_vencimento = pagamentos.Pag_data_vencimento;
            pag.Pag_data_pagamento = pagamentos.Pag_data_pagamento;
            pag.Ins_codigo = pagamentos.Ins_codigo;
            pag.Pla_codigo = pagamentos.Pla_codigo;

            int retorno = PagamentosDB.Insert(pag);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }

        }
    }
}
