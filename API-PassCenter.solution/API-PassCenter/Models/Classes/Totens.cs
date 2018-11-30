using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes {
    public class Totens {
        public int Tot_codigo { get; set; }
        public string Tot_numero_serie { get; set; }
        public bool Tot_estado { get; set; }
        public bool Tot_operacao { get; set; }
        public Instituicoes Ins_codigo { get; set; }
    }
}