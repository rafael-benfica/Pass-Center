using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia
{
    public class PresencasDB
    {
        public static int Insert(PresencasProcedure presencas)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "call InserirPresenca(?vEau_codigo, ?vPes_codigo, ?list_of_ids, ?vPre_horario_entrada, ?vPre_horario_saida, ?vSes_codigo);";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?vPre_horario_entrada", presencas.Pre_horario_entrada));
                objCommand.Parameters.Add(Mapped.Parameter("?vPre_horario_saida", presencas.Pre_horario_saida));
                objCommand.Parameters.Add(Mapped.Parameter("?list_of_ids", presencas.list_of_ids));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?vEau_codigo", presencas.vEau_codigo.Eau_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?vPes_codigo", presencas.vPes_codigo.Pes_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?vSes_codigo", presencas.Ses_codigo.Ses_codigo));

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

        public static DataSet Select(int ses_codigo)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select concat(pes_nome, ' ', pes_sobrenomes) as 'nomes_concatenados', pes_matricula from presencas " +
                "inner join identificadores using (ide_codigo) " +
                 "inner join usuarios using (usu_codigo) " +
                "inner join pessoas using (pes_codigo) " +
                "where ses_codigo = ?ses_codigo";

            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?ses_codigo", ses_codigo));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }

    }
}