﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pagoenLinea.Models
{
    public class AvisoPago
    {
        public string Codigo { get; set; }
        public string Socio { get; set; }
        public string Password { get; set; }
        public string Sucursal { get; set; }
        public string Agencia { get; set; }
        public string Usuario { get; set; }
        public string Referencia { get; set; }
        public string Cliente { get; set; }
        public string Identidad { get; set; }
        public string Tipo { get; set; }
        public float Valor { get; set; }
        public float Factor { get; set; }
        public string Moneda { get; set; }
    }

}