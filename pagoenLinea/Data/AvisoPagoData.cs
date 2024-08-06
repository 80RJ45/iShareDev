using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pagoenLinea.Models;
using System.Data.SqlClient;
using System.Data;

namespace pagoenLinea.Data
{
    public class AvisoPagoData
    {
        public static int pagoAviso(AvisoPago pago)
        {
            SqlConnection connection = Conexion.GetConnection("WebPayment", "iPayment", "wp2024++", "3.18.93.40");

            SqlDataAdapter adp = new SqlDataAdapter();

            adp.UpdateCommand = new SqlCommand("spWebQueryUpdate", connection);
            adp.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adp.UpdateCommand.Parameters.AddWithValue("@Token", pago.Token);
            adp.UpdateCommand.Parameters.AddWithValue("@Valor", pago.Valor);
            adp.UpdateCommand.Parameters.AddWithValue("@Factor", pago.Factor);
            adp.UpdateCommand.Parameters.AddWithValue("@Moneda", pago.Moneda);

            int aff=0;
            try
            {
                connection.Open();
                aff = adp.UpdateCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                return 0;
                throw;
            }

            return aff;
        }

        public static Aviso validarGlobal(AvisoPago pago)
        {
            DataTable tabRespuesta;
            tabRespuesta = Conexion.getDataTable("spRespuestaSelect", new Dictionary<string, object> { }, "webPayment", "3.18.93.40");

            Aviso aviso = new Aviso(); //aviso vacio

            int usuarioID = Validaciones.validarSocio(pago.Socio, pago.Password);
            //validar que el socio existe y que la contraseña es correcta, 
            if (usuarioID <= 0)
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[1][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[1][1].ToString();
            }
            //validar que ese usuario tiene acceso a cobranza para ese cliente
            if (!Validaciones.validarClienteSocio(pago.Cliente, usuarioID) && aviso.Mensaje == "")
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[4][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[4][1].ToString();
            }
            if (!Validaciones.validarTipo(pago.Cliente, pago.Tipo) && aviso.Mensaje == "")
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[3][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[3][1].ToString();
            }
            if (!Validaciones.ClienteExiste(pago.Identidad) && aviso.Mensaje == "")
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[5][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[5][1].ToString();
            }
            if (!Validaciones.PagosPendientes(pago.Identidad, pago.Tipo) && aviso.Mensaje == "")
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[6][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[6][1].ToString();
            }
            if(!Validaciones.AvisoExiste(pago.CodigoAviso) && aviso.Mensaje == "")
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[7][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[7][1].ToString();
            }

            //agregar validaciones de Factor - moneda
            //agregar validaciones de valor - costoAviso
            return aviso;       

        }
    }
}