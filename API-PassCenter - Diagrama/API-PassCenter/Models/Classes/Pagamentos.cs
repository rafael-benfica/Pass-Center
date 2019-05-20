using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes {
    public class Pagamentos {
        public int Pag_codigo { get; set; }
        public DateTime Pag_data_criacao { get; set; }
        public DateTime Pag_data_vencimento { get; set; }
        public DateTime Pag_data_pagamento { get; set; }
        public Instituicoes Ins_codigo { get; set; }
        public Planos Pla_codigo { get; set; }

        public Instituicoes Instituicoes {
            get {
                throw new System.NotImplementedException();
            }

            set {
            }
        }

        public Planos Planos {
            get {
                throw new System.NotImplementedException();
            }

            set {
            }
        }
    }
}