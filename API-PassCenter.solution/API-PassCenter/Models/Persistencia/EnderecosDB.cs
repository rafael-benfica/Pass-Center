using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class EnderecosDB {
        public static int Insert(Enderecos enderecos) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO enderecos(end_logradouro, end_numero, end_bairro, end_municipio, end_estado, end_complemento, end_pais, ten_codigo)" +
                    " VALUES(?end_logradouro, ?end_numero, ?end_bairro, ?end_municipio, ?end_estado, ?end_complemento, ?end_pais, ?ten_codigo);" +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?end_logradouro", enderecos.End_logradouro));
                objCommand.Parameters.Add(Mapped.Parameter("?end_numero", enderecos.End_numero));
                objCommand.Parameters.Add(Mapped.Parameter("?end_bairro", enderecos.End_bairro));
                objCommand.Parameters.Add(Mapped.Parameter("?end_municipio", enderecos.End_municipio));
                objCommand.Parameters.Add(Mapped.Parameter("?end_estado", enderecos.End_estado));
                objCommand.Parameters.Add(Mapped.Parameter("?end_complemento", enderecos.End_complemento));
                objCommand.Parameters.Add(Mapped.Parameter("?end_pais", enderecos.End_pais));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?ten_codigo", enderecos.Ten_codigo.Ten_codigo));
                
                retorno = Convert.ToInt32(objCommand.ExecuteScalar());

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