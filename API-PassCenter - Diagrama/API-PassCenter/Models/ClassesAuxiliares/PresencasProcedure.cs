using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes {
    public class PresencasProcedure {
        public EventosAuditores vEau_codigo { get; set; }
        public Pessoas vPes_codigo { get; set; }
        public string list_of_ids { get; set; }
        public DateTime Pre_horario_entrada { get; set; }
        public DateTime Pre_horario_saida { get; set; }
        public Sessoes Ses_codigo { get; set; }
        public HorariosEventos Hev_codigo { get; set; }
    }
}