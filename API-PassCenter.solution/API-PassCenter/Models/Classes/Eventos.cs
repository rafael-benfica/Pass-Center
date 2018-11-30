using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes {
    public class Eventos {
        public int eve_codigo { get; set; }
        public int eve_nome { get; set; }
        public int eve_sigla { get; set; }
        public int eve_descricao { get; set; }
        public bool eve_estado { get; set; }
        public bool eve_operacao { get; set; }
        public int tev_codigo { get; set; }
    }
}