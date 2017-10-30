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
using PagoAgilFrba.Menu;

namespace PagoAgilFrba.Rendicion
{
    public partial class Rendicion : Form
    {
        public Rendicion()
        {
            InitializeComponent();
        }

        private String cuitEmpresa;

        private void Rendicion_Load(object sender, EventArgs e)
        {
            cargarEmpresas(this.leerEmpresas());
        }

        private void cargarEmpresas(SqlDataReader reader)
        {
            while (reader.Read())
                selectorEmpresa.Items.Add(reader.GetString(0) + ", " + reader.GetString(1));

            reader.Close();

        }

        private SqlDataReader leerEmpresas()
        {
            return ClaseConexion.ResolverConsulta("select empr_nombre,empr_cuit from CONGESTION.Empresa");
        }

        private void btnObtener_Click(object sender, EventArgs e)
        {
            if (selectorEmpresa.SelectedItem != null)
            {
                String[] stringSeparators = new String[] {","};
                String[] cuit = selectorEmpresa.SelectedItem.ToString().Split(stringSeparators,StringSplitOptions.RemoveEmptyEntries);

                cuitEmpresa = cuit[1].Trim();
                cargarFacturas(this.leerFacturas());
            }
            else
            {
                MessageBox.Show("Debe seleccionar una empresa");
            }
        }

        private void cargarFacturas(SqlDataReader reader)
        {
            while (reader.Read())
            {
                dgvFacturas.Rows.Add(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2).Trim() + " " + reader.GetString(5).Trim(),
                    reader.GetDateTime(3), reader.GetDateTime(4),false,"Seleccionar");
            }

            reader.Close();

        }

        private SqlDataReader leerFacturas()
        {
            return ClaseConexion.ResolverConsulta("select DISTINCT fact_num, fact_total,(SELECT clie_nombre from CONGESTION.Cliente WHERE clie_id = fact_cliente),"
                                                    +"fact_fecha_alta,fact_fecha_venc,(SELECT clie_apellido from CONGESTION.Cliente WHERE clie_id = fact_cliente)"
                                                    +"from CONGESTION.Factura JOIN CONGESTION.Empresa on (fact_empresa = empr_id)"
                                                    + "where empr_cuit = '" + cuitEmpresa + "' and (SELECT freg_factura from CONGESTION.Factura_Registro WHERE freg_factura = fact_num) is null "
                                                    + "and fact_rendicion is null");
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuFuncionalidades form = new MenuFuncionalidades();
            form.Show();
        }

        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dgvFacturas.CurrentCell.ColumnIndex;
            int rowIndex = dgvFacturas.CurrentCell.RowIndex;

            if (dgvFacturas.RowCount > 1)
            {
                if (columnIndex == 6)
                {
                    dgvFacturas.Rows[rowIndex].Cells[5].Value = true;
                    dgvFacturas.Rows[rowIndex].Cells[6].Value= "Deseleccionar";
                }
            }
        }

        private void btnRendir_Click(object sender, EventArgs e)
        {
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("CONGESTION.sp_RendirFacturas", ClaseConexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@comision", txtComision.Text);
            cmd.Parameters.AddWithValue("@cuit", cuitEmpresa);

            DataTable tabla = new DataTable();
            tabla.Columns.Add("numero", typeof(int));
            tabla.Columns.Add("total", typeof(int));

            DataRow fila;
            Boolean hayAlgunoSeleccionado=false;

            foreach(DataGridViewRow row in dgvFacturas.Rows){
                if(Convert.ToBoolean(row.Cells[5].Value)){
                    fila = tabla.NewRow();
                    fila[0] = Convert.ToInt32(row.Cells[0].Value);
                    fila[1] = Convert.ToInt32(row.Cells[1].Value);
                    tabla.Rows.Add(fila);
                    hayAlgunoSeleccionado = true;
                }                
            }

            cmd.Parameters.AddWithValue("@listaFacturas", tabla);

            if(hayAlgunoSeleccionado){
            reader= cmd.ExecuteReader();
            reader.Read();

            this.Hide();
            MenuFuncionalidades form = new MenuFuncionalidades();
            form.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar alguna factura");
            }
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvFacturas.Rows.Clear();
            selectorEmpresa.SelectedIndex = 0;
            txtComision.Text = "";
        }
    }
}
