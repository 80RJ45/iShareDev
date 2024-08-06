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
    public class AvisoPagoController : ApiController
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
        public int Post([FromBody] AvisoPago pago)
        {
            Aviso aviso = AvisoPagoData.validarGlobal(pago);

            if (aviso.Mensaje != "")
                return 0;
            else
                return AvisoPagoData.pagoAviso(pago);
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