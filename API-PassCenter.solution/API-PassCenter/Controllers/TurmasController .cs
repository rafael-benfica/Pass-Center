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
    public class TurmasController : ApiController {

        [HttpPost, Route("api/Turmas")]
        // POST: api/Instituicoes
        public IHttpActionResult Post([FromBody]Turmas turmas) {

            if (autenticar.autenticacao(Request, 5) == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            Turmas tur = new Turmas();

            tur.Tur_periodo_identificacao = turmas.Tur_periodo_identificacao;
            tur.Tur_data_abertura = turmas.Tur_data_abertura;
            tur.Tur_date_fechamento = turmas.Tur_date_fechamento;
            tur.Tur_estado = turmas.Tur_estado;
            tur.Ins_codigo = turmas.Ins_codigo;
            tur.Eve_codigo = turmas.Eve_codigo;
            tur.Usu_codigo_participante = turmas.Usu_codigo_participante;
            tur.Pes_codigo_auditor = turmas.Pes_codigo_auditor;

            int retorno = TurmasDB.Insert(tur);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }
        }
    }
}
