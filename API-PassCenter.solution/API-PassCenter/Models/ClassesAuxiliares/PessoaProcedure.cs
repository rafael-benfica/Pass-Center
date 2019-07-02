using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.ClassesAuxiliares
{
    public class PessoaProcedure
    {
        public int End_codigo { get; set; }
        public string End_logradouro { get; set; }
        public string End_numero { get; set; }
        public string End_bairro { get; set; }
        public string End_municipio { get; set; }
        public string End_cep { get; set; }
        public string End_estado { get; set; }
        public string End_complemento { get; set; }
        public string End_pais { get; set; }
        public int Pes_codigo { get; set; }
        public string Pes_nome { get; set; }
        public string Pes_sobrenomes { get; set; }
        public DateTime Pes_data_nascimento { get; set; }
        public int Pes_sexo { get; set; }
        public string Pes_matricula { get; set; }
        public string Pes_cpf { get; set; }
        public string Pes_rg { get; set; }
        public string Pes_tel_residencial { get; set; }
        public string Pes_tel_celular { get; set; }
        public string Pes_info_adicionais { get; set; }
        public int Ins_codigo { get; set; }
        public int Usu_codigo { get; set; }
        public string Usu_login { get; set; }
        public string Usu_senha { get; set; }
        public bool Usu_estado { get; set; }
        public DateTime Usu_data_criacao { get; set; }
        public DateTime Usu_data_desativacao { get; set; }
        public bool Usu_primeiro_login { get; set; }
        public bool Usu_redefinir_senha { get; set; }
        public int Tus_codigo { get; set; }
        public int Gra_codigo { get; set; }
    }
}