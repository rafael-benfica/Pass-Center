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
                string sql = "INSERT INTO sessoes(ses_horario_inicio, ses_horario_fim, tot_codigo, eau_codigo, hev_codigo, Ses_sessao_automatico) " +
                    "VALUES(?ses_horario_inicio, ?ses_horario_fim, ?tot_codigo, ?eau_codigo, ?hev_codigo, ?Ses_sessao_automatico); " +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?ses_horario_inicio", sessoes.Ses_horario_inicio));
                objCommand.Parameters.Add(Mapped.Parameter("?ses_horario_fim", sessoes.Ses_horario_fim));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?tot_codigo", sessoes.Tot_codigo.Tot_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?eau_codigo", sessoes.Eau_codigo.Eau_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?hev_codigo", sessoes.Hev_codigo.Hev_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?Ses_sessao_automatico", sessoes.Ses_sessao_automatico));
                
                retorno = Convert.ToInt32(objCommand.ExecuteScalar());

                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            } catch (Exception e) {
                retorno = -2;
            }
            return retorno;
        }

        public static int InsertManual(Sessoes sessoes)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO sessoes(ses_horario_inicio, ses_horario_fim, eau_codigo, hev_codigo, Ses_sessao_automatico) " +
                    "VALUES(?ses_horario_inicio, ?ses_horario_fim, ?eau_codigo, ?hev_codigo, ?Ses_sessao_automatico); " +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?ses_horario_inicio", sessoes.Ses_horario_inicio));
                objCommand.Parameters.Add(Mapped.Parameter("?ses_horario_fim", sessoes.Ses_horario_fim));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?eau_codigo", sessoes.Eau_codigo.Eau_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?hev_codigo", sessoes.Hev_codigo.Hev_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?Ses_sessao_automatico", sessoes.Ses_sessao_automatico));

                retorno = Convert.ToInt32(objCommand.ExecuteScalar());

                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            }
            catch (Exception e)
            {
                retorno = -2;
            }
            return retorno;
        }

        public static DataSet Select(int eau_codigo)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select * from sessoes " +
                "where eau_codigo = ?eau_codigo";

            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?eau_codigo", eau_codigo));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }

        public static DataSet SelectLive(int eau_codigo)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select * from sessoes " +
                "where eau_codigo = ?eau_codigo and ses_horario_fim is null;";

            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?eau_codigo", eau_codigo));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }


    }
}