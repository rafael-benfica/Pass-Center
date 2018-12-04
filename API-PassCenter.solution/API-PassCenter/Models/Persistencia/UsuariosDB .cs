using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class UsusariosDB {
        public static int Insert(Usuarios usuarios) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO usuarios(usu_login, usu_senha, usu_estado, usu_data_criacao, usu_data_desativacao, usu_primeiro_login, usu_redefinir_senha, pes_codigo, tus_codigo)" +
                    " VALUES(?usu_login, ?usu_senha, ?usu_estado, ?usu_data_criacao, ?usu_data_desativacao, ?usu_primeiro_login, ?usu_redefinir_senha, ?pes_codigo, ?tus_codigo);" +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?usu_login", usuarios.Usu_login));
                objCommand.Parameters.Add(Mapped.Parameter("?usu_senha", usuarios.Usu_senha));
                objCommand.Parameters.Add(Mapped.Parameter("?usu_estado", usuarios.Usu_estado));
                objCommand.Parameters.Add(Mapped.Parameter("?usu_data_criacao", usuarios.Usu_data_criacao));
                objCommand.Parameters.Add(Mapped.Parameter("?usu_data_desativacao", usuarios.Usu_data_desativacao));
                objCommand.Parameters.Add(Mapped.Parameter("?usu_primeiro_login", usuarios.Usu_primeiro_login));
                objCommand.Parameters.Add(Mapped.Parameter("?usu_redefinir_senha", usuarios.Usu_redefinir_senha));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo", usuarios.Pes_codigo.Pes_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?tus_codigo", usuarios.Tus_codigo.Tus_codigo));

                retorno = Convert.ToInt32(objCommand.ExecuteScalar());

                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            } catch (Exception e) {
                retorno = -2;
            }
            return retorno;
        }

        public static int Update(Usuarios usuarios) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "UPDATE usuarios SET usu_login = ?usu_login, usu_senha = ?usu_senha "+
                    "WHERE usu_codigo = ?usu_codigo";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?usu_login", usuarios.Usu_login));
                objCommand.Parameters.Add(Mapped.Parameter("?usu_senha", usuarios.Usu_senha));
                //WHERE
                objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo", usuarios.Usu_codigo));

                objCommand.ExecuteNonQuery(); // utilizado quando cdigo não tem retorno, como seria o caso do SELECT

                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            } catch (Exception e) {
                retorno = -2;
            }
            return retorno;
        }

        public static DataSet SelectByType(int id, int instituicao) {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select * from usuarios inner join pessoas using (pes_codigo)" +
                "where tus_codigo = ?tus_codigo and  ins_codigo = ?ins_codigo";
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?tus_codigo", id));
            objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", instituicao));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }

        public static int UpdateBackup(Usuarios usuarios) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "UPDATE usuarios SET usu_login = ?usu_login, usu_senha = ?usu_senha, " +
                    "usu_estado = ?usu_estado, usu_data_criacao = ?usu_data_criacao, " +
                    "usu_data_desativacao = ?usu_data_desativacao, usu_primeiro_login = ?usu_primeiro_login, " +
                    "usu_redefinir_senha = ?usu_redefinir_senha WHERE usu_codigo = ?usu_codigo";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?usu_login", usuarios.Usu_login));
                objCommand.Parameters.Add(Mapped.Parameter("?usu_senha", usuarios.Usu_senha));
                objCommand.Parameters.Add(Mapped.Parameter("?usu_estado", usuarios.Usu_estado));
                objCommand.Parameters.Add(Mapped.Parameter("?usu_data_criacao", usuarios.Usu_data_criacao));
                objCommand.Parameters.Add(Mapped.Parameter("?usu_data_desativacao", usuarios.Usu_data_desativacao));
                objCommand.Parameters.Add(Mapped.Parameter("?usu_primeiro_login", usuarios.Usu_primeiro_login));
                objCommand.Parameters.Add(Mapped.Parameter("?usu_redefinir_senha", usuarios.Usu_redefinir_senha));
                //WHERE
                objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo", usuarios.Usu_codigo));

                objCommand.ExecuteNonQuery(); // utilizado quando cdigo não tem retorno, como seria o caso do SELECT

                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            } catch (Exception e) {
                retorno = -2;
            }
            return retorno;
        }
    }
}