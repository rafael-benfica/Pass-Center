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
    public class EventosController : ApiController {
        [HttpPost, Route("api/Eventos")]
        // POST: api/Endereco
        public IHttpActionResult Eventos([FromBody]Eventos eventos)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 3);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            Eventos eve = new Eventos();

            eve.Eve_nome = eventos.Eve_nome;
            eve.Eve_sigla = eventos.Eve_sigla;
            eve.Eve_descricao = eventos.Eve_descricao;
            eve.Eve_estado = true;
            eve.Tev_codigo = eventos.Tev_codigo;

            Instituicoes ins = new Instituicoes();
            ins.Ins_codigo = Convert.ToInt32(credenciais.Ins_codigo);

            eve.Ins_codigo = ins;

            int retorno = EventosDB.Insert(eve);

            if (retorno == -2)
            {
                return BadRequest();
            }
            else
            {
                return Ok(retorno);
            }

        }

        [HttpPost, Route("api/Eventos/ADM")]
        // POST: api/Endereco
        public IHttpActionResult EventosADM([FromBody]Eventos eventos)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 1);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            int retorno = EventosDB.Insert(eventos);

            if (retorno == -2)
            {
                return BadRequest();
            }
            else
            {
                return Ok(retorno);
            }

        }

        [HttpGet, Route("api/Eventos")]
        // GET: api/Instituicoes
        public IHttpActionResult Get(int tipo)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 5);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(EventosDB.Select(Convert.ToInt32(credenciais.Ins_codigo), tipo).Tables[0]);
        }

        [HttpGet, Route("api/Eventos/ADM")]
        // GET: api/Instituicoes
        public IHttpActionResult GetADM(int tipo)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 5);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(EventosDB.SelectADM(tipo).Tables[0]);
        }

        [HttpPost, Route("api/Eventos/TiposEventos")]
        // POST: api/Endereco
        public IHttpActionResult TiposEventos([FromBody]TiposEventos tipo_eventos) {

            if (autenticar.autenticacao(Request, 3) == null) {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
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
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            HorariosEventos hev = new HorariosEventos();

            hev.Hev_data_hora = horario_eventos.Hev_data_hora;
            hev.Hev_estado = horario_eventos.Hev_estado;
            hev.Hev_dia_semana = horario_eventos.Hev_dia_semana;
            hev.Eau_codigo = horario_eventos.Eau_codigo;


            int retorno = Horarios_EventosDB.Insert(hev);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }

        }

        [HttpGet, Route("api/Eventos/BuscarNomes")]
        // GET: api/Instituicoes
        public IHttpActionResult GetEventosNomes(string nome)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 3);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(EventosDB.SelectDisciplinasNome(("%" + nome + "%"), Convert.ToInt32(credenciais.Ins_codigo)).Tables[0]);
        }

        [HttpGet, Route("api/Eventos/BuscarNomes/ADM")]
        // GET: api/Instituicoes
        public IHttpActionResult GetEventosNomesADM(string nome, int instituicao)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 1);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(EventosDB.SelectDisciplinasNome(("%" + nome + "%"), instituicao).Tables[0]);
        }

    }
}
