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
        static DataTable tabAvisos;

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
        public static bool AvisoExiste(string codAviso)
        {
            var param = new Dictionary<string, object> { { "codAviso", codAviso } };
            DataTable tabAviso = Conexion.getDataTable("spAvisoSelectCod", param, db, server);
            if (tabAviso.Rows.Count == 0)
                return false;

            return true;
        }

        public static bool Moneda( string moneda)
        {
            if (moneda != "L" && moneda != "D")
                return false;            
            return true;
        }
        public static bool FactorMoneda(float factor, string moneda)
        {
            if((factor != 1 && moneda == "L") || factor < 0)
                return false;
            return true;
        }
        public static bool AvisoSeleccionado(string codAviso, float valor)
        {            
            float saldo;

            foreach(DataRow fila in tabAvisos.Rows)
            {
                saldo = int.Parse(fila["Saldo"].ToString());
                if(saldo > 0 && codAviso == fila["Codigo"].ToString())
                {//es el primer aviso que no se ha pagado y coincide con el código de aviso
                    //que se ha recibido como aviso a pagar (todo bien)
                    if(saldo == valor) //el saldo de ese aviso debe ser igual al valor al pagar
                        return true;                    
                }
            }
            return false;
        }
    }
}