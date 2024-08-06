using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pagoenLinea.Models
{
    public class AvisoPago
    {
        public string Socio { get; set; }
        public string Password { get; set; }
        public string Cliente { get; set; }
        public string Identidad { get; set; }
        public string Tipo { get; set; }
        public string Token { get; set; }
        public string CodigoAviso { get; set; }
        public float Valor { get; set; }
        public float Factor { get; set; }
        public string Moneda { get; set; }
    }

}