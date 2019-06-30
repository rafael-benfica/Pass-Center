using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia
{
    public class EventosGradesDB
    {
        public static int Insert(EventosGrades eventosgrades)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO eventos_grades(gra_codigo, eau_codigo, egr_estado) " +
                    "VALUES(?gra_codigo, ?eau_codigo, ?egr_estado)";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                //Fk
                objCommand.Parameters.Add(Mapped.Parameter("?gra_codigo", eventosgrades.Gra_codigo.Gra_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?eau_codigo", eventosgrades.Eau_codigo.Eau_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?egr_estado", eventosgrades.egr_estado));

                objCommand.ExecuteNonQuery(); // utilizado quando cdigo não tem retorno, como seria o caso do SELECT
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

        public static DataSet Select(int ins, int gra)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select eau_codigo, eve_nome, eve_sigla , pes_nome, pes_sobrenomes from eventos_grades " +
                "inner join eventos_auditores using(eau_codigo) " +
                "inner join eventos using (eve_codigo) " +
                "inner join grades g using (gra_codigo) " +
                "inner join pessoas using (pes_codigo) " +
                "where g.ins_codigo = ?ins_codigo and gra_codigo = ?gra_codigo";
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", ins));
            objCommand.Parameters.Add(Mapped.Parameter("?gra_codigo", gra));


            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }
        public static int Delete(int gra_codigo, int eau_codigo)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "DELETE FROM eventos_grades where eau_codigo = ?eau_codigo and gra_codigo = ?gra_codigo;";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                //Fk
                objCommand.Parameters.Add(Mapped.Parameter("?gra_codigo", gra_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?eau_codigo", eau_codigo));

                objCommand.ExecuteNonQuery(); // utilizado quando cdigo não tem retorno, como seria o caso do SELECT
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

    }
}