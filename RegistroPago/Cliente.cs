using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PagoAgilFrba.RegistroPago
{
    class Cliente
    {
        private static String apellido, nombre, dni;

        private static int id;

        public static void cargarDatosCon(String apellido, String nombre, String dni)
        {
            Cliente.apellido = apellido;
            Cliente.nombre = nombre;
            Cliente.dni = dni;

            Cliente.setId();
        }

        public static String nombreCompleto()
        {
            return Cliente.apellido + ", " + Cliente.nombre;
        }

        public static String getApellido()
        {
            return Cliente.apellido;
        }

        public static String getNombre()
        {
            return Cliente.nombre;
        }

        public static String getDni()
        {
            return Cliente.dni;
        }

        private static void setId()
        {
            String query = "SELECT clie_id FROM CONGESTION.Cliente WHERE";

            query += " clie_apellido = '" + Cliente.apellido + "'";
            query += " and clie_nombre = '" + Cliente.nombre + "'";
            query += " and clie_dni = '" + Cliente.dni + "'";

            SqlDataReader dr = ClaseConexion.ResolverConsulta(query);

            dr.Read();
            Cliente.id = dr.GetInt32(0);
            dr.Close();
        }

        public static int getId()
        {
            return Cliente.id;
        }
    }
}
