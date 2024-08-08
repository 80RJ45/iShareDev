using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using pagoenLinea.Data;
using pagoenLinea.Models;


namespace pagoenLinea.Controllers
{
    public class PagoAvisoController : ApiController
    {
        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        public Aviso Post([FromBody] AvisoPago pago)
        {
            Aviso aviso = AvisoPagoData.validarGlobal(pago);

            if (aviso.Mensaje != "" && aviso.RespuestaID != 0)
            {
                AvisoPagoData.Registrar(pago, aviso.RespuestaID);
                return aviso;
            }
            else
            {
                AvisoPagoData.Registrar(pago, 0);
                return Validaciones.getAviso(pago);
            }

            
        }

        // PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}