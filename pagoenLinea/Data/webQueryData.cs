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

        public static int Registrar (webQuery query)
        {
            using (SqlConnection conn = new SqlConnection(Conexion.Cadena))
            {
                SqlCommand cmd = new SqlCommand("spWebQueryInsert", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@webQueryID", 0);
                cmd.Parameters.AddWithValue("@Fecha", query.Fecha);
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
                    return aff;
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                    return -1;
                }
            }
        }
    }
}