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
    public partial class Modificacion : Form
    {
        string nombreR;
        public Modificacion(string nombre,bool habilitacion)
        {
            InitializeComponent();
            txtNombre.Text = nombre;
            btnHabilitar.Enabled = habilitacion;
            nombreR = nombre;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            AbmRol.Listado form = new AbmRol.Listado();
            this.Hide();
            form.Show();
        }

        private void Modificacion_Load(object sender, EventArgs e)
        {

            cargarFunciones(this.leerFunciones());
            cargarFuncionesCB(this.leerFuncionalidadesCB());
            

        }

        private SqlDataReader leerFunciones()
        {
            return ClaseConexion.ResolverConsulta("SELECT func_descripcion FROM CONGESTION.Funcionalidad JOIN"
                +" CONGESTION.Funcionalidad_Rol ON func_id = fr_funcionalidad JOIN CONGESTION.Rol ON rol_id = fr_rol AND rol_descripcion LIKE'%" + txtNombre.Text + "%'");
        }

        private void cargarFunciones(SqlDataReader reader)
        {
            while (reader.Read())
            {
                dgvFuncionalidades.Rows.Add(reader.GetString(0), "Eliminar");
            }

            reader.Close();

        }

        private void dgvFuncionalidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dgvFuncionalidades.CurrentCell.ColumnIndex;
            int rowIndex = dgvFuncionalidades.CurrentCell.RowIndex;
            if (dgvFuncionalidades.RowCount > 1)
            {
                String descripcion = dgvFuncionalidades.Rows[rowIndex].Cells[0].Value.ToString();

                if (columnIndex == 1)
                {
                    this.eliminarFuncionalidad(descripcion);
                    dgvFuncionalidades.Rows.RemoveAt(rowIndex);
                    selectorFuncionalidades.Items.Clear();
                    cargarFuncionesCB(this.leerFuncionalidadesCB());
                }

            }
        }

        private void eliminarFuncionalidad(string descripcion)
        {
            SqlCommand cmd = new SqlCommand("CONGESTION.sp_eliminarFuncionalidadRol", ClaseConexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombreFuncionalidad", descripcion);
            cmd.Parameters.AddWithValue("@nombreRol", txtNombre.Text);
            cmd.ExecuteReader().Close();
        }

  

        private SqlDataReader leerFuncionalidadesCB()
        {
            return ClaseConexion.ResolverConsulta("SELECT func_descripcion FROM CONGESTION.Funcionalidad WHERE func_descripcion NOT IN (SELECT func_descripcion FROM CONGESTION.Funcionalidad JOIN CONGESTION.Funcionalidad_Rol ON func_id = fr_funcionalidad JOIN CONGESTION.Rol ON rol_id = fr_rol AND rol_descripcion LIKE '%"+ txtNombre.Text +"%')");
        }

        private void cargarFuncionesCB(SqlDataReader reader)
        {
            while (reader.Read())
                selectorFuncionalidades.Items.Add(reader.GetString(0));

            reader.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dgvFuncionalidades.Rows.Add(selectorFuncionalidades.SelectedItem.ToString(),"Eliminar");
            selectorFuncionalidades.Items.Remove(selectorFuncionalidades.SelectedItem);
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            int numRegs = ClaseConexion.ResolverNonQuery("UPDATE CONGESTION.Rol SET rol_habilitado = 'TRUE' WHERE rol_descripcion = '"
                + txtNombre.Text + "'");

            if (numRegs == 0)
            {
                MessageBox.Show("No se pudo habilitar");
            }
            else
            {
                btnHabilitar.Enabled = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        
        {
            
            if (!nombreR.Equals(txtNombre.Text))
            {
                int numRegs = ClaseConexion.ResolverNonQuery("EXEC CONGESTION.sp_updatearRol '" + nombreR + "', '" + txtNombre.Text + "'");

                if (numRegs != 1)
                {
                    MessageBox.Show("No se pudo modificar el rol");
                }
                else
                {
                    this.guardarTodasFuncionalidades();
                    AbmRol.Listado form = new AbmRol.Listado();
                    this.Hide();
                    form.Show();
                }
            }
            else
            {
                this.guardarTodasFuncionalidades();
                AbmRol.Listado form = new AbmRol.Listado();
                this.Hide();
                form.Show();
            }
          
            
        }

        private void guardarFuncionalidadRol(string nombreFuncionalidad)
        {
            SqlCommand cmd = new SqlCommand("CONGESTION.sp_guardarFuncionalidadRol", ClaseConexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombreFuncionalidad", nombreFuncionalidad);
            cmd.Parameters.AddWithValue("@nombreRol", txtNombre.Text);
            cmd.ExecuteReader().Close();
        }

        private void guardarTodasFuncionalidades()
        {
            
            for (int i = 0; i < dgvFuncionalidades.Rows.Count - 1; i++)
            {
                guardarFuncionalidadRol(dgvFuncionalidades.Rows[i].Cells[0].Value.ToString());
                
            }

        }
    }
}
