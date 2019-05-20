using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes {
    public class Sessoes {
        public int Ses_codigo { get; set; }
        public DateTime Ses_horario_inicio { get; set; }
        public DateTime Ses_horario_fim { get; set; }
        public bool Ses_sessao_automatico { get; set; }
        public Totens Tot_codigo { get; set; }
        public EventosAuditores Eau_codigo { get; set; }
        public HorariosEventos Hev_codigo { get; set; }

        public HorariosEventos HorariosEventos {
            get {
                throw new System.NotImplementedException();
            }

            set {
            }
        }

        public Totens Totens {
            get {
                throw new System.NotImplementedException();
            }

            set {
            }
        }

        public EventosAuditores EventosAuditores {
            get {
                throw new System.NotImplementedException();
            }

            set {
            }
        }
    }
}