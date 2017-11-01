using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.RegistroPago
{
    public class Empresa
    {
        private String nombre, cuit;
        private int id;

        public Empresa(int id, String nombre, String cuit)
        {
            this.id = id;
            this.nombre = nombre;
            this.cuit = cuit;
        }

        public override string ToString()
        {
            return this.nombre + "   /   CUIT: " + this.cuit;
        }
    }
}
