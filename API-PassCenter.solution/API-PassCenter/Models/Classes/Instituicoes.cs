using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes {
    public class Instituicoes {

        public int Ins_codigo { get; set; }
        public string Ins_nome_fantasia { get; set; }
        public string Ins_razao_social { get; set; }
        public string Ins_inscricao_estadual { get; set; }
        public string Ins_cnpj { get; set; }
        public bool Ins_estado { get; set; }
        public int Ins_periodo_renovacao_dias { get; set; }
        public Endereco End_codigo { get; set; }

    }
}