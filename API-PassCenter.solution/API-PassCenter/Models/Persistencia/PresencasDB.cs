using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class PresencasDB {
        public static int Insert(PresencasProcedure presencas) 
            {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "call InserirPresenca(?vEau_codigo, vPes_codigo, ?list_of_ids, ?vPre_horario_entrada, ?vPre_horario_saida, ?vSes_codigo);";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?pre_horario_entrada", presencas.Pre_horario_entrada));
                objCommand.Parameters.Add(Mapped.Parameter("?pre_horario_saida", presencas.Pre_horario_saida));
                objCommand.Parameters.Add(Mapped.Parameter("?list_of_ids", presencas.Pre_horario_saida));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?vEau_codigo", presencas.Ses_codigo.Ses_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?vPes_codigo", presencas.Ses_codigo.Ses_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?ses_codigo", presencas.Ses_codigo.Ses_codigo));

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