using API_PassCenter.Models.Classes;
using API_PassCenter.Models.ClassesAuxiliares;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia {
    public class UsusariosDB {

        public static int InsertProcedure(UsuarioProcedure usuario)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando


                string sql = "call InserirUsuario(?end_logradouro, ?end_numero, ?end_bairro, ?end_municipio, ?end_cep, ?end_estado, ?end_complemento, ?end_pais, " +
                    "?pes_nome, ?pes_sobrenomes, ?pes_data_nascimento, ?pes_cpf, ?pes_rg, ?pes_matricula, ?pes_sexo, ?pes_tel_residencial, ?pes_tel_celular, ?pes_info_adicionais, ?ins_codigo, " +
                    "?usu_login, ?usu_senha, ?usu_data_criacao, ?tus_codigo, ?gra_codigo);";


                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                //Endereço
                objCommand.Parameters.Add(Mapped.Parameter("?end_logradouro", usuario.End_logradouro));
                objCommand.Parameters.Add(Mapped.Parameter("?end_numero", usuario.End_numero));
                objCommand.Parameters.Add(Mapped.Parameter("?end_bairro", usuario.End_bairro));
                objCommand.Parameters.Add(Mapped.Parameter("?end_municipio", usuario.End_municipio));
                objCommand.Parameters.Add(Mapped.Parameter("?end_cep", usuario.End_cep));
                objCommand.Parameters.Add(Mapped.Parameter("?end_estado", usuario.End_estado));
                objCommand.Parameters.Add(Mapped.Parameter("?end_complemento", usuario.End_complemento));
                objCommand.Parameters.Add(Mapped.Parameter("?end_pais", usuario.End_pais));

                //Pessoa
                objCommand.Parameters.Add(Mapped.Parameter("?pes_nome", usuario.Pes_nome));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_sobrenomes", usuario.Pes_sobrenomes));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_data_nascimento", usuario.Pes_data_nascimento));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_cpf", usuario.Pes_cpf));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_rg", usuario.Pes_rg));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_matricula", usuario.Pes_matricula));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_sexo", usuario.Pes_sexo));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_tel_residencial", usuario.Pes_tel_residencial));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_tel_celular", usuario.Pes_tel_celular));
                objCommand.Parameters.Add(Mapped.Parameter("?pes_info_adicionais", usuario.Pes_info_adicionais));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", usuario.Ins_codigo));

                //Usuário
                objCommand.Parameters.Add(Mapped.Parameter("?usu_login", usuario.Usu_login));
                objCommand.Parameters.Add(Mapped.Parameter("?usu_senha", usuario.Usu_senha));
                objCommand.Parameters.Add(Mapped.Parameter("?usu_data_criacao", usuario.Usu_data_criacao));
                objCommand.Parameters.Add(Mapped.Parameter("?tus_codigo", usuario.Tus_codigo));
                if (usuario.Gra_codigo != 0)
                {
                    objCommand.Parameters.Add(Mapped.Parameter("?gra_codigo", usuario.Gra_codigo));
                }
                else
                {
                    objCommand.Parameters.Add(Mapped.Parameter("?gra_codigo", null));
                }

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

        public static int Insert(Usuarios usuarios) {
            int retorno = 0;
            try {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                
                    string sql = "INSERT INTO usuarios(usu_login, usu_senha, usu_estado, usu_data_criacao, usu_primeiro_login, usu_redefinir_senha, pes_codigo, tus_codigo, gra_codigo)" +
                        " VALUES(?usu_login, ?usu_senha, ?usu_estado, ?usu_data_criacao, ?usu_primeiro_login, true, ?pes_codigo, ?tus_codigo, ?gra_codigo);" +
                        "SELECT LAST_INSERT_ID();";
              
                if (usuarios.Gra_codigo == null)
                {
                    sql = "INSERT INTO usuarios(usu_login, usu_senha, usu_estado, usu_data_criacao, usu_primeiro_login, usu_redefinir_senha, pes_codigo, tus_codigo)" +
                        " VALUES(?usu_login, ?usu_senha, ?usu_estado, ?usu_data_criacao, ?usu_primeiro_login, true, ?pes_codigo, ?tus_codigo);" +
                        "SELECT LAST_INSERT_ID();";
                }
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?usu_login", usuarios.Usu_login));
                objCommand.Parameters.Add(Mapped.Parameter("?usu_senha", usuarios.Usu_senha));
                objCommand.Parameters.Add(Mapped.Parameter("?usu_estado", usuarios.Usu_estado));
                objCommand.Parameters.Add(Mapped.Parameter("?usu_data_criacao", usuarios.Usu_data_criacao));
                objCommand.Parameters.Add(Mapped.Parameter("?usu_primeiro_login", usuarios.Usu_primeiro_login));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo", usuarios.Pes_codigo.Pes_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?tus_codigo", usuarios.Tus_codigo.Tus_codigo));
                if (usuarios.Gra_codigo != null) {
                    objCommand.Parameters.Add(Mapped.Parameter("?gra_codigo", usuarios.Gra_codigo.Gra_codigo));
                }
                retorno = Convert.ToInt32(objCommand.ExecuteScalar());

                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            } catch (Exception e) {
                retorno = -2;
            }
            return retorno;
        }

        public static int Update(Usuarios usuarios)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "UPDATE usuarios SET usu_login = ?usu_login " +
                    "WHERE usu_codigo = ?usu_codigo";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?usu_login", usuarios.Usu_login));
                //WHERE
                objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo", usuarios.Usu_codigo));

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

        public static int UpdateSenha(int Usu_codigo, string Usu_senha)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "UPDATE usuarios SET usu_senha = ?usu_senha, usu_redefinir_senha = '1' " +
                    "WHERE usu_codigo = ?usu_codigo;";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?usu_senha", Usu_senha));
                //WHERE
                objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo", Usu_codigo));

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

        public static int UpdateEsqueciMnhaSenha(string Usu_login, string Usu_senha)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "UPDATE usuarios SET usu_senha = ?usu_senha, usu_redefinir_senha = '1' " +
                    "WHERE usu_login = ?usu_login;";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?usu_senha", Usu_senha));
                //WHERE
                objCommand.Parameters.Add(Mapped.Parameter("?usu_login", Usu_login));

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

        public static int UpdateRedefinirSenha(int Usu_codigo, string Usu_senha)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "UPDATE usuarios SET usu_senha = ?usu_senha, usu_redefinir_senha = '0' " +
                    "WHERE usu_codigo = ?usu_codigo;";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?usu_senha", Usu_senha));
                //WHERE
                objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo", Usu_codigo));

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

        public static DataSet SelectByType(int tipo, int instituicao) {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select * from usuarios inner join pessoas using (pes_codigo)" +
                "inner join enderecos using (end_codigo)" +
                "where tus_codigo = ?tus_codigo and  ins_codigo = ?ins_codigo";
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?tus_codigo", tipo));
            objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", instituicao));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }

        public static DataSet SelectByTypeADM(int tipo)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select * from usuarios inner join pessoas using (pes_codigo)" +
                "inner join enderecos using (end_codigo)" +
                "where tus_codigo = ?tus_codigo;";
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?tus_codigo", tipo));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }
    }
}