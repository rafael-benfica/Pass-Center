using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes {
    public class Turmas {
        public int Tur_codigo { get; set; }
        public string Tur_periodo_identificacao { get; set; }
        public DateTime Tur_data_abertura { get; set; }
        public DateTime Tur_date_fechamento { get; set; }
        public bool Tur_estado { get; set; }
        public Instituicoes Ins_codigo { get; set; }
        public Eventos Eve_codigo { get; set; }
        public Usuarios Usu_codigo_participante { get; set; }
        public Pessoas Pes_codigo_auditor { get; set; }
    }
}