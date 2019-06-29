using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes
{
    public class Grades
    {
        public int Gra_codigo { get; set; }
        public string Gra_nome { get; set; }
        public Instituicoes Ins_codigo { get; set; }
        public int Gra_prox_grade { get; set; }
    }
}