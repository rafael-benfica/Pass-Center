using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes {
    public class Turmas {
        public int Tur_codigo { get; set; }
        public Usuarios Usu_codigo { get; set; }
        public EventosAuditores Eau_codigo { get; set; }
    }
}