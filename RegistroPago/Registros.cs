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

        public static int cliente, sucursal, medioPago;
        public static DateTime fechaCobro;
        public static float total;
    }
}
