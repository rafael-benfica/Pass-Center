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
    public class EnderecoController : ApiController {
        [HttpPost, Route("api/Endereco")]
        // POST: api/Endereco
        public IHttpActionResult Endereco([FromBody]Enderecos endereco) {

            if (autenticar.autenticacao(Request, 5) == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            Enderecos end = new Enderecos();

            end.End_logradouro = endereco.End_logradouro;
            end.End_numero = endereco.End_numero;
            end.End_bairro = endereco.End_bairro;
            end.End_municipio = endereco.End_municipio;
            end.End_estado = endereco.End_estado;
            end.End_complemento = endereco.End_complemento;
            end.End_pais = endereco.End_pais;
            end.Ten_codigo = endereco.Ten_codigo;

            int retorno = EnderecoDB.Insert(end);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }

        }

        [HttpPost, Route("api/Endereco/TipoEndereco")]
        // POST: api/Endereco
        public IHttpActionResult TipoEndereco([FromBody]TiposEnderecos tipo_endereco) {

            if (autenticar.autenticacao(Request, 5) == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            TiposEnderecos tem = new TiposEnderecos();

            tem.Ten_titulo = tipo_endereco.Ten_titulo;

            if (TipoEnderecoDB.Insert(tem) == 0) {
                return Ok();

            } else {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }
        }

    }
}
