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
    public class UsuariosController : ApiController {
        [HttpPost, Route("api/Usuarios")]
        // POST: api/Endereco
        public IHttpActionResult Usuarios([FromBody]Usuarios usuarios) {

            if (autenticar.autenticacao(Request, 3) == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            Usuarios usu = new Usuarios();

            usu.Usu_login = usuarios.Usu_login;
            usu.Usu_senha = usuarios.Usu_senha;
            usu.Usu_estado = usuarios.Usu_estado;
            usu.Usu_data_criacao = usuarios.Usu_data_criacao;
            usu.Usu_data_desativacao = usuarios.Usu_data_desativacao;
            usu.Usu_primeiro_login = usuarios.Usu_primeiro_login;
            usu.Usu_redefinir_senha = usuarios.Usu_redefinir_senha;
            usu.Pes_codigo = usuarios.Pes_codigo;
            usu.Tus_codigo = usuarios.Tus_codigo;


            int retorno = UsusariosDB.Insert(usu);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }

        }

        [HttpPut, Route("api/Usuarios")]
        // POST: api/Instituicoes
        public IHttpActionResult Put([FromBody]Usuarios usuarios) {

            Indentificacao credenciais = autenticar.autenticacao(Request, 5);

            if (credenciais == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            usuarios.Usu_codigo = Convert.ToInt32(credenciais.Usu_codigo);

            if (UsusariosDB.Update(usuarios) == -2) {
                return BadRequest();
            } else {
                return Ok();
            }
        }

        [HttpPost, Route("api/Usuarios/TiposUsuarios")]
        // POST: api/Endereco
        public IHttpActionResult TiposUsuarios([FromBody]TiposUsuarios tipos_usuarios) {

            if (autenticar.autenticacao(Request, 3) == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            TiposUsuarios tus = new TiposUsuarios();

            tus.Tus_titulo = tipos_usuarios.Tus_titulo;

            if (TiposUsuariosDB.Insert(tus) == 0) {
                return Ok();

            } else {
                return BadRequest();
            }
        }

    }
}
