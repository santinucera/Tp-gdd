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
    public partial class Listado : Form
    {
        public Listado()
        {
            InitializeComponent();
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmFactura.Menu form = new Menu();
            form.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Listado_Load(object sender, EventArgs e)
        {
            cargarFacturas(this.leerFacturas());
            cargarEmpresas(this.leerEmpresas());
        }

        private void cargarFacturas(SqlDataReader reader)
        {
            while (reader.Read())
            {
                dgvFacturas.Rows.Add(reader.GetInt32(0), reader.GetDecimal(1), reader.GetString(2).Trim() + " " + reader.GetString(8).Trim(),
                    reader.GetString(3).Trim() , reader.GetDateTime(4), reader.GetDateTime(5), "Items", reader.GetInt32(6) != 0, reader.GetInt32(7) != 0, "Modificar","Baja");
            }

            reader.Close();

        }

        private SqlDataReader leerFacturas()
        {
            return ClaseConexion.ResolverConsulta("select DISTINCT fact_num, fact_total,"
                                                    +"(SELECT clie_nombre from CONGESTION.Cliente WHERE clie_id = fact_cliente),"
                                                    +"(SELECT empr_nombre from CONGESTION.Empresa WHERE empr_id = fact_empresa),"
                                                    + "fact_fecha_alta,fact_fecha_venc,"
                                                    + "isnull((SELECT distinct freg_factura from CONGESTION.Factura_Registro WHERE freg_factura = fact_num and freg_devolucion is null ),0)"
                                                    + ",isnull(fact_rendicion,0),"
                                                    + "(SELECT clie_apellido from CONGESTION.Cliente WHERE clie_id = fact_cliente)"
                                                    +" from CONGESTION.Factura ");
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

        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dgvFacturas.CurrentCell.ColumnIndex;
            int rowIndex = dgvFacturas.CurrentCell.RowIndex;

            int numero = (int)dgvFacturas.Rows[rowIndex].Cells[0].Value;
            Boolean estaPagaORendida = (Boolean)dgvFacturas.Rows[rowIndex].Cells[7].Value || (Boolean)dgvFacturas.Rows[rowIndex].Cells[8].Value;
                
            if (columnIndex == 6)
            {//columna items
                AbmFactura.Items form= new Items(numero);
                form.Show();
                this.Hide();
            }
            else if (columnIndex == 9 && !estaPagaORendida)
            {//columna baja
                AbmFactura.Modificacion form = new Modificacion(numero);
                form.Show();
                this.Hide();
            }
            else if (columnIndex == 10 && !estaPagaORendida)
            {//columna baja
                AbmFactura.Baja form = new Baja(numero);
                form.Show();
                this.Hide();
            }
            
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            txtNumero.Text = "";
            txtCliente.Text = "";
            selectorEmpresa.SelectedItem = null;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            dgvFacturas.Rows.Clear();
            String cuit;

            if (!String.IsNullOrWhiteSpace(selectorEmpresa.Text))
            {
                String[] stringSeparators = new String[] { "," };
                String[] cuitt = selectorEmpresa.SelectedItem.ToString().Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                cuit = cuitt[1].Trim();
            }
            else
            {
                cuit= "";
            }

            String consulta = "select DISTINCT fact_num, fact_total,clie_nombre ,empr_nombre,fact_fecha_alta,fact_fecha_venc,"
                                + "isnull((SELECT DISTINCT freg_factura from CONGESTION.Factura_Registro WHERE freg_factura = fact_num),0)"
                                + ",isnull(fact_rendicion,0),clie_apellido"
                                + " from CONGESTION.Factura join CONGESTION.Cliente on (clie_id = fact_cliente)"
                                + "join CONGESTION.Empresa on (empr_id = fact_empresa)"
                                +"WHERE clie_dni LIKE '%"+txtCliente.Text.Trim()+"%' and fact_num LIKE '%"+txtNumero.Text.Trim()+"%' and empr_cuit LIKE '%"+cuit+"%'";

            cargarFacturas(ClaseConexion.ResolverConsulta(consulta));
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
