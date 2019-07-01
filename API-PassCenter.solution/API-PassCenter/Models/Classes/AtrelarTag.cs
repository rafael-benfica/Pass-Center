using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes
{
    public class AtrelarTag
    {
        public int Ata_codigo { get; set; }
        public string Ata_identificador { get; set; }
        public Instituicoes Ins_codigo { get; set; }
    }
}