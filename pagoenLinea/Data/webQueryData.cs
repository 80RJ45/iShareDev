using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pagoenLinea.Models;
using System.Data.SqlClient;
using System.Data;

namespace pagoenLinea.Data
{
    public class webQueryData
    {
        static SqlConnection conn;
        static string server, db;
        static string token;


        public static bool Registrar(webQuery query, int RespuestaID)
        {

            conn = new SqlConnection(Conexion.Cadena);
            SqlCommand cmd = new SqlCommand("spWebQueryInsert", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Socio", query.Socio);
            cmd.Parameters.AddWithValue("@Sucursal", query.Sucursal);
            cmd.Parameters.AddWithValue("@Agencia", query.Agencia);
            cmd.Parameters.AddWithValue("@Usuario", query.Usuario);
            cmd.Parameters.AddWithValue("@Referencia", query.Referencia);
            cmd.Parameters.AddWithValue("@Cliente", query.Cliente);
            cmd.Parameters.AddWithValue("@Identidad", query.Identidad);
            cmd.Parameters.AddWithValue("@Tipo", query.Tipo);
            cmd.Parameters.AddWithValue("@RespuestaID", RespuestaID);

            int aff = 0;
            try
            {
                conn.Open();
                aff = cmd.ExecuteNonQuery();
                //despues de almacenar el registro recuperar el token generado
                var parameters = new Dictionary<string, object>
                {
                    {"Socio", query.Socio},
                    {"Sucursal", query.Sucursal},
                    {"Agencia", query.Agencia},
                    {"Usuario", query.Usuario},
                    {"Referencia", query.Referencia},
                    {"Cliente", query.Cliente},
                    {"Identidad", query.Identidad},
                    {"Tipo", query.Tipo},
                };
                DataTable tabToken = Conexion.getDataTable("spGetToken", parameters);
                token = tabToken.Rows[0]["Token"].ToString();
            }
            catch (Exception ex)
            {
                //aviso.Mensaje = ex.Message;
                string a = ex.Message;
                return false;
            }

            return true;
        }

        public static List<Aviso> GetAvisos(webQuery query)
        {
            //inicializar la informacion del cliente
            DataTable tabCliente = new DataTable();
            var parametros = new Dictionary<string, object>
            {
                { "codCliente", query.Cliente }
            };
            tabCliente = Conexion.getDataTable("spClienteCabSelect", parametros);


            server = tabCliente.Rows[0][3].ToString();
            db = tabCliente.Rows[0][4].ToString();

            DataTable tabAviso = new DataTable();
            var Parametros = new Dictionary<string, object>
            {
                { "Identidad", query.Identidad},
                { "Tipo",query.Tipo }
            };

            tabAviso = Conexion.getDataTable("spAvisoQuerySelect", Parametros, db, server);
            List<Aviso> avisos = new List<Aviso>();

            DataTable tabMoneda = Conexion.getDataTable("spContratoMonedaSelect", new Dictionary<string, object> { { "ContratoCabID", tabAviso.Rows[0]["ContratoCabID"] } }, db, server);
            DataTable tabRespuesta = Conexion.getDataTable("spRespuestaSelect", new Dictionary<string, object> { }, "webPayment", "3.18.93.40");
            foreach (DataRow fila in tabAviso.Rows)
            {
                Aviso aviso = new Aviso();
                aviso.Codigo = fila["Codigo"].ToString();
                aviso.Contrato = fila["ContratoCabID"].ToString();
                aviso.TipoContrato = fila["nomTipoContrato"].ToString();
                aviso.Periodo = fila["Periodo"].ToString();
                aviso.Cliente = fila["nomCliente"].ToString();
                aviso.FechaVence = fila["FechaVence"].ToString();
                aviso.SubTotal = float.Parse(fila["Valor"].ToString() ==""? "0": fila["Valor"].ToString());
                aviso.Descuento = float.Parse(fila["Descuento"].ToString() == "" ? "0" : fila["Descuento"].ToString());
                aviso.Impuesto = float.Parse(fila["Impuesto"].ToString() == "" ? "0" : fila["Impuesto"].ToString());
                aviso.Mora = float.Parse(fila["Mora"].ToString() == "" ? "0" : fila["Mora"].ToString());
                aviso.Valor = float.Parse(fila["Saldo"].ToString() == "" ? "0" : fila["Saldo"].ToString());
                aviso.Moneda = tabMoneda.Rows[0]["codMoneda"].ToString();
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[0][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[0][1].ToString();
                aviso.Token = token;
                avisos.Add(aviso);
            }
            return avisos;
        }



        public static Aviso validarGlobal(webQuery query)
        {
            DataTable tabRespuesta;
            tabRespuesta = Conexion.getDataTable("spRespuestaSelect", new Dictionary<string, object> { }, "webPayment", "3.18.93.40");

            Aviso aviso = new Aviso(); //aviso vacio

            int usuarioID = Validaciones.validarSocio(query.Socio, query.Password);
            //validar que el socio existe y que la contraseña es correcta, 
            if (usuarioID <= 0)
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[1][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[1][1].ToString();
            }
            //validar que ese usuario tiene acceso a cobranza para ese cliente
            if (!Validaciones.validarClienteSocio(query.Cliente, usuarioID) && aviso.Mensaje == "")
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[4][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[4][1].ToString();
            }
            if (!Validaciones.validarTipo(query.Cliente, query.Tipo) && aviso.Mensaje == "")
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[3][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[3][1].ToString();
            }
            if (!Validaciones.ClienteExiste(query.Identidad) && aviso.Mensaje == "")
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[5][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[5][1].ToString();
            }
            if (!Validaciones.PagosPendientes(query.Identidad, query.Tipo) && aviso.Mensaje == "")
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[6][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[6][1].ToString();
            }
            return aviso;
        }
    }
}