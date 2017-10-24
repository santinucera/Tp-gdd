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
        private Form ventanaBaja;
        private Form ventanaModificacion;

        public FuncionalidadABM(Form ventanaAlta, Form ventanaBaja, Form ventanaModificacion)
        {
            this.ventanaAlta = ventanaAlta;
            this.ventanaBaja = ventanaBaja;
            this.ventanaModificacion = ventanaModificacion;
        }

        public void abrirVentanaModificar()
        {
            this.ventanaModificacion.Show();
        }

        public void abrirVentanaBaja()
        {
            this.ventanaBaja.Show();
        }

        public void abrirVentanaAlta()
        {
            this.ventanaAlta.Show();
        }
    }
}
