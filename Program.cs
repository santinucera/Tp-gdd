using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    static class Program
    {
        // Defino variable global para el id del usuario logueado
        public static int idUsuarioLogueado = 0;

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        public static String username;
        public static String rol;
        public static String sucursal = "";
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ClaseConexion.Conectar();
            Application.Run(new Form1());
        }
    }
}
