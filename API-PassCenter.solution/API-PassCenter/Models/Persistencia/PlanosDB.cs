using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia
{
    public class PlanosDB
    {
        public static int Insert(Planos planos)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando

                string sql = "INSERT INTO planos(pla_qtd_totens, pla_qtd_tags, pla_preco_totens, pla_preco_tags, pla_estado, ins_codigo)" +
                    " VALUES(?pla_qtd_totens, ?pla_qtd_tags, ?pla_preco_totens, ?pla_preco_tags, false, ?ins_codigo);" +
                    "SELECT LAST_INSERT_ID();";

                if (planos.Pla_estado)
                {
                    sql = "UPDATE planos SET pla_estado = false where ins_codigo = ?ins_codigo; " +
                        "INSERT INTO planos(pla_qtd_totens, pla_qtd_tags, pla_preco_totens, pla_preco_tags, pla_estado, ins_codigo)" +
                    " VALUES(?pla_qtd_totens, ?pla_qtd_tags, ?pla_preco_totens, ?pla_preco_tags, true, ?ins_codigo);" +
                    "SELECT LAST_INSERT_ID();";
                }

                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?pla_qtd_totens", planos.Pla_qtd_totens));
                objCommand.Parameters.Add(Mapped.Parameter("?pla_qtd_tags", planos.Pla_qtd_tags));
                objCommand.Parameters.Add(Mapped.Parameter("?pla_preco_totens", planos.Pla_preco_totens));
                objCommand.Parameters.Add(Mapped.Parameter("?pla_preco_tags", planos.Pla_preco_tags));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", planos.Ins_codigo.Ins_codigo));

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

            string sql = "select * from planos inner join instituicoes using(ins_codigo);";
            objCommand = Mapped.Command(sql, objConexao);

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }

        public static DataSet SelectAtivo(int ins)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select pla_codigo from planos where ins_codigo = ?ins_codigo and pla_estado = true;";
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", ins));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }

        public static int UpdateAtivar(Planos planos)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando

                string sql = "UPDATE planos SET pla_estado = false where ins_codigo = ?ins_codigo; " +
                     "UPDATE planos SET pla_estado = true where pla_codigo = ?pla_codigo;";

                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?pla_codigo", planos.Pla_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", planos.Ins_codigo.Ins_codigo));

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


    }
}