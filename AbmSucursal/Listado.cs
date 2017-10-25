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
    public partial class Listado : Form
    {
        public Listado()
        {
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            cargarSucursales(this.leerSucursales());
        }

        private void cargarSucursales(SqlDataReader reader)
        {
            while (reader.Read())
            {
                String bajaMod;
                if (reader.GetBoolean(3))
                {
                    bajaMod = "Baja";
                }
                else
                {
                    bajaMod = "Habilitar";
                }

                dgvSucursales.Rows.Add(reader.GetString(0).Trim(), reader.GetString(1).Trim(), reader.GetString(2).Trim(), reader.GetBoolean(3), "Modificar", bajaMod);
            }

            reader.Close();

        }

        private SqlDataReader leerSucursales()
        {
            return ClaseConexion.ResolverConsulta("select suc_nombre,suc_direccion,suc_codPostal,suc_habilitado from CONGESTION.Sucursal");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtDireccion.Text = "";
            txtNombre.Text = "";
        }

        private void dgvSucursales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dgvSucursales.CurrentCell.ColumnIndex;
            int rowIndex = dgvSucursales.CurrentCell.RowIndex;

            if (dgvSucursales.RowCount > 1)
            {
                String codigo = dgvSucursales.Rows[rowIndex].Cells[2].Value.ToString();
                String direccion = dgvSucursales.Rows[rowIndex].Cells[1].Value.ToString();
                String nombre = dgvSucursales.Rows[rowIndex].Cells[0].Value.ToString();
                
                if(columnIndex == 4){//columna modificar
                    AbmSucursal.Modificacion form = new Modificacion(codigo,direccion,nombre);
                    form.Show();
                    this.Hide();
                }
                else if (columnIndex == 5){//columna baja
                    
                    Boolean baja= (Boolean)dgvSucursales.Rows[rowIndex].Cells[3].Value;

                    AbmSucursal.Baja form = new Baja(codigo, direccion, nombre,baja);
                    form.Show();
                    this.Hide();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dgvSucursales.Rows.Clear();

            String consulta = "select suc_nombre,suc_direccion,suc_codPostal,suc_habilitado from CONGESTION.Sucursal "
                                +"WHERE suc_nombre LIKE '%"+txtNombre.Text+"%' and suc_codPostal LIKE '%"+txtCodigo.Text+"%' and suc_direccion LIKE '%"+txtDireccion.Text+"%'";
            
            cargarSucursales(ClaseConexion.ResolverConsulta(consulta));
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmSucursal.Menu form= new Menu();
            form.Show();
        }
    }
}
