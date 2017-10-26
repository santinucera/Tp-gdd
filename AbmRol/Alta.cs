using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmRol
{
    public partial class Alta : Form
    {
        public Alta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int numRegs = ClaseConexion.ResolverNonQuery("INSERT INTO CONGESTION.Rol(rol_nombre, rol_habilitado)"
                    + " VALUES('" + txtNombre.Text + "','" + 1 + "')");

            if (numRegs == 0)
            {
                MessageBox.Show("No se pudo agregar la empresa");
            }
        }
    }
}
