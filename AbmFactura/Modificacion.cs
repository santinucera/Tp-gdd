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
        }

        private void cargarFacturas(SqlDataReader reader)
        {
            while (reader.Read())
            {
                txtTotal.Text = reader.GetInt32(0).ToString().Trim();
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
            cargarFacturas(leerFacturas());
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String[] stringSeparators = new String[] { "," };
            String[] cuit = comboBox1.SelectedItem.ToString().Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            int numRegs = ClaseConexion.ResolverNonQuery("UPDATE CONGESTION.Factura SET "
                                                        +"fact_cliente = (select clie_id from CONGESTION.Cliente where clie_dni =" +txtCliente.Text+"),"
                                                        +"fact_empresa = (select empr_id from CONGESTION.Empresa where empr_cuit ='" +cuit[1]+"'),"
                                                        +"fact_fecha_alta ='"+dtmAlta.Value.ToString()+"',fact_fecha_venc='"+dtpVencimiento.Value.ToString()+"',"
                                                        +"fact_total= "+txtTotal.Text+" WHere fact_num = "+txtNumero.Text);

            if (numRegs == 0)
            {
                MessageBox.Show("No se pudo guardar los cambios");
            }
            Listado form = new Listado();
            form.Show();
            this.Hide();
        }
    }
}
