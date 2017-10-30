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

namespace PagoAgilFrba.RegistroPago
{
    public partial class BusquedaCliente : Form
    {
        public BusquedaCliente()
        {
            InitializeComponent();
            this.limpiarCampos();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!this.tieneLosCamposVacios())
            {
                listaClientes.Items.Clear();

                String selectFromClientes = "SELECT clie_apellido, clie_nombre, clie_dni FROM CONGESTION.Cliente WHERE";

                String apellido = " clie_apellido LIKE '%" + txtApellido.Text + "%' and";
                String nombre = " clie_nombre LIKE '%" + txtNombre.Text + "%' and";
                String dni = " clie_dni LIKE '%" + txtDni.Text + "%'";

                this.cargarListaCon(ClaseConexion.ResolverConsulta(selectFromClientes + apellido + nombre + dni));
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiarCampos();
        }

        private void limpiarCampos()
        {
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtDni.Text = "";

            listaClientes.Items.Clear();
            listaClientes.Text = "";

            btnSeleccionar.Enabled = false;
        }

        private void cargarListaCon(SqlDataReader dr)
        {
            int colApellido = dr.GetOrdinal("clie_apellido");
            int colNombre = dr.GetOrdinal("clie_nombre");
            int colDni = dr.GetOrdinal("clie_dni");
            
            while (dr.Read())
            {
                listaClientes.Items.Add(new ClienteDeLista(dr.GetString(colApellido), dr.GetString(colNombre), dr.GetSqlDecimal(colDni).ToString()));
            }

            dr.Close();
        }

        private Boolean tieneLosCamposVacios()  //se usa para la busqueda
        {
            return txtApellido.Text.Equals("") && txtNombre.Text.Equals("") && txtDni.Text.Equals("");
        }


        private void listaClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSeleccionar.Enabled = true;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            ClienteDeLista elCliente = (ClienteDeLista)listaClientes.SelectedItem;

            Cliente.cargarDatosCon(elCliente.getApellido(), elCliente.getNombre(), elCliente.getDni());

            this.Close();
        }
    }
}
