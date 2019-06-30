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
    public class GradesController : ApiController
    {

        [HttpPost, Route("api/Grades")]
        // POST: api/Instituicoes
        public IHttpActionResult Post([FromBody]Grades grades)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 3);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            Instituicoes ins = new Instituicoes();

            ins.Ins_codigo = Convert.ToInt32(credenciais.Ins_codigo);

            grades.Ins_codigo = ins;

            int retorno = GradesDB.Insert(grades);

            if (retorno == -2)
            {
                return BadRequest();
            }
            else
            {
                return Ok(retorno);
            }
        }

        [HttpPut, Route("api/Grades")]
        // POST: api/Instituicoes
        public IHttpActionResult Put([FromBody]Grades grades)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 3);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            Instituicoes ins = new Instituicoes();

            ins.Ins_codigo = Convert.ToInt32(credenciais.Ins_codigo);

            grades.Ins_codigo = ins;

            int retorno = GradesDB.Update(grades);

            if (retorno == -2)
            {
                return BadRequest();
            }
            else
            {
                return Ok(retorno);
            }
        }

        [HttpGet, Route("api/Grades")]
        // GET: api/Instituicoes
        public IHttpActionResult Get()
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 3);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(GradesDB.Select(Convert.ToInt32(credenciais.Ins_codigo)).Tables[0]);
        }

        [HttpDelete, Route("api/Grades")]
        // POST: api/Instituicoes
        public IHttpActionResult Delete(int gra_codigo)
        {

            if (autenticar.autenticacao(Request, 3) == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            int retorno = GradesDB.Delete(gra_codigo);

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
