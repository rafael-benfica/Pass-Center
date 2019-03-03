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
                string sql = "INSERT INTO turmas(usu_codigo, eau_codigo)" +
                    " VALUES(?usu_codigo, ?eau_codigo);" +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo", turmas.Usu_codigo.Usu_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?eau_codigo", turmas.Eau_codigo.Eau_codigo));

                retorno = Convert.ToInt32(objCommand.ExecuteScalar());

                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            } catch (Exception e) {
                retorno = -2;
            }
            return retorno;
        }

        public static DataSet SelectEAU(int id)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select pes_codigo, concat(pes_nome, ' ', pes_sobrenomes) as 'nomes_concatenados', pes_matricula from turmas " +
                "inner join usuarios using (usu_codigo) "+
                "inner join pessoas using (pes_codigo) where eau_codigo = ?eau_codigo;";

            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?eau_codigo", id));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }
    }
}