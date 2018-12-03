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
        public IHttpActionResult Post([FromBody]Instituicoes instituicoes) {

            if (autenticar.autenticacao(Request, 2) == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            Instituicoes ins = new Instituicoes();

            ins.Ins_nome_fantasia = instituicoes.Ins_nome_fantasia;
            ins.Ins_razao_social = instituicoes.Ins_razao_social;
            ins.Ins_inscricao_estadual = instituicoes.Ins_inscricao_estadual;
            ins.Ins_cnpj = instituicoes.Ins_cnpj;
            ins.Ins_estado = instituicoes.Ins_estado;
            ins.Ins_periodo_renovacao_dias = instituicoes.Ins_periodo_renovacao_dias;
            ins.End_codigo = instituicoes.End_codigo;

            int retorno = InstituicoesDB.Insert(ins);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }
        }
    }
}
