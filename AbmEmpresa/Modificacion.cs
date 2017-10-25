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
    public partial class Modificacion : Form
    {
        public Modificacion(String cuit,String direccion,String nombre)
        {
            InitializeComponent();
            txtCuit.Text = cuit;
            txtDireccion.Text = direccion;
            txtNombre.Text = nombre;
            this.cuit = cuit;
        }

        private String cuit;

        private void Modificacion_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            int numRegs = ClaseConexion.ResolverNonQuery("UPDATE CONGESTION.Empresa SET empr_direccion = '" + txtDireccion.Text + "' ,empr_cuit = '" + txtCuit.Text + "', empr_nombre = '" + txtNombre.Text + "'"
                            + "WHERE empr_cuit = '" + cuit + "'");

            if (numRegs == 0)
            {
                MessageBox.Show("No se pudo guardar los cambios");
            }
            Listado form = new Listado();
            form.Show();
            this.Hide();
        }
    }
}
