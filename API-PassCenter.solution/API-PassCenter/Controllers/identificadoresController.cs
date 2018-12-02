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
    public class identificadoresController : ApiController {
        [HttpPost, Route("api/Identificadores")]
        // POST: api/Endereco
        public IHttpActionResult Identificadores([FromBody]Identificadores identificadores) {

            if (autenticar.autenticacao(Request, 5) == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            Identificadores ide = new Identificadores();

            ide.Ide_estado = identificadores.Ide_estado;
            ide.Ide_identificador = identificadores.Ide_identificador;
            ide.Usu_codigo = identificadores.Usu_codigo;
            ide.Tid_codigo = identificadores.Tid_codigo;

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

            if (autenticar.autenticacao(Request, 5) == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            TiposIdentificadores tid = new TiposIdentificadores();

            tid.Tid_titulo = tipos_identificadores.Tid_titulo;

            if (TiposIdentificadoresDB.Insert(tid) == 0) {
                return Ok();

            } else {
                return BadRequest(); return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }
        }

    }
}
