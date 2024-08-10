using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace pagoenLinea.Data
{
    public class Conexion
    {
        public static string Cadena = "User Id=iPayment;Password=wp2024++;Initial Catalog=webPayment;Server=3.18.93.40";
        
        public static SqlConnection GetConnection(string db, string usr, string pass, string server)
        {
            string cadena2 = "User Id="+usr+";Password="+pass+";Initial Catalog="+db+";Server="+server;
            SqlConnection conn = new SqlConnection(cadena2);
            return conn;
        }

        public static DataTable getDataTable(string sp, Dictionary<string,object>parametros)
        {
            SqlConnection connection = new SqlConnection(Cadena);
            SqlDataAdapter adapter = new SqlDataAdapter(sp, connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            foreach(var param in parametros){
                adapter.SelectCommand.Parameters.AddWithValue("@" + param.Key, param.Value);                
            }

            DataTable tabResult = new DataTable();
            adapter.Fill(tabResult);

            return tabResult;            
        }

        public static DataTable getDataTable(string sp, Dictionary<string, object> parametros, string db,string server)
        {

            SqlConnection connection = GetConnection(db, "iPayment", "wp2024++", server);
            SqlDataAdapter adapter = new SqlDataAdapter(sp, connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            foreach (var param in parametros)
            {
                adapter.SelectCommand.Parameters.AddWithValue("@" + param.Key, param.Value);
            }

            DataTable tabResult = new DataTable();
            try
            {
                adapter.Fill(tabResult);
            }
            catch (Exception)
            {

                throw;
            }
            

            return tabResult;
        }
    }
}