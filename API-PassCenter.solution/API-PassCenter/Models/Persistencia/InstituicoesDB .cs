using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class InstituicoesDB {
        public static int Insert(Instituicoes instituicoes) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO instituicoes(ins_nome_fantasia, ins_razao_social, ins_inscricao_estadual, ins_cnpj, ins_estado, ins_periodo_renovacao_dias, end_codigo)" +
                    " VALUES(?ins_nome_fantasia, ?ins_razao_social, ?ins_inscricao_estadual, ?ins_cnpj, ?end_estado, ?ins_periodo_renovacao_dias, ?end_codigo);" +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?ins_nome_fantasia", instituicoes.Ins_nome_fantasia));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_razao_social", instituicoes.Ins_razao_social));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_inscricao_estadual", instituicoes.Ins_inscricao_estadual));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_cnpj", instituicoes.Ins_cnpj));
                objCommand.Parameters.Add(Mapped.Parameter("?end_estado", instituicoes.Ins_estado));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_periodo_renovacao_dias", instituicoes.Ins_periodo_renovacao_dias));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?end_codigo", instituicoes.End_codigo.End_codigo));
                
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