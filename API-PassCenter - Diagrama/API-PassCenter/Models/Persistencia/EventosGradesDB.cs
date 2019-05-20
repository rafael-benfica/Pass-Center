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
        public Mapped Mapped {
            get {
                throw new System.NotImplementedException();
            }

            set {
            }
        }

        public static int Insert(EventosGrades eventosgrades)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO grades(gra_codigo, eua_codigo) " +
                    "VALUES(?gra_codigo, ?eua_codigo)" ;
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                //Fk
                objCommand.Parameters.Add(Mapped.Parameter("?gra_codigo", eventosgrades.Gra_codigo.Gra_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?end_codigo", eventosgrades.Eau_codigo.Eau_codigo));

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