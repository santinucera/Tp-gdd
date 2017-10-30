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

        public override string ToString()
        {
            return this.apellido + ", " + this.nombre + "    /    " + this.dni;
        }

        public String getApellido()
        {
            return this.apellido;
        }

        public String getNombre()
        {
            return this.apellido;
        }

        public String getDni()
        {
            return this.apellido;
        }
    }
}
