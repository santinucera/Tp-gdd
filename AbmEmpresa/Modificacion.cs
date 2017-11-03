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
    public partial class Modificacion : Form
    {
        private String cuitViejo;

        public Modificacion(String cuit)
        {
            InitializeComponent();

            this.cuitViejo = cuit;
        }

        private void Modificacion_Load(object sender, EventArgs e)
        {
            this.cargarRubros();
            this.mostrarEmpresaCon(cuitViejo);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (selectorRubros.SelectedItem == null)
                MessageBox.Show("Debe elegir un rubro", "Error");
            else
            {
                try
                {
                    this.guardarEmpresa();
                    MessageBox.Show("Empresa guardada correctamente", "Ok");
                    this.Close();
                    new Listado().Show();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void mostrarEmpresaCon(String cuit)
        {
            SqlDataReader empresaConRubro = 
                ClaseConexion.ResolverConsulta("SELECT * FROM CONGESTION.listado_empresas WHERE empr_cuit = '" + cuit + "'");

            empresaConRubro.Read();

            txtNombre.Text = empresaConRubro.GetString(1);
            txtDireccion.Text = empresaConRubro.GetString(2);
            txtCuit.Text = empresaConRubro.GetString(3);
            selectorRubros.SelectedItem = empresaConRubro.GetString(5);

            empresaConRubro.Close();
        }

        private void cargarRubros()
        {
            SqlDataReader rubros = ClaseConexion.ResolverConsulta("SELECT rub_descripcion FROM CONGESTION.Rubro");

            while (rubros.Read())
                selectorRubros.Items.Add(rubros.GetString(0));

            rubros.Close();
        }

        private void volver_Click(object sender, EventArgs e)
        {
            Listado form = new Listado();
            form.Show();
            this.Close();
        }

        private void guardarEmpresa()
        {
            SqlCommand cmd = new SqlCommand("CONGESTION.sp_modificarEmpresa", ClaseConexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cuitViejo", cuitViejo);
            cmd.Parameters.AddWithValue("@cuit", txtCuit.Text);
            cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd.Parameters.AddWithValue("@descripcionRubro", selectorRubros.SelectedItem.ToString());

            cmd.ExecuteReader().Close();
        }
    }
}
