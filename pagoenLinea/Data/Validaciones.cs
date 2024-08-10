using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using pagoenLinea.Models;
namespace pagoenLinea.Data
{
    public class Validaciones
    {
        static SqlConnection conn;
        static string server, db;
        static DataTable tabAvisos, tabMoneda;

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

        public static bool validarTipo(string cliente, string tipo)
        {
            DataTable tabCliente = new DataTable();
            var parametros = new Dictionary<string, object>
            {
                { "codCliente", cliente }
            };
            tabCliente = Conexion.getDataTable("spClienteCabSelect", parametros);


            server = tabCliente.Rows[0][3].ToString();
            db = tabCliente.Rows[0][4].ToString();

            //validar tipo de contrato en la base del cliente
            DataTable tabTipoContrato = new DataTable();
            parametros = new Dictionary<string, object>
            {
                {"Tipo", tipo }
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
        public static bool PagosPendientes(string identidad, string tipo)
        {
            var param = new Dictionary<string, object>
            {
                { "Identidad", identidad},
                { "Tipo",tipo }
            };

            tabAvisos = Conexion.getDataTable("spAvisoQuerySelect", param, db, server);

            if (tabAvisos.Rows.Count == 0)
                return false;
            else
                return true;
        }
        public static bool AvisoExiste(string codAviso,string identidad)
        {
            var param = new Dictionary<string, object> { { "codAviso", codAviso },{"Identidad",identidad } };
            DataTable tabAviso = Conexion.getDataTable("spAvisoSelectCod", param, db, server);
            if (tabAviso.Rows.Count == 0)
                return false;

            return true;
        }

        public static bool Moneda(string moneda)
        {
            tabMoneda = Conexion.getDataTable
               (
                   "spMonedaQuerySelect",
                   new Dictionary<string, object>
                   {
                        {"Codigo", moneda }
                   },
                   db,
                   server
               );

            if (tabMoneda.Rows.Count == 0)
                return false;
            return true;
        }
        
        public static bool FactorMoneda(float factor, string moneda)
        {
            if ((factor != 1 && moneda == "L.") || factor < 0)
                return false;            
            return true;
        }
        public static int AvisoSeleccionado(string codAviso, float valor,float factor = 1)
        {// 1 aviso incorrecto seleccionado
            //2 valor del pago no coincide con el saldo del aviso
            int resp = 0;//ok
            float saldo;
            

            DataRow fila = tabAvisos.Rows[0];

                saldo = int.Parse(fila["Saldo"].ToString());
                
                
                if (!(codAviso == fila["Codigo"].ToString()))
                {//es el primer aviso que no se ha pagado y  NO coincide con el código de aviso                    
                 //que se ha recibido como aviso a pagar

                    resp = 1;
                    return resp;
                }
                else
                {
                    if (saldo != valor * factor) //el saldo de ese aviso debe ser igual al valor a pagar
                    {
                        resp = 2;
                        return resp;
                    }
                }

            
            return resp;
        }


        public static List<object> getAviso(AvisoPago pago, string token)
        {
            List<object> list = new List<object>();

            //inicializar la informacion del cliente
            DataTable tabCliente = new DataTable();
            var parametros = new Dictionary<string, object>
            {
                { "codCliente", pago.Cliente }
            };
            tabCliente = Conexion.getDataTable("spClienteCabSelect", parametros);


            server = tabCliente.Rows[0][3].ToString();
            db = tabCliente.Rows[0][4].ToString();

            DataTable tabAviso = new DataTable();
            var Parametros = new Dictionary<string, object>
            {
                { "Identidad", pago.Identidad},
                { "Tipo",pago.Tipo }
            };

            tabAviso = Conexion.getDataTable("spAvisoQuerySelect", Parametros, db, server);
            DataRow fila = tabAviso.Rows[0];

            Aviso aviso = new Aviso();
            aviso.Codigo = fila["Codigo"].ToString();
            aviso.Contrato = fila["ContratoCabID"].ToString();
            aviso.TipoContrato = fila["nomTipoContrato"].ToString();
            aviso.Periodo = fila["Periodo"].ToString();
            aviso.Cliente = fila["nomCliente"].ToString();
            aviso.FechaVence = fila["FechaVence"].ToString();
            aviso.SubTotal = float.Parse(fila["Valor"].ToString());
            aviso.Descuento = float.Parse(fila["Descuento"].ToString());
            aviso.Impuesto = float.Parse(fila["Impuesto"].ToString());
            aviso.Mora = float.Parse(fila["Mora"].ToString());
            aviso.Valor = float.Parse(fila["Saldo"].ToString());
            aviso.Moneda = tabMoneda.Rows[0]["Codigo"].ToString();
            aviso.RespuestaID = 0;
            aviso.Mensaje = "OK";
            aviso.Token = token;

            list.Add(aviso);
            list.Add(fila["Avisos"]);
            return list;
        }
    }
}