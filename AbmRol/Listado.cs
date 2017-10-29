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

namespace PagoAgilFrba.AbmRol
{
    public partial class Listado : Form
    {
        public Listado()
        {
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            cargarRoles(this.leerRoles());
        }

        private SqlDataReader leerRoles()
        {
            return ClaseConexion.ResolverConsulta("SELECT rol_descripcion,rol_habilitado FROM CONGESTION.Rol");
        }

        private void cargarRoles(SqlDataReader reader)
        {
            while (reader.Read())
            {
                dgvRoles.Rows.Add(reader.GetString(0).Trim(), reader.GetBoolean(1), "Modificar","Baja");
            }
            
            reader.Close();

        }

        private void dgvRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dgvRoles.CurrentCell.ColumnIndex;
            int rowIndex = dgvRoles.CurrentCell.RowIndex;
            if (dgvRoles.RowCount > 1)
            {

                String descripcion = dgvRoles.Rows[rowIndex].Cells[0].Value.ToString();
                DataGridViewCheckBoxCell cB = dgvRoles.Rows[rowIndex].Cells["Habilitado"] as DataGridViewCheckBoxCell;
                bool habilitacion = !Convert.ToBoolean(cB.Value);

                if (columnIndex == 2)
                {
                    AbmRol.Modificacion form = new Modificacion(descripcion,habilitacion);
                    form.Show();
                    this.Hide();
                }
                else if (columnIndex == 3)
                {
                    AbmRol.Baja form = new Baja(descripcion);
                    form.Show();
                    this.Hide();
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            AbmRol.MenuRol form = new AbmRol.MenuRol();
            this.Hide();
            form.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvRoles.Rows.Clear();
            String consulta = "SELECT rol_descripcion,rol_habilitado FROM CONGESTION.Rol "
                               + "WHERE rol_descripcion LIKE '%" + txtNombreFiltro.Text + "%'";
            cargarRoles(ClaseConexion.ResolverConsulta(consulta));
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreFiltro.Clear();
            dgvRoles.Rows.Clear();
            cargarRoles(this.leerRoles());
           
        }

    }
}
