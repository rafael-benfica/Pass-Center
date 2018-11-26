using API_PassCenter.Models.PasetoToken;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class UserDB {
        public static int Insert(User User) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO user(nome ,senha) VALUES(?nome, ?senha)";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?nome", User.login));
                objCommand.Parameters.Add(Mapped.Parameter("?senha", User.senha));
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