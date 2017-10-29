using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.RegistroPago
{
    class Cliente
    {
        private static String apellido, nombre, dni;

        public static void cargarDatosCon(String apellido, String nombre, String dni)
        {
            Cliente.apellido = apellido;
            Cliente.nombre = nombre;
            Cliente.dni = dni;
        }

        public static String nombreCompleto()
        {
            return Cliente.apellido + ", " + Cliente.nombre;
        }

        public static String documento()
        {
            return Cliente.dni;
        }
    }
}
