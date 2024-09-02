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
        public static SqlConnection connection, connCliente;
        public static string db, server;
        public static List<object> Registrar(AvisoPago pago, int RespuestaID)
        {
            List<object> list = new List<object>();
            connection = Conexion.GetConnection("WebPayment", "iPayment", "wp2024++", "3.18.93.40");
            
            SqlCommand cmd = new SqlCommand("spWebQueryInsert", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@webQueryID", 0);
            cmd.Parameters[0].Direction = ParameterDirection.InputOutput;
            cmd.Parameters.AddWithValue("@Socio", pago.Socio);
            cmd.Parameters.AddWithValue("@Sucursal", pago.Sucursal);
            cmd.Parameters.AddWithValue("@Agencia", pago.Agencia);
            cmd.Parameters.AddWithValue("@Usuario", pago.Usuario);
            cmd.Parameters.AddWithValue("@Referencia", pago.Referencia);
            cmd.Parameters.AddWithValue("@Cliente", pago.Cliente);
            cmd.Parameters.AddWithValue("@Identidad", pago.Identidad);
            cmd.Parameters.AddWithValue("@Tipo", pago.Tipo);
            cmd.Parameters.AddWithValue("@RespuestaID", RespuestaID);
            cmd.Parameters.AddWithValue("@Valor", pago.Valor);
            cmd.Parameters.AddWithValue("@Factor", pago.Factor);
            cmd.Parameters.AddWithValue("@Moneda", pago.Moneda);
            cmd.Parameters.AddWithValue("@Token", "00000000000000000000");
            cmd.Parameters["@Token"].Direction = ParameterDirection.InputOutput;
            
            int webQueryID=-1;
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                webQueryID = (int)cmd.Parameters[0].Value;
                connection.Close();
            }
            catch (Exception ex)
            {
                string a = ex.Message;                
                throw;
            }

            list.Add(webQueryID);
            list.Add(cmd.Parameters["@Token"].Value);
            return list;
            //la lista es [ webQueryID,  Token]
        }   


        public static int registrarWebTransaccion(string cliente, int webQueryID)
        {

            SqlCommand cmd = new SqlCommand("spWebTransaccionInsert", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@webTransaccionID", 0);
            cmd.Parameters[0].Direction = ParameterDirection.InputOutput;
            cmd.Parameters.AddWithValue("@WebQueryID", webQueryID);
            cmd.Parameters.AddWithValue("@Cliente", cliente);

            int webTransaccionID = -1;
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                webTransaccionID = (int) cmd.Parameters[0].Value;
                connection.Close();
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                return webTransaccionID;
                throw;
            }
            return webTransaccionID;
        }
        public static int marcarAviso(string codAviso,int webTransaccionID,string cliente)
        {
            int avisoCabID=-1;
            DataTable tabCliente = new DataTable();
            var parametros = new Dictionary<string, object>
            {
                { "codCliente", cliente }
            };
            tabCliente = Conexion.getDataTable("spClienteCabSelect", parametros);


            server = tabCliente.Rows[0][3].ToString();
            db = tabCliente.Rows[0][4].ToString();

            connCliente = Conexion.GetConnection(db, "iPayment", "wp2024++", server);
            SqlCommand cmd = new SqlCommand("spAvisoCabUpdateTransaccion", connCliente);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AvisoCabID", 0);
            cmd.Parameters[0].Direction = ParameterDirection.InputOutput;
            cmd.Parameters.AddWithValue("@codAviso", codAviso);
            cmd.Parameters.AddWithValue("@webTransaccionID", webTransaccionID);

            int aff = 0;
            try
            {
                connCliente.Open();
                aff =cmd.ExecuteNonQuery();
                avisoCabID = (int)cmd.Parameters[0].Value;
                connCliente.Close();
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                throw;
            }

            //configurar proc para que devuelva el avisoCabID
            //terminar de configurar el command y ya hacer pruebas
            return avisoCabID;
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
                return aviso;
            }
            if (aviso.Mensaje == "" && !Validaciones.AvisoExiste(pago.Codigo,pago.Identidad))
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[7][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[7][1].ToString();
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