using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class Alta : Form
    {
        public Alta()
        {
            InitializeComponent();
        }

        private void Alta_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
       
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            int numRegs = ClaseConexion.ResolverNonQuery("INSERT INTO CONGESTION.Empresa(empr_cuit, empr_direccion, empr_nombre, empr_habilitado)"
                    + " VALUES('" + txtCuit.Text + "','" + txtDireccion.Text + "','" + txtNombre.Text + "','" + 1 + "')");

            if (numRegs == 0)
            {
                MessageBox.Show("No se pudo agregar la empresa");
            }
            this.Hide();
            Listado form = new Listado();
            form.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            AbmEmpresa.MenuEmpresas form = new MenuEmpresas();
            this.Hide();
            form.Show();
        }
    }
}
