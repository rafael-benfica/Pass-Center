using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class UsusariosDB {
        public static int Insert(Usuarios usuarios) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO usuarios(end_logradouro, end_numero, end_bairro, end_municipio, end_estado, end_complemento, end_pais, ten_codigo)" +
                    " VALUES(?end_logradouro, ?end_numero, ?end_bairro, ?end_municipio, ?end_estado, ?end_complemento, ?end_pais, ?ten_codigo);" +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?end_logradouro", usuarios.End_logradouro));
                objCommand.Parameters.Add(Mapped.Parameter("?end_numero", usuarios.End_numero));
                objCommand.Parameters.Add(Mapped.Parameter("?end_bairro", usuarios.End_bairro));
                objCommand.Parameters.Add(Mapped.Parameter("?end_municipio", usuarios.End_municipio));
                objCommand.Parameters.Add(Mapped.Parameter("?end_estado", usuarios.End_estado));
                objCommand.Parameters.Add(Mapped.Parameter("?end_complemento", usuarios.End_complemento));
                objCommand.Parameters.Add(Mapped.Parameter("?end_pais", usuarios.End_pais));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?ten_codigo", usuarios.Ten_codigo.Ten_codigo));
                
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