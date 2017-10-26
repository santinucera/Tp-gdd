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
            this.cargarRubros();
        }

        private void label1_Click(object sender, EventArgs e)
        {
       
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (selectorRubros.SelectedItem == null)
            {
                MessageBox.Show("Debe elegir un rubro","Error");
            }
            else
            {
                try
                {
                    this.guardarEmpresa();
                    MessageBox.Show("Empresa guardada correctamente","Ok");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message,"Error");
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            AbmEmpresa.MenuEmpresas form = new MenuEmpresas();
            this.Hide();
            form.Show();
        }

        private void cargarRubros()
        {
            SqlDataReader rubros = ClaseConexion.ResolverConsulta("SELECT rub_descripcion FROM CONGESTION.Rubro");

            while (rubros.Read())
                selectorRubros.Items.Add(rubros.GetString(0));

            rubros.Close();
        }

        private void guardarEmpresa()
        {
            SqlCommand cmd = new SqlCommand("CONGESTION.sp_guardarEmpresa", ClaseConexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cuit", txtCuit.Text);
            cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd.Parameters.AddWithValue("@descripcionRubro", selectorRubros.SelectedItem.ToString());

            cmd.ExecuteReader().Close();
        }
    }
}
