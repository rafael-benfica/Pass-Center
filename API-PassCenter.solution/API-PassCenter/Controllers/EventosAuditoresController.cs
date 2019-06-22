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
    public class EventosAuditoresController : ApiController
    {

        [HttpPost, Route("api/EventosAuditores")]
        // POST: api/Instituicoes
        public IHttpActionResult Post([FromBody]EventosAuditores enventosAuditores)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 3);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            var date = DateTime.Now;

            EventosAuditores eau = new EventosAuditores();

            eau.Eau_periodo_identificacao = date.Year.ToString();
            eau.Eau_data_abertura = date;
            eau.Eau_estado = true;

            Instituicoes ins = new Instituicoes();
            ins.Ins_codigo = Convert.ToInt32(credenciais.Ins_codigo);

            eau.Ins_codigo = ins;
            eau.Eve_codigo = enventosAuditores.Eve_codigo;
            eau.Pes_codigo = enventosAuditores.Pes_codigo;

            int retorno = EventosAuditoresDB.Insert(eau);

            if (retorno == -2)
            {
                return BadRequest();
            }
            else
            {
                return Ok(retorno);
            }
        }

        [HttpGet, Route("api/EventosAuditores")]
        // GET: api/Instituicoes
        public IHttpActionResult Get()
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 3);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(EventosAuditoresDB.Select(Convert.ToInt32(credenciais.Ins_codigo)).Tables[0]);
        }

        [HttpGet, Route("api/EventosAuditores/Disciplinas")]
        public IHttpActionResult Disciplinas()
        {
            Indentificacao credenciais = autenticar.autenticacao(Request, 4);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(EventosAuditoresDB.SelectDisciplinas(Convert.ToInt32(credenciais.Pes_codigo)).Tables[0]);
        }

        [HttpGet, Route("api/EventosAuditores/PeriodosIdentificacao")]
        // GET: api/Instituicoes
        public IHttpActionResult GetPeriodosIdentificacao()
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 4);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(EventosAuditoresDB.SelectPeriodosIdentificacao(Convert.ToInt32(credenciais.Pes_codigo)).Tables[0]);
        }

        [HttpGet, Route("api/EventosAuditores/Participantes/PeriodosIdentificacao")]
        // GET: api/Instituicoes
        public IHttpActionResult GetParticipantesPeriodosIdentificacao()
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 5);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(EventosAuditoresDB.SelectParticipantesPeriodosIdentificacao(Convert.ToInt32(credenciais.Pes_codigo)).Tables[0]);
        }

        [HttpGet, Route("api/EventosAuditores/DisciplinasHistorico")]
        // GET: api/Instituicoes
        public IHttpActionResult GetDisciplinasHistorico(string identificacao)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 4);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(EventosAuditoresDB.SelectDisciplinaHistorico(Convert.ToInt32(credenciais.Pes_codigo), identificacao).Tables[0]);
        }

        [HttpGet, Route("api/EventosAuditores/Participantes/DisciplinasHistorico")]
        // GET: api/Instituicoes
        public IHttpActionResult GetParticipantesDisciplinasHistorico(string identificacao)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 5);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(EventosAuditoresDB.SelectParticipantesDisciplinaHistorico(Convert.ToInt32(credenciais.Usu_codigo), identificacao).Tables[0]);
        }
    }
}
