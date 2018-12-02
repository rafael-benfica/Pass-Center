using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class PagamentosDB {
        public static int Insert(Pagamentos pagamentos) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO pagamentos(pag_data_criacao, pag_data_vencimento, pag_data_pagamento, ins_codigo, pla_codigo)" +
                    " VALUES(?pag_data_criacao, ?pag_data_vencimento, ?pag_data_pagamento, ?ins_codigo, ?pla_codigo);" +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?pag_data_criacao", pagamentos.Pag_data_criacao));
                objCommand.Parameters.Add(Mapped.Parameter("?pag_data_vencimento", pagamentos.Pag_data_vencimento));
                objCommand.Parameters.Add(Mapped.Parameter("?pag_data_pagamento", pagamentos.Pag_data_pagamento));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", pagamentos.Ins_codigo.Ins_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?pla_codigo", pagamentos.Pla_codigo.Pla_codigo));
                
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