using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.RegistroPago
{
    class ClienteDeLista
    {
        private String apellido, nombre, dni;

        public ClienteDeLista(String apellido, String nombre, String dni)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.dni = dni;
        }

        public String adaptar()
        {
            return "NOMBRE:" + this.apellido + ", " + this.nombre + " -----  DNI:" + this.dni;
        }
    }
}
