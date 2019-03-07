using API_PassCenter.Models.Classes;
using API_PassCenter.Models.PasetoToken;
using API_PassCenter.Models.Persistencia;
using API_PassCenter.Models.PersistenciaAuxliar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_PassCenter.Controllers
{
    public class UsuariosController : ApiController
    {
        [HttpPost, Route("api/Usuarios")]
        // POST: Insere usuarios
        public IHttpActionResult Usuarios([FromBody]Usuarios usuarios)
        {

            if (autenticar.autenticacao(Request, 3) == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            Usuarios usu = new Usuarios();

            usu.Usu_login = usuarios.Usu_login;
            usu.Usu_senha = usuarios.Usu_senha;
            usu.Usu_estado = true;
            usu.Usu_data_criacao = DateTime.UtcNow; ;
            usu.Usu_primeiro_login = true;
            usu.Usu_redefinir_senha = false;
            usu.Pes_codigo = usuarios.Pes_codigo;
            usu.Tus_codigo = usuarios.Tus_codigo;


            int retorno = UsusariosDB.Insert(usu);

            if (retorno == -2)
            {
                return BadRequest();
            }
            else
            {
                return Ok(retorno);
            }

        }

        // POST: Adiciona Tipo de Usuário 
        [HttpPost, Route("api/Usuarios/TiposUsuarios")]
        public IHttpActionResult TiposUsuarios([FromBody]TiposUsuarios tipos_usuarios)
        {

            if (autenticar.autenticacao(Request, 3) == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            TiposUsuarios tus = new TiposUsuarios();

            tus.Tus_titulo = tipos_usuarios.Tus_titulo;

            if (TiposUsuariosDB.Insert(tus) == 0)
            {
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }

        // PUT: Atualiza Dados de um usuario.
        [HttpPut, Route("api/Usuarios/Senha")]
        public IHttpActionResult PutUserSenha([FromBody]Senhas senhas)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 5);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            int user = Convert.ToInt32(credenciais.Usu_codigo);

            string senhaAtualBanco = LoginCredenciaisDB.SelectPorUser(user).Tables[0].Rows[0]["usu_senha"].ToString();

            if (senhaAtualBanco.Equals(senhas.senhaAtual))
            {
                if (senhaAtualBanco.Equals(senhas.senhaNova))
                {
                    return BadRequest();
                }
                else
                {
                    int retorno = UsusariosDB.UpdateSenha(user, senhas.senhaNova);

                    if (retorno == -2)
                    {
                        return BadRequest();
                    }
                    else
                    {
                        return Ok();
                    }
                }


            }
            else
            {
                return BadRequest();
            }


        }

        [HttpPut, Route("api/Usuarios/MeusDados")]
        // PUT: Atualiza os dados do usuario (Token)
        public IHttpActionResult PutMeusDados([FromBody]Usuarios usuarios)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 5);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            usuarios.Usu_codigo = Convert.ToInt32(credenciais.Usu_codigo);

            if (UsusariosDB.Update(usuarios) == -2)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }


        // PUT: Atualiza os dados de um usuario especifico.
        [HttpPut, Route("api/Usuarios")]
        public IHttpActionResult Put([FromBody]Usuarios usuarios)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 3);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            int retorno = UsusariosDB.Update(usuarios);

            if (retorno == -2)
            {
                return BadRequest();
            }
            else
            {
                return Ok(retorno);
            }
        }

        // GET: Retorna usuários por Tipo
        [HttpGet, Route("api/Usuarios/porTipo")]
        public IHttpActionResult selectPorTipo(int tipo)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 3);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            return Ok(UsusariosDB.SelectByType(tipo, Convert.ToInt32(credenciais.Ins_codigo)).Tables[0]);
        }


    }
}
