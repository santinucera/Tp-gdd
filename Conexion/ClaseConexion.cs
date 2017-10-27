using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    class ClaseConexion
    {
       
        // declaro una variable de conexion global
        public static SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLSERVER2012;Initial Catalog=GD2C2017;Persist Security Info=True;User ID=gd;Password=gd2017;MultipleActiveResultSets=True");
        
        public static void Conectar()
        {
            try
            {
                conexion.Open();
            }
            catch (SqlException e)
            {
                MessageBox.Show("No se pudo establecer la conexion a la base de datos." + e.Message);
            }
        }

       
        public static SqlDataReader ResolverConsulta(String query)
        {
            return new SqlCommand(query, conexion).ExecuteReader();
        }

        public static int ResolverNonQuery(String nonQuery)
        {
            return new SqlCommand(nonQuery, conexion).ExecuteNonQuery();
        }

        public static object ResolverFuncion(String query)
        {
            return new SqlCommand(query, conexion).ExecuteScalar();
        }

    }
}
