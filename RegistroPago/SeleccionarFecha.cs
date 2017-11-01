using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.RegistroPago
{
    public partial class SeleccionarFecha : Form
    {
        private AgregarFactura parent;

        public SeleccionarFecha(AgregarFactura parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void elegir_Click(object sender, EventArgs e)
        {
            this.parent.setFechaVto(calendario.SelectionStart.Date);
            this.Close();
        }
    }
}
