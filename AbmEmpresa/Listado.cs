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
    public partial class Listado : Form
    {
        public Listado()
        {
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            this.limpiarCampos();
            this.cargarRubros();
            this.cargarEmpresas(this.leerEmpresas());
        }

        private void cargarEmpresas(SqlDataReader reader)
        {
            while (reader.Read())
            {
                String bajaMod;

                if (reader.GetBoolean(3))
                    bajaMod = "Baja";
                else
                    bajaMod = "Habilitar";
               
                dgvSucursales.Rows.Add(reader.GetString(0).Trim(), reader.GetString(1).Trim(), reader.GetString(2).Trim(), reader.GetString(4).Trim(), reader.GetBoolean(3), "Modificar", bajaMod);
            }

            reader.Close();
        }

        private SqlDataReader leerEmpresas()
        {
            return ClaseConexion.ResolverConsulta("SELECT * FROM CONGESTION.listado_empresas");
        }

        private void cargarRubros()
        {
            SqlDataReader rubros = ClaseConexion.ResolverConsulta("SELECT rub_descripcion FROM CONGESTION.Rubro");

            while (rubros.Read())
                selectorRubros.Items.Add(rubros.GetString(0));

            rubros.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiarCampos();
        }

        private void dgvSucursales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dgvSucursales.CurrentCell.ColumnIndex;
            int rowIndex = dgvSucursales.CurrentCell.RowIndex;

            String cuit = dgvSucursales.Rows[rowIndex].Cells[2].Value.ToString();

            if (columnIndex == 5)       //si modifica
            {
                this.Close();
                new Modificacion(cuit).Show();
            }
            else if (columnIndex == 6)      //si da de baja
            {

                Boolean baja = (Boolean)dgvSucursales.Rows[rowIndex].Cells[3].Value;

                //  AbmEmpresa.Baja form = new Baja(cuit, direccion, nombre,baja);
                // form.Show();
               // this.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            
            dgvSucursales.Rows.Clear();

            String consulta = "SELECT * FROM CONGESTION.listado_empresas " +
                                    "WHERE empr_nombre LIKE '%" + txtNombre.Text + "%' and empr_cuit LIKE '%" + txtCuit.Text + "%'";

            if (selectorRubros.SelectedItem != null)    
                consulta += " and rub_descripcion LIKE '%" + selectorRubros.SelectedItem.ToString() + "%'";  //para evitar un NullPointerExc
            
            dr = ClaseConexion.ResolverConsulta(consulta);
            cargarEmpresas(dr);
            dr.Close();
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            new MenuEmpresas().Show();
        }

        private void limpiarCampos()
        {
            txtCuit.Text = "";
            txtNombre.Text = "";
            selectorRubros.SelectedItem = null;
        }
    }
}
