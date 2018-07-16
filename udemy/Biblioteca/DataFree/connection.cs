using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFree
{
    public class connection
    {

        // Singleton
        private static connection objConexion = null;
        public SqlConnection con;
        public SqlCommand sen;
        public SqlDataReader rs;

        private static string connectionString;

        private connection() {
            connectionString = @"Data Source=DARWINBERMU72C3\SQLEXPRESS;Initial Catalog=BIBLIOTECA;Integrated Security=True";
            con = new SqlConnection(connectionString);
        }

        public static connection saberEstado() {

            if (objConexion == null) {
                objConexion = new connection(); 
            }
            return objConexion;
        }

        public SqlConnection getCon()
        {
            return con;
        }

        public void cerrarConexion()
        {
            objConexion = null;
        }

    }
}
