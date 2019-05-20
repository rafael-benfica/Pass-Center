using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes {
    public class HorariosEventos {
        public int Hev_codigo { get; set; }
        public DateTime Hev_data_hora { get; set; }
        public bool Hev_estado { get; set; }
        public string Hev_dia_semana { get; set; }
        public Eventos Eve_codigo { get; set; }

        public Eventos Eventos {
            get {
                throw new System.NotImplementedException();
            }

            set {
            }
        }
    }
}