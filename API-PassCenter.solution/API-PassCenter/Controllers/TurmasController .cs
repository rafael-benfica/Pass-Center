﻿using API_PassCenter.Models.Classes;
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

            if (autenticar.autenticacao(Request, 3) == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            Turmas tur = new Turmas();

            tur.Usu_codigo = turmas.Usu_codigo;
            tur.Eau_codigo = turmas.Eau_codigo;

            int retorno = TurmasDB.Insert(tur);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }
        }
    }
}
