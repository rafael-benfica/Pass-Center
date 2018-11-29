using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes {
    public class Endereco {
        public int End_codigo { get; set; }

        public string End_logradouro { get; set; }

        public string End_numero { get; set; }

        public string End_bairro { get; set; }

        public string End_municipio { get; set; }

        public string End_estado { get; set; }

        public string End_complemento { get; set; }

        public string End_pais { get; set; }

        public TipoEndereco Ten_codigo { get; set; }

    }
}