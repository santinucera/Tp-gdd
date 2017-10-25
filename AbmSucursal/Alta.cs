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
            int numRegs = ClaseConexion.ResolverNonQuery("INSERT INTO CONGESTION.Sucursal(suc_nombre, suc_direccion, suc_codPostal)"
                    + " VALUES('"+ txtNombre.Text +"','"+txtDireccion.Text +"','"+ txtCodigo.Text+"')");

            if (numRegs == 0)
            {
                MessageBox.Show("No se pudo agregar la sucurusal");
            }
            this.Hide();
            Listado form = new Listado();
            form.Show();
        }
    }
}
