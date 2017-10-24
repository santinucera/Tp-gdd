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
        public static SqlConnection conexion = new SqlConnection("Data Source=localhost\\NAMEDINSTANCE;Initial Catalog=GD2C2017;Persist Security Info=True;User ID=gd;Password=gd2017");

        public static void Conectar()
        {
            try
            {
                conexion.Open();
            }
            catch (SqlException e)
            {
                MessageBox.Show("No se pudo establecer la conexion a la base de datos");
            }
        }

       
        public static SqlDataReader ResolverConsulta(String query)
        {
            SqlCommand cmd = new SqlCommand(query, conexion);

            SqlDataReader reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                throw new Exception("No se encontraron registros");
            }

            return reader;
        }

        public static void ResolverNonQuery(String nonQuery)
        {
            SqlCommand sqlcom = new SqlCommand(nonQuery, conexion);

            sqlcom.ExecuteNonQuery();

        }

        public static object ResolverFuncion(String query)
        {
            SqlCommand cmd = new SqlCommand(query, conexion);

            object resultado = cmd.ExecuteScalar();

            return resultado;
        }

    }
}
