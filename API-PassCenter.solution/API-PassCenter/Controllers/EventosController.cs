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
    public class EventosController : ApiController {
        [HttpPost, Route("api/Eventos")]
        // POST: api/Endereco
        public IHttpActionResult Eventos([FromBody]Eventos eventos) {

            if (autenticar.autenticacao(Request, 3) == null) {
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

        [HttpPost, Route("api/Eventos/TiposEventos")]
        // POST: api/Endereco
        public IHttpActionResult TiposEventos([FromBody]TiposEventos tipo_eventos) {

            if (autenticar.autenticacao(Request, 3) == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            TiposEventos tev = new TiposEventos();

            tev.Tev_titulo = tipo_eventos.Tev_titulo;

            if (TiposEventosDB.Insert(tev) == 0) {
                return Ok();

            } else {
                return BadRequest();
            }
        }

        [HttpPost, Route("api/Eventos/HorariosEventos")]
        // POST: api/Endereco
        public IHttpActionResult HorariosEventos([FromBody]HorariosEventos horario_eventos) {

            if (autenticar.autenticacao(Request, 3) == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            HorariosEventos hev = new HorariosEventos();

            hev.Hev_data_hora = horario_eventos.Hev_data_hora;
            hev.Hev_estado = horario_eventos.Hev_estado;
            hev.Hev_dia_semana = horario_eventos.Hev_dia_semana;
            hev.Eve_codigo = horario_eventos.Eve_codigo;


            int retorno = Horarios_EventosDB.Insert(hev);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }

        }

    }
}
