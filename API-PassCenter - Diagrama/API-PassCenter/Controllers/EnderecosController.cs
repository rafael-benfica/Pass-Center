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
    public class EnderecosController : ApiController {
        [HttpPost, Route("api/Enderecos")]
        // POST: api/Endereco
        public IHttpActionResult Endereco([FromBody]Enderecos endereco) {

            if (autenticar.autenticacao(Request, 3) == null) {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            Enderecos end = new Enderecos();

            end.End_logradouro = endereco.End_logradouro;
            end.End_numero = endereco.End_numero;
            end.End_bairro = endereco.End_bairro;
            end.End_municipio = endereco.End_municipio;
            end.End_cep = endereco.End_cep;
            end.End_estado = endereco.End_estado;
            end.End_complemento = endereco.End_complemento;
            end.End_pais = endereco.End_pais;

            int retorno = EnderecosDB.Insert(end);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }

        }

        [HttpPut, Route("api/Enderecos")]
        // PUT: api/Instituicoes
        public IHttpActionResult Put([FromBody]Enderecos endereco) {

            Indentificacao credenciais = autenticar.autenticacao(Request, 5);

            if (credenciais == null) {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            if (EnderecosDB.Update(endereco) == -2) {
                return BadRequest();
            } else {
                return Ok();
            }
        }

        [HttpPut, Route("api/Enderecos/MeusDados")]
        // PUT: api/Instituicoes
        public IHttpActionResult PutMeusDados([FromBody]Enderecos endereco) {

            Indentificacao credenciais = autenticar.autenticacao(Request, 5);

            if (credenciais == null) {
                return Content(HttpStatusCode.Unauthorized, "Credenciais Invalidas ou Ausentes!");
            }

            endereco.End_codigo = Convert.ToInt32(credenciais.End_codigo);

            if (EnderecosDB.Update(endereco) == -2) {
                return BadRequest();
            } else {
                return Ok();
            }
        }
        
    }
}
