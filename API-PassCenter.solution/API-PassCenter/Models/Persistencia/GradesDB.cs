using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia
{
    public class GradesDB
    {
        public static int Insert(Grades gra)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando

                string sql = "INSERT INTO grades(gra_codigo, gra_nome, ins_codigo, gra_prox_grade) " +
                        "VALUES(?gra_codigo, ?gra_nome, ?ins_codigo, ?gra_prox_grade)";

                if (gra.Gra_prox_grade == 0)
                {
                    sql = "INSERT INTO grades(gra_codigo, gra_nome, ins_codigo) " +
                       "VALUES(?gra_codigo, ?gra_nome, ?ins_codigo)";
                }

                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?gra_codigo", gra.Gra_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?gra_nome", gra.Gra_nome));
                //Fk
                objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", gra.Ins_codigo.Ins_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?Gra_prox_grade", gra.Gra_prox_grade));

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

        public static int Update(Grades gra)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando

                string sql = "UPDATE grades SET gra_nome = ?gra_nome, ins_codigo = ?ins_codigo, gra_prox_grade = ?gra_prox_grade where gra_codigo = ?gra_codigo;";

                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?gra_codigo", gra.Gra_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?gra_nome", gra.Gra_nome));
                //Fk
                objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", gra.Ins_codigo.Ins_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?Gra_prox_grade", gra.Gra_prox_grade));

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


        public static DataSet Select(int ins)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select a.gra_codigo, a.gra_nome, a.gra_prox_grade, b.gra_nome as 'gra_prox_grade_nome' from grades a left join grades b on a.gra_prox_grade=b.gra_codigo where a.ins_codigo = ?ins_codigo";
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", ins));


            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }

    }
}