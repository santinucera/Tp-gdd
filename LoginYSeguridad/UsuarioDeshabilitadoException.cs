using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.LoginYSeguridad
{
    class PasswordInvalidaException : Exception
    {
        public PasswordInvalidaException(String msg): base(msg)
        {

        }
    }
}
