using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class Horarios_EventosDB {
        public static int Insert(HorariosEventos hev) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO horarios_eventos(hev_data_hora, hev_estado, hev_dia_semana, eau_codigo)" +
                    " VALUES(?hev_data_hora, ?hev_estado, ?hev_dia_semana, ?eve_codigo);" +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?hev_data_hora", hev.Hev_data_hora));
                objCommand.Parameters.Add(Mapped.Parameter("?hev_estado", hev.Hev_estado));
                objCommand.Parameters.Add(Mapped.Parameter("?hev_dia_semana", hev.Hev_dia_semana));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?eau_codigo", hev.Eau_codigo.Eau_codigo));

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