using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes {
    public class Usuarios {
        public int Usu_codigo { get; set; }
        public string Usu_login { get; set; }
        public string Usu_senha { get; set; }
        public bool Usu_estado { get; set; }
        public DateTime Usu_data_criacao { get; set; }
        public DateTime Usu_data_desativacao { get; set; }
        public bool Usu_primeiro_login { get; set; }
        public bool Usu_redefinir_senha { get; set; }
        public Pessoas Pes_codigo { get; set; }
        public TiposUsuarios Tus_codigo { get; set; }
        public Grades Gra_codigo { get; set; }
    }
}