using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia
{
    public class IdentificadoresDB
    {
        public static int Insert(Identificadores ide)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "DELETE FROM atrelar_tag where ata_codigo = ?ide_codigo; " +
                    "UPDATE identificadores set ide_estado = false where usu_codigo = ?usu_codigo or ide_identificador = ?ide_identificador; " +
                    "INSERT INTO identificadores(ide_estado, ide_identificador, usu_codigo, tid_codigo) " +
                    "VALUES(?ide_estado, ?ide_identificador, ?usu_codigo, ?tid_codigo)";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?ide_codigo", ide.Ide_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?ide_estado", ide.Ide_estado));
                objCommand.Parameters.Add(Mapped.Parameter("?ide_identificador", ide.Ide_identificador));
                //Fk
                objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo", ide.Usu_codigo.Usu_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?tid_codigo", ide.Tid_codigo.Tid_codigo));
                objCommand.ExecuteNonQuery(); // utilizado quando cdigo não tem retorno, como seria o caso do SELECT
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

        public static DataSet getID(Identificadores ide)
        {

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();
            string sql = "select ide_codigo from identificadores " +
                    "where ide_identificador = ?ide_identificador and ide_estado = true";

            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?ide_identificador", ide.Ide_identificador));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;
        }
    }
}