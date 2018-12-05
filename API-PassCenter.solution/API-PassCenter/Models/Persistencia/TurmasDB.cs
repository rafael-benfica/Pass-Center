using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class TurmasDB {
        public static int Insert(Turmas turmas) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO turmas(usu_codigo_participante, eau_codigo)" +
                    " VALUES(?tur_periodo_identificacao, ?eau_codigo);" +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo_participante", turmas.Usu_codigo.Usu_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo_auditor", turmas.Eau_codigo.Eau_codigo));

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