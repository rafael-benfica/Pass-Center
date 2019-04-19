using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class EventosAuditoresDB {
        public static int Insert(EventosAuditores eau) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO eventos_auditores (eau_periodo_identificacao, eau_estado, eau_data_abertura, pes_codigo, eve_codigo, ins_codigo)" +
                    " VALUES(?eau_periodo_identificacao, ?eau_estado, ?eau_data_abertura, ?pes_codigo, ?eve_codigo, ?ins_codigo);" +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?eau_periodo_identificacao", eau.Eau_periodo_identificacao));
                objCommand.Parameters.Add(Mapped.Parameter("?eau_estado", eau.Eau_estado));
                objCommand.Parameters.Add(Mapped.Parameter("?eau_data_abertura", eau.Eau_data_abertura));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo", eau.Pes_codigo.Pes_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?eve_codigo", eau.Eve_codigo.Eve_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", eau.Ins_codigo.Ins_codigo));

                retorno = Convert.ToInt32(objCommand.ExecuteScalar());

                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            } catch (Exception e) {
                retorno = -2;
            }
            return retorno;
        }

        public static DataSet Select(int instituicao) {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select * from eventos_auditores " +
                "inner join pessoas using (pes_codigo) " +
                "inner join eventos using (eve_codigo) " +
                "where pessoas.ins_codigo = ?ins_codigo";
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", instituicao));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }
    }
}