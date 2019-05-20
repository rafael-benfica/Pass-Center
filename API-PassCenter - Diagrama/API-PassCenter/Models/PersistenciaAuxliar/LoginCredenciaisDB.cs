using API_PassCenter.Models.Classes;
using API_PassCenter.Models.PasetoToken;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class LoginCredenciaisDB
    {
        public Mapped Mapped {
            get {
                throw new System.NotImplementedException();
            }

            set {
            }
        }

        public static DataSet Select(LoginCredenciais login)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select usu_codigo, pes_codigo, end_codigo, ins_codigo, tus_codigo, usu_redefinir_senha from usuarios " +
                "inner join pessoas using (pes_codigo) " +
                "where usu_login = ?usu_login and usu_senha = ?usu_senha";

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

        public static DataSet SelectPorUser(int usu_codigo)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select usu_senha from usuarios " +
                "where usu_codigo = ?usu_codigo";

            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo", usu_codigo));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }
    }
}