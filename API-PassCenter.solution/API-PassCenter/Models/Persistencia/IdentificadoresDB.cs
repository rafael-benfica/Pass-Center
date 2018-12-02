using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class IdentificadoresDB {
        public static int Insert(Identificadores ide) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO identificadores(ide_estado, ide_identificador, usu_codigo, tid_codigo) " +
                    "VALUES(?ide_estado, ?ide_identificador, ?usu_codigo, ?tid_codigo)";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?ide_estado", ide.Ide_estado));
                objCommand.Parameters.Add(Mapped.Parameter("?ide_identificador", ide.Ide_identificador));
                //Fk
                objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo", ide.Usu_codigo.Usu_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?tid_codigo", ide.Tid_codigo.Tid_codigo));
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