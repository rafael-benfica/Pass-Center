using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class TotensDB {
        public static int Insert(Totens totens) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO totens(tot_numero_serie, tot_estado, tot_operacao, ins_codigo)" +
                    " VALUES(?tot_numero_serie, ?tot_estado, ?tot_operacao, ?ins_codigo);" +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?tot_numero_serie", totens.Tot_numero_serie));
                objCommand.Parameters.Add(Mapped.Parameter("?tot_estado", totens.Tot_estado));
                objCommand.Parameters.Add(Mapped.Parameter("?tot_operacao", totens.Tot_operacao));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", totens.Ins_codigo.Ins_codigo));
                
                retorno = Convert.ToInt32(objCommand.ExecuteScalar());

                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            } catch (Exception e) {
                retorno = -2;
            }
            return retorno;
        }

        public static DataSet getDisciplinas(int pes_codigo)
        {
            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select eau_codigo, eve_sigla, eau_periodo_identificacao from eventos_auditores " +
                "inner join eventos using (eve_codigo) " +
                "where pes_codigo = ?pes_codigo and eau_estado = 1";

            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo", pes_codigo));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;
        }
        public static DataSet getTotalDisciplinas(int pes_codigo)
        {
            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select count(eau_codigo) as Total from eventos_auditores " +
                "inner join eventos using (eve_codigo) " +
                "where pes_codigo = ?pes_codigo and eau_estado = 1";

            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo", pes_codigo));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;
        }

    }
}