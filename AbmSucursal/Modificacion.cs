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
    public partial class Modificacion : Form
    {
        public Modificacion(String codigo,String direccion,String nombre)
        {
            InitializeComponent();
            txtCodigo.Text = codigo;
            txtDireccion.Text = direccion;
            txtNombre.Text = nombre;
            this.codigo = codigo;
        }

        private String codigo;

        private void Modificacion_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            int numRegs = ClaseConexion.ResolverNonQuery("UPDATE CONGESTION.Sucursal SET suc_direccion = '" + txtDireccion.Text + "' ,suc_codPostal = '" + txtCodigo.Text + "', suc_nombre = '" + txtNombre.Text + "'"
                            + "WHERE suc_codPostal = '" + codigo + "'");

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
