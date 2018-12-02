using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class SessoesDB {
        public static int Insert(Sessoes sessoes) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO sessoes(ses_horario_inicio, ses_horario_fim, tot_codigo, eve_codigo, hev_codigo, tin_codigo)" +
                    " VALUES(?ses_horario_inicio, ?ses_horario_fim, ?tot_codigo, ?eve_codigo, ?hev_codigo, ?tin_codigo);" +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?ses_horario_inicio", sessoes.Ses_horario_inicio));
                objCommand.Parameters.Add(Mapped.Parameter("?ses_horario_fim", sessoes.Ses_horario_fim));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?tot_codigo", sessoes.Tot_codigo.Tot_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?eve_codigo", sessoes.Eve_codigo.Eve_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?hev_codigo", sessoes.Eve_codigo.Eve_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?tin_codigo", sessoes.Tin_codigo.Tin_codigo));
                
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