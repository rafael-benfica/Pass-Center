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
                string sql = "INSERT INTO eventos(eve_nome, eve_sigla, eve_descricao, eve_estado, eve_operacao, tev_codigo, ins_codigo)" +
                    " VALUES(?eve_nome, ?eve_sigla, ?eve_descricao, ?eve_estado, ?eve_operacao, ?tev_codigo, ?ins_codigo);" +
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
                objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", eventos.Ins_codigo.Ins_codigo));

                retorno = Convert.ToInt32(objCommand.ExecuteScalar());

                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            } catch (Exception e) {
                retorno = -2;
            }
            return retorno;
        }

        public static DataSet Select(int instituicao, int tipo) {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select * from eventos " +
                "where ins_codigo = ?ins_codigo and tev_codigo = ?tev_codigo";
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", instituicao));
            objCommand.Parameters.Add(Mapped.Parameter("?tev_codigo", tipo));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }

        public static DataSet SelectNome(string nome, int instituicao)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select * from eventos " +
                "where  and ins_codigo = ?ins_codigo";
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?tev_codigo", nome));
            objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", instituicao));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }

        public static DataSet SelectDisciolinasNome(string nome, int instituicao)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select eve_codigo, eve_nome, eve_sigla from eventos where eve_nome like ?eve_nome and ins_codigo = 1 and tev_codigo = 1;";
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?eve_nome", nome));
            objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", instituicao));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }

    }
}