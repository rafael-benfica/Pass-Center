using API_PassCenter.Models.Classes;
using API_PassCenter.Models.PasetoToken;
using API_PassCenter.Models.Persistencia;
using API_PassCenter.Models.PersistenciaAuxliar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
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
            usu.Usu_estado = true;
            usu.Usu_data_criacao = DateTime.UtcNow; ;
            usu.Usu_primeiro_login = true;
            usu.Usu_redefinir_senha = false;
            usu.Pes_codigo = usuarios.Pes_codigo;
            usu.Tus_codigo = usuarios.Tus_codigo;

            string senha = GeraSenha();

            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(senha);
            byte[] hash = sha512.ComputeHash(bytes);
            usu.Usu_senha = GetStringFromHash(hash);

            int retorno = UsusariosDB.Insert(usu);

            if (retorno == -2)
            {
                return BadRequest();
            }
            else
            {

                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("nao.responder.passcenter@gmail.com", "fatec2019");
                MailMessage mail = new MailMessage();
                mail.Sender = new System.Net.Mail.MailAddress(usu.Usu_login, "Pass Center");
                mail.From = new MailAddress("nao.responder.passcenter@gmail.com", "Pass Center - Não Responder");
                mail.To.Add(new MailAddress(usu.Usu_login, "Você"));
                mail.Subject = "Pass Center";
                mail.Body = "Olá, é um prazer te conhecer!<br/>Bom, para começar, aqui está a sua senha: " + senha + "<br/><br/>Se precisar de alguma ajuda, entre em contato com a gente!<br/>Um grande abraço da Equipe Pass Center =D";
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                try
                {
                    client.Send(mail);
                }
                catch (System.Exception erro)
                {
                    return BadRequest();
                    //trata erro
                }
                finally
                {
                    mail = null;
                }

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

        // PUT: Atualiza a Senha de um usuario. (Token)
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
        // PUT: Atualiza o Login de um usuario (Token)
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


        // PUT: Atualiza o Login de um usuario especifico.
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

        // PUT: Atualiza a senha de um usuario especifico.
        [HttpPut, Route("api/Usuarios/SolicitacaoSenha")]
        public IHttpActionResult PutUserSenhaEspec([FromBody]Usuarios usuarios)
        {

            Indentificacao credenciais = autenticar.autenticacao(Request, 3);

            if (credenciais == null)
            {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            string senha = GeraSenha();

            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(senha);
            byte[] hash = sha512.ComputeHash(bytes);

            usuarios.Usu_senha = GetStringFromHash(hash);


            int retorno = UsusariosDB.Update(usuarios);

            if (retorno == -2)
            {
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("nao.responder.passcenter@gmail.com", "fatec2019");
                MailMessage mail = new MailMessage();
                mail.Sender = new System.Net.Mail.MailAddress(usuarios.Usu_login, "Pass Center");
                mail.From = new MailAddress("nao.responder.passcenter@gmail.com", "Pass Center - Não Responder");
                mail.To.Add(new MailAddress(usuarios.Usu_login, "Você"));
                mail.Subject = "Reposição de Senha - Pass Center";
                mail.Body = "Olá,<br/>Bom, foi solicitada a reposição da senha de acesso, e aqui está a sua senha temporaria: " + senha + "<br/><br/>Se você não solicitou essa reposição, entre em contato com a gente imdiatamente!<br/>Um grande abraço da Equipe Pass Center =D";
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                try
                {
                    client.Send(mail);
                }
                catch (System.Exception erro)
                {
                    return BadRequest();
                    //trata erro
                }
                finally
                {
                    mail = null;
                }

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

        private string GeraSenha()
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@!*_#";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 10)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
        public static string GenerateSHA512String(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString().ToLower();
        }

    }
}
