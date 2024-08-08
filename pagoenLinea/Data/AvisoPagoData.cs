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
        public static int Registrar(AvisoPago pago, int RespuestaID)
        {
            SqlConnection connection = Conexion.GetConnection("WebPayment", "iPayment", "wp2024++", "3.18.93.40");
            
            SqlCommand cmd = new SqlCommand("spWebQueryInsert", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Socio", pago.Socio);
            cmd.Parameters.AddWithValue("@Sucursal", pago.Sucursal);
            cmd.Parameters.AddWithValue("@Agencia", pago.Agencia);
            cmd.Parameters.AddWithValue("@Usuario", pago.Usuario);
            cmd.Parameters.AddWithValue("@Referencia", pago.Referencia);
            cmd.Parameters.AddWithValue("@Cliente", pago.Cliente);
            cmd.Parameters.AddWithValue("@Identidad", pago.Identidad);
            cmd.Parameters.AddWithValue("@Tipo", pago.Tipo);
            cmd.Parameters.AddWithValue("@RespuestaID", RespuestaID);

            int aff = 0;
            try
            {
                connection.Open();
                aff = cmd.ExecuteNonQuery();
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
            if (aviso.Mensaje == "" && !Validaciones.AvisoExiste(pago.Codigo,pago.Identidad))
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[7][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[7][1].ToString();
            }
            if (!Validaciones.PagosPendientes(pago.Identidad, pago.Tipo) && aviso.Mensaje == "")
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[6][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[6][1].ToString();
            }
            if (aviso.Mensaje == "" && !Validaciones.Moneda(pago.Moneda))
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[8][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[8][1].ToString();
            }
            if (!Validaciones.FactorMoneda(pago.Factor, pago.Moneda) && aviso.Mensaje == "")
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[9][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[9][1].ToString();
            }
            if (!Validaciones.FactorMoneda(pago.Factor, pago.Moneda) && aviso.Mensaje == "")
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[9][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[9][1].ToString();
            }

            int okAviso = Validaciones.AvisoSeleccionado(pago.Codigo, pago.Valor,pago.Factor);
            if(okAviso == 1 && aviso.Mensaje == "")
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[10][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[10][1].ToString();
            }
            if (okAviso == 2 && aviso.Mensaje == "")
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[11][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[11][1].ToString();
            }
            return aviso;

        }
    }
}