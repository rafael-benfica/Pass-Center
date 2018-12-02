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
    public class identificadoresController : ApiController {
        [HttpPost, Route("api/Identificadores")]
        // POST: api/Endereco
        public IHttpActionResult Identificadores([FromBody]Eventos eventos) {

            if (autenticar.autenticacao(Request, 5) == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            Eventos eve = new Eventos();

            eve.Eve_nome = eventos.Eve_nome;
            eve.Eve_sigla = eventos.Eve_sigla;
            eve.Eve_descricao = eventos.Eve_descricao;
            eve.Eve_estado = eventos.Eve_estado;
            eve.Eve_operacao = eventos.Eve_operacao;
            eve.Tev_codigo = eventos.Tev_codigo;

            int retorno = EventosDB.Insert(eve);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }

        }

        [HttpPost, Route("api/Identificadores/TiposIdentificadores")]
        // POST: api/Endereco
        public IHttpActionResult TiposIdentificadores([FromBody]TiposIdentificadores tiposIdentificadores) {

            if (autenticar.autenticacao(Request, 5) == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            TiposEventos tid = new TiposEventos();

            tid.Tid_titulo = tipo_eventos.Tev_titulo;

            if (TiposEventosDB.Insert(tev) == 0) {
                return Ok();

            } else {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }
        }

    }
}
