using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmCliente
{
    public partial class Cliente : Form
    {
        //id de la fila seleccionada en el datagridview
        int id;

        public Cliente()
        {
            InitializeComponent();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            this.ActualizarGrid();
            chkHabilitado.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text == "" || txtDireccion.Text == "" || txtDni.Text == "" || txtFechaNacimiento.Text == "" || txtNombre.Text == "" || txtTelefono.Text == "")
            {
                MessageBox.Show("Completar campos");
                return;
            }

            try
            {
                chkHabilitado.Enabled = false;
                ClaseConexion.Conectar();
                int habilitado = this.GetChk();
                string consulta = "UPDATE CONGESTION.Cliente SET clie_nombre='" + txtNombre.Text + "', clie_apellido='" + txtApellido.Text + "', clie_dni=" + txtDni.Text + ", clie_fecNac='" + txtFechaNacimiento.Text + "', clie_mail='" + txtMail.Text + "', clie_telefono='" + txtTelefono.Text + "', clie_direccion='" + txtDireccion.Text + "', clie_codPostal='" + txtCodigoPostal.Text + "', clie_habilitado='" + habilitado + "' WHERE clie_id=" + id;
                ClaseConexion.ResolverNonQuery(consulta);
                this.ActualizarGrid();
                ClaseConexion.Desconectar();
                this.LimpiarCampos();
                MessageBox.Show("Operacion realizada correctamente");
                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
            chkHabilitado.Enabled = true;
            id = int.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtApellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtDni.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtDireccion.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtTelefono.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtMail.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtCodigoPostal.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtFechaNacimiento.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.Buscador();
        }

        private void txtBuscar2_KeyUp(object sender, KeyEventArgs e)
        {
            this.Buscador();
        }

        private void txtBuscar3_KeyUp(object sender, KeyEventArgs e)
        {
            this.Buscador();
        }

        private void Buscador()
        {
            ClaseConexion.ActualizarGrid(this.dataGridView1, "Cliente", "SELECT * from CONGESTION.Cliente WHERE clie_nombre LIKE '" + txtBuscar.Text + "%' AND clie_apellido LIKE '" + txtBuscar2.Text + "%' AND clie_dni LIKE '" + txtBuscar3.Text + "%'");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private int GetChk()
        {
            int habilitado;
            if (chkHabilitado.Checked)
            {
                habilitado = 1;
            }
            else
            {
                habilitado = 0;
            }
            return habilitado;
        }

        private void ActualizarGrid()
        {
            ClaseConexion.ActualizarGrid(this.dataGridView1, "Cliente", "SELECT clie_id, clie_nombre, clie_apellido, clie_dni, clie_direccion, clie_telefono, clie_mail, clie_codPostal, clie_fecNac, clie_habilitado FROM CONGESTION.Cliente");
            ClaseConexion.Desconectar();
        }

        private void LimpiarCampos()
        {
            txtBuscar.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCodigoPostal.Text = "";
            txtDireccion.Text = "";
            txtDni.Text = "";
            txtFechaNacimiento.Text = "";
            txtTelefono.Text = "";
            txtMail.Text = "";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            chkHabilitado.Checked = true;
            chkHabilitado.Enabled = false;
            btnActualizar.Enabled = true;
            btnGuardar.Enabled = false;
            LimpiarCampos();
            ActualizarGrid();
            ClaseConexion.Desconectar();
        }

    }
}
