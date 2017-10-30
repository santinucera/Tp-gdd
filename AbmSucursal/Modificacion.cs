using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            if (String.IsNullOrWhiteSpace(txtCodigo.Text) && String.IsNullOrWhiteSpace(txtDireccion.Text) && String.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe completar todos los campos", "Error");
            }
            else
            {
                try
                {
                    this.guardarSucursal();
                    MessageBox.Show("Sucursal guardada correctamente", "Ok");
                    this.Close();
                    new Listado().Show();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void guardarSucursal()
        {
            SqlCommand cmd = new SqlCommand("CONGESTION.sp_modificarSucursal", ClaseConexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codigo", txtCodigo.Text);
            cmd.Parameters.AddWithValue("@codigoViejo", codigo);
            cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);

            cmd.ExecuteReader().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Listado().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
        }
    }
}
