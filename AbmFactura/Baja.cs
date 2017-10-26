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
    public partial class Baja : Form
    {
        private int numero;
        public Baja(int numero)
        {
            InitializeComponent();
            this.numero = numero;
        }

        private void Baja_Load(object sender, EventArgs e)
        {
            cargarItems(leerItems());
            cargarFacturas(leerFacturas());
            lblNumero.Text = numero.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            int numRegs2 = ClaseConexion.ResolverNonQuery("delete from CONGESTION.Item_Factura where item_fact =" + numero.ToString());
            int numRegs = ClaseConexion.ResolverNonQuery("delete from CONGESTION.Factura where fact_num ="+numero.ToString());
            
            if (numRegs == 0 && numRegs2 ==0)
            {
                MessageBox.Show("No se pudo borrar la factura");
            }
            this.Hide();
            Listado form = new Listado();
            form.Show();
        }

        private void cargarItems(SqlDataReader reader)
        {
            while (reader.Read())
            {

                dgvItems.Rows.Add(reader.GetString(0).Trim(), reader.GetDecimal(1), reader.GetDecimal(2), "Modificar");
            }

            reader.Close();

        }

        private SqlDataReader leerItems()
        {
            return ClaseConexion.ResolverConsulta("select isnull(item_concepto,''),item_monto,item_cantidad from CONGESTION.Item_Factura where item_fact = " + numero.ToString());
        }

        private void cargarFacturas(SqlDataReader reader)
        {
            while (reader.Read())
            {
                lblTotal.Text = reader.GetInt32(0).ToString();
                lblCliente.Text= reader.GetDecimal(1).ToString();
                lblEmpresa.Text= reader.GetString(2).Trim(); 
                lblAlta.Text = reader.GetDateTime(3).ToString();
                lblBaja.Text = reader.GetDateTime(4).ToString();
            }

            reader.Close();

        }

        private SqlDataReader leerFacturas()
        {
            return ClaseConexion.ResolverConsulta("select fact_total,"
                                                    + "(SELECT clie_dni from CONGESTION.Cliente WHERE clie_id = fact_cliente),"
                                                    + "(SELECT empr_nombre from CONGESTION.Empresa WHERE empr_id = fact_empresa),"
                                                    + "fact_fecha_alta,fact_fecha_venc"
                                                    + " from CONGESTION.Factura WHERE fact_num = "+numero.ToString());
        }
    }
}
