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
using PagoAgilFrba.Menu;

namespace PagoAgilFrba.Devolucion
{
    public partial class Devolucion : Form
    {
        public Devolucion()
        {
            InitializeComponent();
        }

        private void Devolucion_Load(object sender, EventArgs e)
        {
            cargarFacturas(this.leerFacturas());
        }

        private void cargarFacturas(SqlDataReader reader)
        {
            while (reader.Read())
            {
                dgvFacturas.Rows.Add(reader.GetInt32(0), reader.GetInt32(1), reader.GetDecimal(2),reader.GetDecimal(3),
                    reader.GetString(4).Trim(), reader.GetDateTime(5), false, "Seleccionar");
            }

            reader.Close();

        }

        private SqlDataReader leerFacturas()
        {
            return ClaseConexion.ResolverConsulta("select distinct fact_num,reg_id,fact_total,"
                                                +"(select clie_dni from CONGESTION.Cliente where clie_id = fact_cliente),"
                                                +"(select empr_nombre from CONGESTION.Empresa where empr_id = fact_empresa),"
                                                +"reg_fecha_cobro from CONGESTION.Factura "
                                                +"join CONGESTION.Factura_Registro on (fact_num = freg_factura) "
                                                +"join CONGESTION.Registro on (freg_registro = reg_id)"
                                                +"where freg_devolucion is null and fact_rendicion is null");
        }

        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dgvFacturas.CurrentCell.ColumnIndex;
            int rowIndex = dgvFacturas.CurrentCell.RowIndex;

            if (columnIndex == 7)
            {
                if (!(Boolean)dgvFacturas.Rows[rowIndex].Cells[6].Value)
                {
                    foreach (DataGridViewRow row in dgvFacturas.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[6].Value))
                        {
                            row.Cells[6].Value = false;
                            row.Cells[7].Value = "Seleccionar";
                        }
                    }

                    dgvFacturas.Rows[rowIndex].Cells[6].Value = true;
                    dgvFacturas.Rows[rowIndex].Cells[7].Value = "Deseleccionar";

                }

                    
            }
            
        }

        private void btnRendir_Click(object sender, EventArgs e)
        {
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("CONGESTION.sp_DevolverFactura", ClaseConexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            int indexSelec = -1;
            int cantSelec = 0;

            foreach (DataGridViewRow row in dgvFacturas.Rows)
            {
                if (Convert.ToBoolean(row.Cells[6].Value))
                {
                    indexSelec = row.Index;
                    cantSelec = cantSelec + 1;
                }
            }

            if (indexSelec != -1 && cantSelec == 1)
            {
                try
                {
                    cmd.Parameters.AddWithValue("@factura", dgvFacturas.Rows[indexSelec].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@pago", dgvFacturas.Rows[indexSelec].Cells[1].Value);
                    cmd.Parameters.AddWithValue("@motivo", txtMotivo.Text.Trim());

                    reader = cmd.ExecuteReader();
                    reader.Read();

                    this.Hide();
                    MenuFuncionalidades form = new MenuFuncionalidades();
                    form.Show();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar una sola factura");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            new PagoAgilFrba.Menu.MenuFuncionalidades().Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtMotivo.Text = "";
            foreach (DataGridViewRow row in dgvFacturas.Rows)
            {
                if (Convert.ToBoolean(row.Cells[6].Value))
                {
                    row.Cells[6].Value = false;
                    row.Cells[7].Value = "Seleccionar";
                }
            }
        }
    }
}
