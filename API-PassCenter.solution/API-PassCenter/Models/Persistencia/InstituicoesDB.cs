using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia
{
    public class InstituicoesDB
    {
        public static int Insert(Instituicoes instituicoes)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO instituicoes(ins_nome_fantasia, ins_razao_social, ins_inscricao_estadual, ins_cnpj, ins_estado, ins_periodo_renovacao_dias, ins_telefone, end_codigo) " +
                    "VALUES(?ins_nome_fantasia, ?ins_razao_social, ?ins_inscricao_estadual, ?ins_cnpj, ?ins_estado, ?ins_periodo_renovacao_dias, ?ins_telefone, ?end_codigo);";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?ins_nome_fantasia", instituicoes.Ins_nome_fantasia));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_razao_social", instituicoes.Ins_razao_social));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_inscricao_estadual", instituicoes.Ins_inscricao_estadual));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_cnpj", instituicoes.Ins_cnpj));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_estado", instituicoes.Ins_estado));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_periodo_renovacao_dias", instituicoes.Ins_periodo_renovacao_dias));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_telefone", instituicoes.Ins_telefone));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?end_codigo", instituicoes.End_codigo.End_codigo));

                retorno = Convert.ToInt32(objCommand.ExecuteScalar());

                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            }
            catch (Exception e)
            {
                retorno = -2;
            }
            return retorno;
        }

        public static int Update(Instituicoes instituicoes)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "UPDATE instituicoes set ins_nome_fantasia = ?ins_nome_fantasia, ins_razao_social = ?ins_razao_social, ins_inscricao_estadual = ?ins_inscricao_estadual, " +
                    "ins_cnpj = ?ins_cnpj, ins_estado=?ins_estado, ins_periodo_renovacao_dias = ?ins_periodo_renovacao_dias, ins_telefone =?ins_telefone "+
                "WHERE ins_codigo = ?ins_codigo;";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", instituicoes.Ins_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_nome_fantasia", instituicoes.Ins_nome_fantasia));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_razao_social", instituicoes.Ins_razao_social));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_inscricao_estadual", instituicoes.Ins_inscricao_estadual));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_cnpj", instituicoes.Ins_cnpj));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_estado", instituicoes.Ins_estado));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_periodo_renovacao_dias", instituicoes.Ins_periodo_renovacao_dias));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_telefone", instituicoes.Ins_telefone));

                retorno = Convert.ToInt32(objCommand.ExecuteScalar());

                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            }
            catch (Exception e)
            {
                retorno = -2;
            }
            return retorno;
        }

        public static int UpdateAtivarDesativar(Instituicoes instituicoes)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "UPDATE instituicoes set ins_estado = ?ins_estado WHERE ins_codigo = ?ins_codigo;";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", instituicoes.Ins_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_estado", instituicoes.Ins_estado));

                retorno = Convert.ToInt32(objCommand.ExecuteScalar());

                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            }
            catch (Exception e)
            {
                retorno = -2;
            }
            return retorno;
        }


        public static DataSet Select()
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select * from instituicoes where ins_codigo != 1;";
            objCommand = Mapped.Command(sql, objConexao);


            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }
        public static DataSet SelectInstituicaoEndereco()
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select * from instituicoes inner join enderecos using(end_codigo) where ins_codigo != 1;";
            objCommand = Mapped.Command(sql, objConexao);


            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }
    }
}