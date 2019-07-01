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
    public class IdentificadoresController : ApiController {
        [HttpPost, Route("api/Identificadores")]
        // POST: api/Endereco
        public IHttpActionResult Identificadores([FromBody]Identificadores identificadores) {

            if (autenticar.autenticacao(Request, 3) == null) {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            Identificadores ide = new Identificadores();

            ide.Ide_codigo = identificadores.Ide_codigo;
            ide.Ide_estado = true;
            ide.Ide_identificador = identificadores.Ide_identificador;
            ide.Usu_codigo = identificadores.Usu_codigo;
            TiposIdentificadores tid = new TiposIdentificadores();
            tid.Tid_codigo = 1;
            ide.Tid_codigo = tid;

            int retorno = IdentificadoresDB.Insert(ide);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok();
            }

        }

        [HttpPost, Route("api/Identificadores/TiposIdentificadores")]
        // POST: api/Endereco
        public IHttpActionResult TiposIdentificadores([FromBody]TiposIdentificadores tipos_identificadores) {

            if (autenticar.autenticacao(Request, 3) == null) {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            TiposIdentificadores tid = new TiposIdentificadores();

            tid.Tid_titulo = tipos_identificadores.Tid_titulo;

            if (TiposIdentificadoresDB.Insert(tid) == 0) {
                return Ok();

            } else {
                return BadRequest(); return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }
        }

    }
}
