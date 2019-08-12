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
    public class PresencasController : ApiController
    {
        [HttpPost, Route("api/Presencas")]
        // POST: api/Endereco
        public IHttpActionResult Presencas([FromBody]PresencasProcedure presencas)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 4);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            //Seessao
            Sessoes ses = new Sessoes();
            ses.Eau_codigo = presencas.vEau_codigo;
            ses.Ses_horario_inicio = presencas.Pre_horario_entrada;
            ses.Ses_horario_fim = presencas.Pre_horario_saida;
            ses.Ses_sessao_automatico = false;
            ses.Hev_codigo = presencas.Hev_codigo;
            presencas.Ses_codigo = ses;

            //Presenca
            Pessoas pes = new Pessoas();
            pes.Pes_codigo = Convert.ToInt32(credenciais.Pes_codigo);
            presencas.vPes_codigo = pes;


            //DB

            int retornoSessao = SessoesDB.InsertManual(ses);

            if (retornoSessao == -2)
            {
                return BadRequest();
            }
            else
            {

                presencas.Ses_codigo.Ses_codigo = retornoSessao;

                int retorno = PresencasDB.InsertPresencaProcedure(presencas);

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

        [HttpPost, Route("api/Presencas/Manuais")]
        // POST: api/Endereco
        public IHttpActionResult adicionaParticipante([FromBody]Presencas presencas)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 4);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            presencas.Pre_horario_saida = presencas.Pre_horario_entrada = DateTime.Now;

            presencas.Pre_sessao_automatico = false;

            int retorno = PresencasDB.InsertPresenca(presencas);

            if (retorno == -2)
            {
                return BadRequest();
            }
            else
            {
                return Ok(retorno);
            }



        }

        [HttpDelete, Route("api/Presencas/Manuais")]
        // POST: api/Endereco
        public IHttpActionResult removeParticipante(int ses_codigo, int ide_codigo)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 4);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            Presencas presencas = new Presencas();

            presencas.Ses_codigo = new Sessoes();

            presencas.Ses_codigo.Ses_codigo = ses_codigo;

            presencas.Ide_codigo = new Identificadores();
            presencas.Ide_codigo.Ide_codigo = ide_codigo;

            int retorno = PresencasDB.deletePresenca(presencas);

            if (retorno == -2)
            {
                return BadRequest();
            }
            else
            {
                return Ok(retorno);
            }



        }

        [HttpGet, Route("api/Presencas/live")]
        // GET: api/Endereco
        public IHttpActionResult GetPresencasLive(int eau_codigo)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 4);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            try { 
            int ses_codigo = Convert.ToInt32(SessoesDB.SelectLive(eau_codigo).Tables[0].Rows[0]["ses_codigo"].ToString());

            return Ok(PresencasDB.Select(ses_codigo, eau_codigo).Tables[0]);
            }
            catch {
                return Content(HttpStatusCode.Gone, "Esta sessão foi encerrada!");
            }
        }

        [HttpGet, Route("api/Presencas")]
        // GET: api/Endereco
        public IHttpActionResult GetPresencas(int ses_codigo, int eau_codigo)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 4);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(PresencasDB.Select(ses_codigo, eau_codigo).Tables[0]);

        }


        [HttpGet, Route("api/Presencas/Relatorio")]
        // GET: api/Endereco
        public IHttpActionResult GetPresencasRelatorio(int eau_codigo)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 4);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(PresencasDB.SelectPresencasRelatorio(eau_codigo).Tables[0]);

        }

        [HttpGet, Route("api/Presencas/Participante")]
        // GET: api/Endereco
        public IHttpActionResult GetPresencas()
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 5);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(PresencasDB.SelectPresencas(Convert.ToInt32(credenciais.Usu_codigo)).Tables[0]);

        }


        [HttpGet, Route("api/Presencas/Participante/diasFaltas")]
        // GET: api/Endereco
        public IHttpActionResult GetPresencasDiasFaltas(int eau_codigo)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 5);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(PresencasDB.SelectPresencasDiasFaltas(Convert.ToInt32(credenciais.Usu_codigo), eau_codigo).Tables[0]);

        }

        [HttpGet, Route("api/Presencas/Participante/PorPeriodoIdentificacao")]
        // GET: api/Endereco
        public IHttpActionResult GetPresencasPorPeriodoIdentificacao(string eau_periodo_identificacao)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 5);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(PresencasDB.SelectPresencasPorPeriodoIdentificacao(eau_periodo_identificacao, Convert.ToInt32(credenciais.Usu_codigo)).Tables[0]);

        }
    }
}
