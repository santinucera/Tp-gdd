using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Menu
{
    public class FuncionalidadABM
    {
        private Form ventanaAlta;
        private Form ventanaListado;

        public FuncionalidadABM(Form ventanaAlta,Form ventanaListado)
        {
            this.ventanaAlta = ventanaAlta;
            this.ventanaListado= ventanaListado;
        }

       
        public void abrirVentanaAlta()
        {
            Form alta = this.ventanaAlta;
            alta.Show();
        }
        public void abrirVentanaListado()
        {
            Form listado = this.ventanaListado;
            listado.Show();
        }
    }
}
