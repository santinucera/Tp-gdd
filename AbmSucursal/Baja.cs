using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmSucursal
{
    public partial class Baja : Form
    {
        public Baja()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClaseConexion.ResolverNonQuery("UPDATE CONGESTION.Sucursal SET usua_habilitado = 0 WHERE usua_username = '" + txtUsuario.Text + "'");
            this.Hide();
        }
    }
}
