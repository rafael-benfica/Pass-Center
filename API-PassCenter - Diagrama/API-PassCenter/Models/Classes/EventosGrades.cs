using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes
{
    public class EventosGrades
    {
        public Grades Gra_codigo { get; set; }
        public EventosAuditores Eau_codigo { get; set; }

        public EventosAuditores EventosAuditores {
            get {
                throw new System.NotImplementedException();
            }

            set {
            }
        }

        public Grades Grades {
            get {
                throw new System.NotImplementedException();
            }

            set {
            }
        }
    }
}