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
    public class PresencasController : ApiController {
        [HttpPost, Route("api/Presencas")]
        // POST: api/Endereco
        public IHttpActionResult Presencas([FromBody]PresencasProcedure presencas) {

            Indentificacao credenciais = autenticar.autenticacao(Request, 6);

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
            else{

                presencas.Ses_codigo.Ses_codigo = retornoSessao;

                int retorno = PresencasDB.Insert(presencas);

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

        [HttpGet, Route("api/Presencas/live")]
        // GET: api/Endereco
        public IHttpActionResult GetPresencasLive(int eau_codigo)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 4);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }


            int sessao_id = Convert.ToInt32(SessoesDB.SelectLive(eau_codigo).Tables[0].Rows[0]["ses_codigo"].ToString());

            return Ok(PresencasDB.Select(sessao_id).Tables[0]);

        }

        [HttpGet, Route("api/Presencas")]
        // GET: api/Endereco
        public IHttpActionResult GetPresencas(int ses_codigo)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 4);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(PresencasDB.Select(ses_codigo).Tables[0]);

        }
    }
}
