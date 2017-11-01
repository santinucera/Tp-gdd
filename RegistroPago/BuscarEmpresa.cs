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
    public partial class BuscarEmpresa : Form
    {
        private AgregarFactura padre;

        public BuscarEmpresa(AgregarFactura parent)
        {
            InitializeComponent();
            this.limpiarCampos();
            this.cargarCombroRubros();
            this.padre = parent;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!this.tieneLosCamposVacios())
            {
                listaEmpresas.Items.Clear();

                String selectFromEmpresas = "SELECT empr_id, empr_nombre, empr_cuit, rub_descripcion FROM CONGESTION.listado_empresas";

                String nombre = " empr_nombre LIKE '%" + txtNombre.Text + "%' and";
                String cuit = " empr_cuit LIKE '%" + txtCuit.Text + "%' and";
                String rubro = " rub_descripcion LIKE '%" + selectorRubros.SelectedText + "%'"; 

                this.cargarListaCon(ClaseConexion.ResolverConsulta(selectFromEmpresas + nombre + cuit + rubro));
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiarCampos();
        }

        private void limpiarCampos()
        {
            txtNombre.Text = "";
            txtCuit.Text = "";
            selectorRubros.SelectedItem = null;
            
            listaEmpresas.Items.Clear();
            listaEmpresas.Text = "";

            btnSeleccionar.Enabled = false;
        }

        private void cargarListaCon(SqlDataReader dr)
        {
            int colId = dr.GetOrdinal("empr_id");
            int colNombre = dr.GetOrdinal("empr_nombre");
            int colCuit = dr.GetOrdinal("empr_cuit");
            
            while (dr.Read())
            {
                listaEmpresas.Items.Add(new Empresa(dr.GetInt32(colId), dr.GetString(colNombre), dr.GetString(colCuit)));
            }

            dr.Close();
        }

        private Boolean tieneLosCamposVacios()  //se usa para la busqueda
        {
            return txtNombre.Text.Equals("") && txtCuit.Text.Equals("") && selectorRubros.SelectedItem.Equals(null);
        }


        private void listaClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSeleccionar.Enabled = true;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Empresa laEmpresa = listaEmpresas.SelectedItem as Empresa;


            this.padre.setEmpresa(laEmpresa);
            this.Close();
        }

        private void cargarCombroRubros()
        {
            SqlDataReader dr = ClaseConexion.ResolverConsulta("SELECT rub_descripcion FROM CONGESTION.Rubro");

            while (dr.Read())
            {
                selectorRubros.Items.Add(dr.GetString(0));
            }

            dr.Close();
        }
    }
}
