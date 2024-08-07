using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pagoenLinea.Models
{
    public class Aviso
    {
        public string Codigo { get; set; }
        public string Contrato { get; set; }
        public string TipoContrato { get; set; }
        public string Periodo { get; set; }
        public string Cliente { get; set; }
        public string FechaVence { get; set; }
        public float SubTotal { get; set; }
        public float Descuento { get; set; }
        public float Impuesto { get; set; }
        public float Mora { get; set; }
        public float Valor { get; set; }
        public string Moneda { get; set; }
        public int RespuestaID { get; set; }
        public string Mensaje { get; set; }
        public string Token { get; set; }

        public Aviso()
        {
            Codigo = "";
            Contrato = "";
            TipoContrato = "";
            Periodo = "";
            Cliente = "";
            FechaVence = "";
            SubTotal = 0;
            Descuento = 0;
            Impuesto = 0;
            Mora = 0;
            Valor = 0;
            Mensaje = "";
            RespuestaID = 0;
            Token = "";
        }
    }
}