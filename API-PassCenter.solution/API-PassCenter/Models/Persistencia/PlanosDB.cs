using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class PlanosDB {
        public static int Insert(Planos planos) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO planos(pla_qtd_totens, pla_qtd_tags, pla_preco_totens, pla_preco_tags, pla_estado)" +
                    " VALUES(?pla_qtd_totens, ?pla_qtd_tags, ?pla_preco_totens, ?pla_preco_tags, ?pla_estado);" +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?pla_qtd_totens", planos.Pla_qtd_totens));
                objCommand.Parameters.Add(Mapped.Parameter("?pla_qtd_tags", planos.Pla_qtd_tags));
                objCommand.Parameters.Add(Mapped.Parameter("?pla_preco_totens", planos.Pla_preco_totens));
                objCommand.Parameters.Add(Mapped.Parameter("?pla_preco_tags", planos.Pla_qtd_tags));
                objCommand.Parameters.Add(Mapped.Parameter("?pla_estado", planos.Pla_estado));
                
                retorno = Convert.ToInt32(objCommand.ExecuteScalar());

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