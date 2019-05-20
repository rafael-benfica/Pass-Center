using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes {
    public class Eventos {
        public int Eve_codigo { get; set; }
        public string Eve_nome { get; set; }
        public string Eve_sigla { get; set; }
        public string Eve_descricao { get; set; }
        public bool Eve_estado { get; set; }
        public bool Eve_operacao { get; set; }
        public TiposEventos Tev_codigo { get; set; }
        public Instituicoes Ins_codigo { get; set; }

        public TiposEventos TiposEventos {
            get {
                throw new System.NotImplementedException();
            }

            set {
            }
        }
    }
}