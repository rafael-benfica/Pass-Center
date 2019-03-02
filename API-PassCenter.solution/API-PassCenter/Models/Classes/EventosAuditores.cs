using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes {
    public class EventosAuditores {
        public int Eau_codigo { get; set; }
        public string Eau_periodo_identificacao { get; set; }
        public DateTime Eau_data_abertura { get; set; }
        public DateTime Eau_date_fechamento { get; set; }
        public bool Eau_estado { get; set; }
        public Instituicoes Ins_codigo { get; set; }
        public Eventos Eve_codigo { get; set; }
        public Pessoas Pes_codigo { get; set; }
    }
}