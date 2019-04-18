using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class PresencasDB {
        public static int Insert(Presencas presencas) 
            {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO presencas(pre_horario_entrada, pre_horario_saida, ide_codigo, ses_codigo, eve_codigo, Pre_sessao_automatico)" +
                    " VALUES(?pre_horario_entrada, ?pre_horario_saida, ?ide_codigo, ?ses_codigo, ?eve_codigo, ?Pre_sessao_automatico);" +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?pre_horario_entrada", presencas.Pre_horario_entrada));
                objCommand.Parameters.Add(Mapped.Parameter("?pre_horario_saida", presencas.Pre_horario_saida));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?ide_codigo", presencas.Ide_codigo.Ide_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?ses_codigo", presencas.Ses_codigo.Ses_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?eve_codigo", presencas.Eve_codigo.Eve_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?Pre_sessao_automatico", presencas.Pre_sessao_automatico));
                
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