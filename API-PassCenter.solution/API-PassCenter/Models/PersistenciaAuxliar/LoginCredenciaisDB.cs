using API_PassCenter.Models.Classes;
using API_PassCenter.Models.PasetoToken;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class LoginCredenciaisDB {
        public static DataSet SelectUsuarioSenha(LoginCredenciais login)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select usu_codigo, pes_codigo, p.end_codigo, ins_codigo, tus_codigo, usu_redefinir_senha from usuarios " +
                "inner join pessoas p using(pes_codigo) " +
                "inner join instituicoes using(ins_codigo) "+
                "where usu_login = ?usu_login and usu_senha = ?usu_senha and ins_estado = 1;";

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

        public static DataSet SelectRFID(LoginCredenciais login)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select usu_codigo, pes_codigo, pes_nome, end_codigo, ins_codigo, tus_codigo, usu_redefinir_senha from usuarios " +
                "inner join pessoas using (pes_codigo) " +
                "inner join identificadores using (usu_codigo) " +
                "where ide_identificador = ?usu_login";

            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?usu_login", login.usu_login));

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