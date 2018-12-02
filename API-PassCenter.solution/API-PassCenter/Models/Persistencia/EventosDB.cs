using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class EventosDB {
        public static int Insert(Eventos eventos) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO eventos(eve_nome, eve_sigla, eve_descricao, eve_estado, eve_operacao, tev_codigo)" +
                    " VALUES(?eve_nome, ?eve_sigla, ?eve_descricao, ?eve_estado, ?eve_operacao, ?tev_codigo);" +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?eve_nome", eventos.Eve_nome));
                objCommand.Parameters.Add(Mapped.Parameter("?eve_sigla", eventos.Eve_sigla));
                objCommand.Parameters.Add(Mapped.Parameter("?eve_descricao", eventos.Eve_descricao));
                objCommand.Parameters.Add(Mapped.Parameter("?eve_estado", eventos.Eve_estado));
                objCommand.Parameters.Add(Mapped.Parameter("?eve_operacao", eventos.Eve_operacao));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?tev_codigo", eventos.Tev_codigo.Tev_codigo));
                
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