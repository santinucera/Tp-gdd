﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoAgilFrba.AbmCliente
{
    public partial class Cliente : Form
    {
        //id de la fila seleccionada en el datagridview
        int id;
        int dni;

        public Cliente()
        {
            InitializeComponent();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            this.Text = "ABM Cliente";
            this.ActualizarGrid();
            chkHabilitado.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text == "" || txtDireccion.Text == "" || txtDni.Text == "" || txtNombre.Text == "" || txtMail.Text == "" || txtCodigoPostal.Text == "")
            {
                MessageBox.Show("Completar campos");
                return;
            }

            string query = "SELECT count(clie_mail) as NRO FROM CONGESTION.cliente WHERE clie_mail = '" + txtMail.Text + "' and clie_dni <> "+dni.ToString();
            SqlDataReader leer = ClaseConexion.ResolverConsulta(query);
            leer.Read();
            int nro = leer.GetInt32(leer.GetOrdinal("NRO"));
            leer.Close();

            // Verificacion. Si el mail ya existe, lo informa; caso contrario modifica
            if (nro != 0)
            {
                MessageBox.Show("Mail ya existente");
                return;
            }
            string query2 = "SELECT count(clie_dni) as NRO FROM CONGESTION.cliente where clie_dni = " + txtDni.Text;
            SqlDataReader leer2 = ClaseConexion.ResolverConsulta(query2);
            leer2.Read();
            int nro2 = leer2.GetInt32(leer2.GetOrdinal("NRO"));
            leer2.Close();
            
            if(nro2!=0 && dni.ToString() != txtDni.Text)
            {
                MessageBox.Show("DNI ya existente");
                return;
            }
            

            try
            {
                chkHabilitado.Enabled = false;
                int habilitado = this.GetChk();
                string consulta = "UPDATE CONGESTION.Cliente SET clie_nombre='" + txtNombre.Text + "', clie_apellido='" + txtApellido.Text + "', clie_dni=" + txtDni.Text + ", clie_fecNac='" + dtpFechaNacimiento.Value + "', clie_mail='" + txtMail.Text + "', clie_telefono='" + txtTelefono.Text + "', clie_direccion='" + txtDireccion.Text + "', clie_codPostal='" + txtCodigoPostal.Text + "', clie_habilitado='" + habilitado + "' WHERE clie_id=" + id;
                ClaseConexion.ResolverNonQuery(consulta);
                this.ActualizarGrid();
                this.LimpiarCampos();
                MessageBox.Show("Operacion realizada correctamente");
                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true;
                btnDarAlta.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnDarAlta.Enabled = false;
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
            chkHabilitado.Checked = (Boolean)dataGridView1.CurrentRow.Cells[9].Value;
            dtpFechaNacimiento.Value = (DateTime)dataGridView1.CurrentRow.Cells[8].Value;
            dni = Int32.Parse(txtDni.Text);
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
        }

        private void LimpiarCampos()
        {
            txtBuscar.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCodigoPostal.Text = "";
            txtDireccion.Text = "";
            txtDni.Text = "";
            txtTelefono.Text = "";
            txtMail.Text = "";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PagoAgilFrba.Menu.MenuFuncionalidades().Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            chkHabilitado.Checked = true;
            chkHabilitado.Enabled = false;
            btnActualizar.Enabled = true;
            btnGuardar.Enabled = false;
            btnDarAlta.Enabled = true;
            txtBuscar.Text = "";
            txtBuscar2.Text = "";
            txtBuscar3.Text = "";
            LimpiarCampos();
            this.ActualizarGrid();
        }

        private void btnDarAlta_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text == "" || txtDireccion.Text == "" || txtDni.Text == "" || txtNombre.Text == "" || txtMail.Text == "" || txtCodigoPostal.Text == "")
            {
                MessageBox.Show("Completar campos");
                return;
            }
            
            try
            {
                string query = "SELECT count(clie_mail) as NRO FROM CONGESTION.cliente WHERE clie_mail = '"+ txtMail.Text +"'";
                SqlDataReader leer = ClaseConexion.ResolverConsulta(query);
                leer.Read();
                int nro = leer.GetInt32(leer.GetOrdinal("NRO"));
                leer.Close();


                string query2 = "SELECT count(clie_dni) as NRO FROM CONGESTION.cliente WHERE clie_dni = '" + txtDni.Text + "'";
                SqlDataReader leer2 = ClaseConexion.ResolverConsulta(query2);
                leer2.Read();
                int nro2 = leer2.GetInt32(leer2.GetOrdinal("NRO"));
                leer2.Close();


                // Verificacion. Si el mail ya existe, lo informa; caso contrario da el alta
                if (nro != 0)
                {
                    MessageBox.Show("Mail ya existente");
                }
                else if(nro2!=0)
                {
                    MessageBox.Show("DNI ya existente");
                }
                else
                {
                    string consulta = "INSERT INTO CONGESTION.Cliente (clie_nombre, clie_apellido, clie_dni, clie_direccion, clie_telefono, clie_mail, clie_codPostal, clie_fecNac, clie_habilitado) VALUES ('" + txtNombre.Text + "', '" + txtApellido.Text + "', '" + txtDni.Text + "', '" + txtDireccion.Text + "', '" + txtTelefono.Text + "', '" + txtMail.Text + "', '" + txtCodigoPostal.Text + "', '" + dtpFechaNacimiento.Value + "', 1)";
                    ClaseConexion.ResolverNonQuery(consulta);
                    this.ActualizarGrid();
                    this.LimpiarCampos();
                    MessageBox.Show("Operacion realizada correctamente");
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingresar todos los datos. Error: "+ ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
