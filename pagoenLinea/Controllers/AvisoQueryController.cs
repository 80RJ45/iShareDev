using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using pagoenLinea.Models;
using pagoenLinea.Data;
using System.Data;


namespace pagoenLinea.Controllers
{
    public class AvisoQueryController : ApiController
    {

        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        public List<Aviso> Post([FromBody] webQuery query)
        {
            Aviso aviso = webQueryData.validarGlobal(query);
            //el método validará y devolverá un aviso con el mensaje de error en caso de que haya

            List<Aviso> avisos = new List<Aviso>();

            //si hubieron errores retornar la lista con un solo aviso vacio que tenga el mensaje
            if (aviso.Mensaje != "" && aviso.RespuestaID != 0)
            {
                avisos.Add(aviso);
                webQueryData.Registrar(query, aviso.RespuestaID);
            }
            else
            {
                webQueryData.Registrar(query, aviso.RespuestaID);//primero para que se genere
                //el token
                avisos = webQueryData.GetAvisos(query);
            }


            return avisos;
        }

        // PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}