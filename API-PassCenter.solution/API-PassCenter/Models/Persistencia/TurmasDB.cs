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
                string sql = "INSERT INTO turmas(tur_periodo_identificacao, tur_data_abertura, tur_date_fechamento, tur_estado, ins_codigo, eve_codigo, usu_codigo_participante, pes_codigo_auditor)" +
                    " VALUES(?tur_periodo_identificacao, ?tur_data_abertura, ?tur_date_fechamento, ?tur_estado, ?ins_codigo, ?eve_codigo, ?usu_codigo_participante, ?pes_codigo_auditor);" +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?tur_periodo_identificacao", turmas.Tur_periodo_identificacao));
                objCommand.Parameters.Add(Mapped.Parameter("?tur_data_abertura", turmas.Tur_data_abertura));
                objCommand.Parameters.Add(Mapped.Parameter("?tur_date_fechamento", turmas.Tur_date_fechamento));
                objCommand.Parameters.Add(Mapped.Parameter("?tur_estado", turmas.Tur_estado));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", turmas.Ins_codigo.Ins_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?eve_codigo", turmas.Eve_codigo.Eve_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo_participante", turmas.Usu_codigo_participante.Usu_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo_auditor", turmas.Pes_codigo_auditor.Pes_codigo));

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