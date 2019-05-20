using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes {
    public class Identificadores {
        public int Ide_codigo { get; set; }
        public bool Ide_estado { get; set; }
        public string Ide_identificador { get; set; }
        public Usuarios Usu_codigo { get; set; }
        public TiposIdentificadores Tid_codigo { get; set; }

        public Usuarios Usuarios {
            get {
                throw new System.NotImplementedException();
            }

            set {
            }
        }

        public TiposIdentificadores TiposIdentificadores {
            get {
                throw new System.NotImplementedException();
            }

            set {
            }
        }
    }
}