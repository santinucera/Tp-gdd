using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PagoAgilFrba.RegistroPago
{
    class Registro      //sirve simple repositorio de cobros, y de cetralizador de datos de cabecera
    {
        public static List<CobroPendiente> cobrosPendientes = new List<CobroPendiente>();

        public static int cliente;
        public static String sucursal;
        public static DateTime fechaCobro;

        public static int getIdSucursal()
        {
            SqlDataReader dr = 
                ClaseConexion.ResolverConsulta("SELECT suc_id FROM CONGESTION.Sucursal WHERE suc_descripcion = '" + Registro.sucursal + "'");
            dr.Read();

            int id = dr.GetInt32(0);

            dr.Close();

            return id;
        }
    }
}
