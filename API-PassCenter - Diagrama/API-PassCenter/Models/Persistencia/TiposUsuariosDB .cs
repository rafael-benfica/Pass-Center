using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class TiposUsuariosDB
    {
        public Mapped Mapped {
            get {
                throw new System.NotImplementedException();
            }

            set {
            }
        }

        public static int Insert(TiposUsuarios tus) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO tipos_usuarios(tus_codigo, tus_titulo) VALUES(?tus_codigo, ?tus_titulo)";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?tus_codigo", tus.Tus_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?tus_titulo", tus.Tus_titulo));
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