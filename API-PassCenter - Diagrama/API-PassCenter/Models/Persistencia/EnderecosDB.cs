using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class EnderecosDB
    {
        public Mapped Mapped {
            get {
                throw new System.NotImplementedException();
            }

            set {
            }
        }

        public static int Insert(Enderecos enderecos) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO enderecos(end_logradouro, end_numero, end_bairro, end_municipio, end_cep, end_estado, end_complemento, end_pais)" +
                    " VALUES(?end_logradouro, ?end_numero, ?end_bairro, ?end_municipio, ?end_cep, ?end_estado, ?end_complemento, ?end_pais);" +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?end_logradouro", enderecos.End_logradouro));
                objCommand.Parameters.Add(Mapped.Parameter("?end_numero", enderecos.End_numero));
                objCommand.Parameters.Add(Mapped.Parameter("?end_bairro", enderecos.End_bairro));
                objCommand.Parameters.Add(Mapped.Parameter("?end_municipio", enderecos.End_municipio));
                objCommand.Parameters.Add(Mapped.Parameter("?end_cep", enderecos.End_cep));
                objCommand.Parameters.Add(Mapped.Parameter("?end_estado", enderecos.End_estado));
                objCommand.Parameters.Add(Mapped.Parameter("?end_complemento", enderecos.End_complemento));
                objCommand.Parameters.Add(Mapped.Parameter("?end_pais", enderecos.End_pais));
                
                retorno = Convert.ToInt32(objCommand.ExecuteScalar());

                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            } catch (Exception e) {
                retorno = -2;
            }
            return retorno;
        }

        public static int Update(Enderecos enderecos) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "UPDATE enderecos SET end_logradouro = ?end_logradouro, end_numero = ?end_numero, " +
                    "end_bairro = ?end_bairro, end_municipio = ?end_municipio, end_estado = ?end_estado, " +
                    "end_complemento = ?end_complemento WHERE end_codigo = ?end_codigo";

                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?end_logradouro", enderecos.End_logradouro));
                objCommand.Parameters.Add(Mapped.Parameter("?end_numero", enderecos.End_numero));
                objCommand.Parameters.Add(Mapped.Parameter("?end_bairro", enderecos.End_bairro));
                objCommand.Parameters.Add(Mapped.Parameter("?end_municipio", enderecos.End_municipio));
                objCommand.Parameters.Add(Mapped.Parameter("?end_estado", enderecos.End_estado));
                objCommand.Parameters.Add(Mapped.Parameter("?end_complemento", enderecos.End_complemento));
                //WHERE
                objCommand.Parameters.Add(Mapped.Parameter("?end_codigo", enderecos.End_codigo));

                objCommand.ExecuteNonQuery(); // utilizado quando cdigo não tem retorno, como seria o caso do SELECT

                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            } catch (Exception e) {
                retorno = -2;
            }
            return retorno;
        }
    }
}