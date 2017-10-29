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
    public partial class RegistroPago : Form
    {
        public RegistroPago()
        {
            InitializeComponent();
        }

        private void RegistroPago_Load(object sender, EventArgs e)
        {
            this.cargarFecha();
        }

        private void cargarFecha()
        {
            fecha.Text = ClaseConexion.ResolverConsulta("SELECT GETDATE()").Read().ToString();
        }
    }
}
