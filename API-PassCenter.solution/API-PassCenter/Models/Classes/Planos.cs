using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes {
    public class Planos {
        public int Pla_codigo { get; set; }
        public int Pla_qtd_totens { get; set; }
        public int Pla_qtd_tags { get; set; }
        public double Pla_preco_totens { get; set; }
        public double Pla_preco_tags { get; set; }
        public bool Pla_estado { get; set; }
    }
}