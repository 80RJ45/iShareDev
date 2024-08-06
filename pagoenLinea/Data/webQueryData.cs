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
        static SqlConnection connCliente;
        static string server, db;

        public static int validarSocio(string usr, string pass)
        {
            SqlDataAdapter adpUsuario;
            DataTable tabUser = new DataTable();
            conn = new SqlConnection(Conexion.Cadena);
            adpUsuario = new SqlDataAdapter("spUsuarioSelect", conn);
            adpUsuario.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpUsuario.SelectCommand.Parameters.AddWithValue("@Usuario", usr);
            adpUsuario.SelectCommand.Parameters.AddWithValue("@Password", pass);

            adpUsuario.Fill(tabUser);

            if (tabUser.Rows.Count > 0)
                return int.Parse(tabUser.Rows[0]["UsuarioID"].ToString());

            return -1;
        }

        public static bool validarClienteSocio(string codCliente, int usuarioID)
        {
            SqlDataAdapter adpClienteDet = new SqlDataAdapter("spClienteDetSelect", conn);
            adpClienteDet.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpClienteDet.SelectCommand.Parameters.AddWithValue("@CodCliente", codCliente);
            adpClienteDet.SelectCommand.Parameters.AddWithValue("@usuarioID", usuarioID);

            DataTable tabClienteDet = new DataTable();
            adpClienteDet.Fill(tabClienteDet);

            if (tabClienteDet.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public static bool validarTipo(webQuery query)
        {
            DataTable tabCliente = new DataTable();
            var parametros = new Dictionary<string, object>
            {
                { "codCliente", query.Cliente }
            };
            tabCliente = Conexion.getDataTable("spClienteCabSelect", parametros);

            
            server = tabCliente.Rows[0][3].ToString();
            db = tabCliente.Rows[0][4].ToString();

            //validar tipo de contrato en la base del cliente
            DataTable tabTipoContrato = new DataTable();
            parametros = new Dictionary<string, object>
            {
                {"Tipo", query.Tipo }
            };
            tabTipoContrato = Conexion.getDataTable("spValidarTipoContrato", parametros, db, server);

            if (tabTipoContrato.Rows.Count == 0)
                return false;

            return true;
        }

        public static bool ClienteExiste(string identidad)
        {
            var param = new Dictionary<string, object>
            {
                {"Identidad", identidad }
            };
            DataTable tabCliente = Conexion.getDataTable("spClienteWebQuerySelect", param, db, server);
            //reutilizando variables estáticas db, server(del cliente), se asignan en validarTipo

            if (tabCliente.Rows.Count == 0)
                return false;
            else
                return true;
        }
        public static bool PagosPendientes(webQuery query)
        {
            var param = new Dictionary<string, object>
            {
                { "Identidad", query.Identidad},
                { "Tipo",query.Tipo }
            };
            DataTable tabAvisos = Conexion.getDataTable("spAvisoQuerySelect", param, db, server);

            if (tabAvisos.Rows.Count == 0)
                return false;
            else
                return true;
        }
        public static List<Aviso> Registrar(webQuery query)
        {
            
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
            

            int aff = 0;
            try
            {
                conn.Open();
                aff = cmd.ExecuteNonQuery();
                //if (aff > 0)
                    //aviso.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                //aviso.Mensaje = ex.Message;
                string a = ex.Message;
            }


            DataTable tabAviso = new DataTable();
            var Parametros = new Dictionary<string, object>
            {
                { "Identidad", query.Identidad},
                { "Tipo",query.Tipo }
            };

            tabAviso = Conexion.getDataTable("spAvisoQuerySelect", Parametros, db, server);
            List<Aviso> avisos = new List<Aviso>();

            DataTable tabRespuesta = Conexion.getDataTable("spRespuestaSelect", new Dictionary<string, object> { }, "webPayment", "3.18.93.40");
            foreach (DataRow fila in tabAviso.Rows)
            {
                Aviso aviso = new Aviso();
                aviso.Codigo = fila["Codigo"].ToString();
                aviso.Contrato = fila["ContratoCabID"].ToString();
                aviso.TipoContrato = fila["nomTipoContrato"].ToString();
                aviso.Periodo = fila["Periodo"].ToString();
                aviso.Cliente = fila["nomCliente"].ToString();
                aviso.Fecha = fila["FechaVence"].ToString();
                aviso.SubTotal = float.Parse(fila["Valor"].ToString());
                aviso.Descuento = float.Parse(fila["Descuento"].ToString());
                aviso.Impuesto = float.Parse(fila["Impuesto"].ToString());
                aviso.Mora = float.Parse(fila["Mora"].ToString());
                aviso.Valor = float.Parse(fila["Total"].ToString());
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[0][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[0][1].ToString();
                avisos.Add(aviso);
            }
            return avisos;
        }

        

        public static Aviso validarGlobal(webQuery query)
        {
            DataTable tabRespuesta;
            tabRespuesta = Conexion.getDataTable("spRespuestaSelect", new Dictionary<string, object> { }, "webPayment", "3.18.93.40");

            Aviso aviso = new Aviso(); //aviso vacio

            int usuarioID = validarSocio(query.Socio, query.Password);
            //validar que el socio existe y que la contraseña es correcta, 
            if (usuarioID <= 0)
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[1][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[1][1].ToString();
            }
            //validar que ese usuario tiene acceso a cobranza para ese cliente
            if (!validarClienteSocio(query.Cliente, usuarioID) && aviso.Mensaje == "")
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[4][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[4][1].ToString();
            }
            if (!validarTipo(query) && aviso.Mensaje == "")
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[3][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[3][1].ToString();
            }
            if (!ClienteExiste(query.Identidad) && aviso.Mensaje == "")
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[5][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[5][1].ToString();
            }
            if (!PagosPendientes(query) && aviso.Mensaje == "")
            {
                aviso.RespuestaID = int.Parse(tabRespuesta.Rows[6][0].ToString());
                aviso.Mensaje = tabRespuesta.Rows[6][1].ToString();
            }
            return aviso;
        }
    }
}