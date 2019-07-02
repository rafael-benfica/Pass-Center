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

        public static int abreSessao(Sessoes sessoes)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "UPDATE totens SET tot_operacao = 1 WHERE tot_codigo = ?tot_codigo; " +
                    "UPDATE eventos_auditores SET eau_operacao = 1 where eau_codigo = ?eau_codigo; INSERT INTO sessoes(ses_horario_inicio, eau_codigo, hev_codigo, Ses_sessao_automatico) " +
                    "VALUES(?ses_horario_inicio, ?eau_codigo, ?hev_codigo, ?Ses_sessao_automatico); " +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?ses_horario_inicio", sessoes.Ses_horario_inicio));
                objCommand.Parameters.Add(Mapped.Parameter("?tot_codigo", sessoes.Tot_codigo.Tot_codigo));
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

        public static int fechaSessao(Sessoes sessoes)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "update totens set tot_operacao=0 where tot_codigo = (select tot_codigo from sessoes where ses_codigo=?ses_codigo); " +
                    "UPDATE eventos_auditores SET eau_operacao = 0 where eau_codigo = ?eau_codigo; UPDATE sessoes SET ses_horario_fim = ?ses_horario_fim WHERE ses_codigo = ?ses_codigo;";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?ses_horario_fim", sessoes.Ses_horario_fim));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?ses_codigo", sessoes.Ses_codigo)) ;
                objCommand.Parameters.Add(Mapped.Parameter("?eau_codigo", sessoes.Eau_codigo.Eau_codigo));

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
                "where eau_codigo = ?eau_codigo and ses_horario_fim is not null order by ses_horario_fim desc LIMIT 0, 4;";

            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?eau_codigo", eau_codigo));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }
        public static DataSet SelectHistorico(int eau_codigo)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select * from sessoes " +
                "where eau_codigo = ?eau_codigo and ses_horario_fim is not null order by ses_horario_inicio desc;";

            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?eau_codigo", eau_codigo));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }

        public static DataSet historico(int eau_codigo)
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