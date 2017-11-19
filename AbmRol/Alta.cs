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
    public partial class Alta : Form
    {
        public Alta()
        {
            InitializeComponent();
        }

        private void Alta_Load(object sender, EventArgs e)
        {
            cargarFuncionalidades(this.leerFuncionalidades());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(selectorFuncs.Text))
            {
                dgvFunciones.Rows.Add(selectorFuncs.SelectedItem.ToString());
                selectorFuncs.Items.Remove(selectorFuncs.SelectedItem);
            }
            else
            {
                MessageBox.Show("Debe selecccionar una funcionalidad");
            }
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txtNombre.Text == "" || dgvFunciones.Rows.Count == 1)           //comprueba que se hayan completado todos los campos
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else
            {
                if (txtNombre.Text.Length > 100)
                    MessageBox.Show("El nombre es demasiado largo");            //comprueba que no exceda el maximo definido en la bd
                else
                {
                    String query = "INSERT INTO CONGESTION.Rol (rol_descripcion,rol_habilitado) VALUES ('" + txtNombre.Text + "','TRUE')"; 

                    SqlCommand command = new SqlCommand(query, ClaseConexion.conexion);
                    try
                    {
                        //intenta insertar el rol

                        command.ExecuteNonQuery();
                        guardarTodasFuncionalides();
                        this.Hide();
                        Listado form = new Listado();
                        form.Show();

                    }
                    catch (SqlException ex)
                    {
                        if (ex.Message.Contains("clave duplicada"))     //contains para ver si la excepcion es porque ya existe ese rol
                            MessageBox.Show("El Rol ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }

                
                
            
        }

      
        private void cargarFuncionalidades(SqlDataReader reader)
        {
            while (reader.Read())
                selectorFuncs.Items.Add(reader.GetString(0));

            reader.Close();

        }

        private SqlDataReader leerFuncionalidades()
        {
            return ClaseConexion.ResolverConsulta("SELECT func_descripcion FROM CONGESTION.Funcionalidad");
        }

        

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            selectorFuncs.Items.Clear();
            cargarFuncionalidades(this.leerFuncionalidades());
            dgvFunciones.Rows.Clear();
            txtNombre.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbmRol.MenuRol form = new AbmRol.MenuRol();
            this.Hide();
            form.Show();
        }

        private void guardarFuncionalidadRol(string nombreFuncionalidad)
        {
            SqlCommand cmd = new SqlCommand("CONGESTION.sp_guardarFuncionalidadRol", ClaseConexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombreFuncionalidad", nombreFuncionalidad);
            cmd.Parameters.AddWithValue("@nombreRol", txtNombre.Text);
            cmd.ExecuteReader().Close();
        }

        private void guardarTodasFuncionalides()
        {
            int i = 0;
            while (i < dgvFunciones.Rows.Count-1)
            {
                guardarFuncionalidadRol(dgvFunciones.Rows[i].Cells[0].Value.ToString());
                i++;
            }

        }

        private void dgvFunciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    
    }
}
