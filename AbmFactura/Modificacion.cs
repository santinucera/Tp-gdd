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

namespace PagoAgilFrba.AbmFactura
{
    public partial class Modificacion : Form
    {
        public Modificacion(int numero)
        {
            InitializeComponent();
            this.numero = numero;
        }
        private int numero;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Listado form = new Listado();
            form.Show();
        }

        private void Modificacion_Load(object sender, EventArgs e)
        {
            cargarEmpresas(leerEmpresas());
            cargarFacturas(leerFacturas());
            dtpVencimiento.MinDate = dtmAlta.Value.AddDays(1);
        }

        private void cargarFacturas(SqlDataReader reader)
        {
            while (reader.Read())
            {
                txtTotal.Text = reader.GetDecimal(0).ToString().Trim();
                txtCliente.Text = reader.GetDecimal(1).ToString().Trim();
                comboBox1.SelectedIndex = comboBox1.FindStringExact(reader.GetString(2) + ", " + reader.GetString(5));
                dtmAlta.Text = reader.GetDateTime(3).ToString();
                dtpVencimiento.Text = reader.GetDateTime(4).ToString();
            }
            txtNumero.Text = numero.ToString();
            reader.Close();
            
        }

        private SqlDataReader leerFacturas()
        {
            return ClaseConexion.ResolverConsulta("select fact_total,"
                                                    + "(SELECT clie_dni from CONGESTION.Cliente WHERE clie_id = fact_cliente),"
                                                    + "(SELECT empr_nombre from CONGESTION.Empresa WHERE empr_id = fact_empresa),"
                                                    + "fact_fecha_alta,fact_fecha_venc,"
                                                     + "(SELECT empr_cuit from CONGESTION.Empresa WHERE empr_id = fact_empresa)"
                                                    + " from CONGESTION.Factura WHERE fact_num = " + numero.ToString());
        }

        private void cargarEmpresas(SqlDataReader reader)
        {
            while (reader.Read())
                comboBox1.Items.Add(reader.GetString(0) + ", " + reader.GetString(1));

            reader.Close();

        }

        private SqlDataReader leerEmpresas()
        {
            return ClaseConexion.ResolverConsulta("select empr_nombre,empr_cuit from CONGESTION.Empresa");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtpVencimiento.MinDate = dtmAlta.Value;
            cargarFacturas(leerFacturas());
            dtpVencimiento.MinDate = dtmAlta.Value.AddDays(1);
            txtCliente.Text = "";
            comboBox1.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String[] stringSeparators = new String[] { "," };
            String[] cuit = comboBox1.SelectedItem.ToString().Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            if (String.IsNullOrWhiteSpace(txtCliente.Text) || String.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Debe completar todos los campos", "Error");
            }
            else
            {
                try
                {
                    this.guardarFactura();
                    this.Close();
                    new Listado().Show();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            
        }

        private void guardarFactura()
        {
            String[] stringSeparators = new String[] { "," };
            String[] cuit = comboBox1.SelectedItem.ToString().Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            int dni = Int32.Parse(txtCliente.Text);

            SqlCommand cmd = new SqlCommand("CONGESTION.sp_modificarFactura", ClaseConexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@numero", txtNumero.Text);
            cmd.Parameters.AddWithValue("@dni", dni.ToString());
            cmd.Parameters.AddWithValue("@cuit", cuit[1].Trim());
            cmd.Parameters.AddWithValue("@fechaVen", dtpVencimiento.Value);

            cmd.ExecuteReader().Close();
            
        }
    }
}
