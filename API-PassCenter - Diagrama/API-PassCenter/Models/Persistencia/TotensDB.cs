using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class TotensDB
    {
        public Mapped Mapped {
            get {
                throw new System.NotImplementedException();
            }

            set {
            }
        }

        public static int Insert(Totens totens) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO totens(tot_numero_serie, tot_estado, tot_operacao, ins_codigo)" +
                    " VALUES(?tot_numero_serie, ?tot_estado, ?tot_operacao, ?ins_codigo);" +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?tot_numero_serie", totens.Tot_numero_serie));
                objCommand.Parameters.Add(Mapped.Parameter("?tot_estado", totens.Tot_estado));
                objCommand.Parameters.Add(Mapped.Parameter("?tot_operacao", totens.Tot_operacao));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", totens.Ins_codigo.Ins_codigo));
                
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