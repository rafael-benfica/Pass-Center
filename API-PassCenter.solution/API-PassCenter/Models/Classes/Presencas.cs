using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes {
    public class Presencas {
        public int Pre_codigo { get; set; }
        public DateTime Pre_horario_entrada { get; set; }
        public DateTime Pre_horario_saida { get; set; }
        public Identificadores Ide_codigo { get; set; }
        public Sessoes Ses_codigo { get; set; }
        public Eventos Eve_codigo { get; set; }
        public TiposInsercoes Tin_codigo { get; set; }
    }
}