using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes {
    public class Turmas {
        public Usuarios Usu_codigo { get; set; }
        public EventosAuditores Eau_codigo { get; set; }

        public Usuarios Usuarios {
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