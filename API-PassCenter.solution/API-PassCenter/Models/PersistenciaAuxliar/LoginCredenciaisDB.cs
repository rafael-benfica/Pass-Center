using API_PassCenter.Models.Classes;
using API_PassCenter.Models.PasetoToken;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class LoginCredenciaisDB {
        public static DataSet Select(LoginCredenciais login) {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select usu_codigo, pes_codigo, end_codigo, ins_codigo, tus_codigo from usuarios as a " +
                "inner join pessoas using (pes_codigo) "+
                "inner join tipos_usuarios using (tus_codigo) "+
                "where a.usu_login = ?usu_login and a.usu_senha = ?usu_senha";

            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?usu_login", login.usu_login));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_senha", login.usu_senha));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }
    }
}