using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class PessoasDB {
        public static int Insert(Pessoas pessoas) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO pessoas(pes_nome, pes_sobrenomes, pes_cpf, pes_rg, pes_matricula, pes_sexo, pes_tel_residencial, pes_tel_celular, pes_info_adicionais, end_codigo, ins_codigo)" +
                    " VALUES(?pes_nome, ?pes_sobrenomes, ?pes_cpf, ?pes_rg, ?pes_matricula, ?pes_sexo, ?pes_tel_residencial, ?pes_tel_celular, ?pes_info_adicionais, ?end_codigo, ?ins_codigo);" +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?pes_nome", pessoas.Pes_nome));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_sobrenomes", pessoas.Pes_sobrenomes));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_cpf", pessoas.Pes_cpf));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_rg", pessoas.Pes_rg));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_matricula", pessoas.Pes_matricula));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_sexo", pessoas.Pes_sexo));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_tel_residencial", pessoas.Pes_tel_residencial));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_tel_celular", pessoas.Pes_tel_celular));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_info_adicionais", pessoas.Pes_info_adicionais));

                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?end_codigo", pessoas.End_codigo.End_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", pessoas.Ins_codigo.Ins_codigo));

                retorno = Convert.ToInt32(objCommand.ExecuteScalar());

                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            } catch (Exception e) {
                retorno = -2;
            }
            return retorno;
        }
        public static DataSet SelectID(int id) {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select * from usuarios inner join pessoas using (pes_codigo)" +
                "inner join enderecos using (end_codigo)" +
                "where pes_codigo = ?pes_codigo";
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo", id));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }

        public static int Update(Pessoas pessoas) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "UPDATE pessoas SET pes_nome = ?pes_nome, pes_sobrenomes = ?pes_sobrenomes," +
                    " pes_cpf = ?pes_cpf, pes_rg = ?pes_rg, pes_matricula = ?pes_matricula, pes_sexo = ?pes_sexo," +
                    " pes_tel_residencial = ?pes_tel_residencial, pes_tel_celular = ?pes_tel_celular," +
                    " pes_info_adicionais = ?pes_info_adicionais  WHERE (pes_codigo = ?pes_codigo)";
                
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?pes_nome", pessoas.Pes_nome));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_sobrenomes", pessoas.Pes_sobrenomes));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_cpf", pessoas.Pes_cpf));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_rg", pessoas.Pes_rg));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_matricula", pessoas.Pes_matricula));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_sexo", pessoas.Pes_sexo));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_tel_residencial", pessoas.Pes_tel_residencial));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_tel_celular", pessoas.Pes_tel_celular));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_info_adicionais", pessoas.Pes_info_adicionais));

                //WHERE
                objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo", pessoas.Pes_codigo));

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