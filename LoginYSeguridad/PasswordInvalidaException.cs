using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.LoginYSeguridad
{
    class UsuarioDeshabilitadoException : Exception
    {
        public UsuarioDeshabilitadoException(string msg): base(msg)
        {
        }
    }
}
