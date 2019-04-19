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
                string sql = "INSERT INTO grades(gra_codigo, gra_nome, ins_codigo) " +
                    "VALUES(?gra_codigo, ?gra_nome, ?ins_codigo)";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?gra_codigo", gra.Gra_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?gra_nome", gra.Gra_nome));
                //Fk
                objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", gra.Ins_codigo.Ins_codigo));

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