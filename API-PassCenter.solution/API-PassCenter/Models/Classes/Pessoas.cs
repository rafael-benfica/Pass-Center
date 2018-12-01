using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes {
    public class Pessoas {
        public int Pes_codigo { get; set; }
        public string Pes_nome { get; set; }
        public string Pes_sobrenomes { get; set; }
        public int Pes_sexo { get; set; }
        public string Pes_matricula { get; set; }
        public string Pes_cpf { get; set; }
        public string Pes_rg { get; set; }
        public string Pes_tel_residencial { get; set; }
        public string Pes_tel_celular { get; set; }
        public string Pes_info_adicionais { get; set; }
        public Enderecos End_codigo { get; set; }
        public Instituicoes Ins_codigo { get; set; }
    }
}