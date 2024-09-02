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
            int webQueryID,webTransaccionID=-1,avisoCabID=-1, cantAvisos=0;
            List<object> getAviso = new List<object>(); //lista para almacenar el resultado de la función getAviso
            Aviso aviso = AvisoPagoData.validarGlobal(pago); 

            if (aviso.Mensaje != "" && aviso.RespuestaID != 0)
            {
                AvisoPagoData.Registrar(pago, aviso.RespuestaID);
                return aviso;
            }
            else
            {
                List<object> data = new List<object>();
                
                data = AvisoPagoData.Registrar(pago, 0);
                webQueryID =(int) data[0];

                if (webQueryID > 0)
                    webTransaccionID = AvisoPagoData.registrarWebTransaccion(pago.Cliente, webQueryID);
                if (webTransaccionID > 0)
                    getAviso = Validaciones.getAviso(pago, data[1].ToString());

                aviso =(Aviso)getAviso [0]; //getAviso devuelve una lista con [ (objeto de tipo Aviso), cantidadAvisos]        
                cantAvisos = (int)getAviso[1];
                avisoCabID = AvisoPagoData.marcarAviso(pago.Codigo,cantAvisos, webTransaccionID, pago.Cliente)[0];
                if(avisoCabID >0)
                    return aviso;
                else
                    return new Aviso();
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