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
                dgvFacturas.Rows.Add(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2).Trim() + " " + reader.GetString(8).Trim(),
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
                                                    + "isnull((SELECT freg_factura from CONGESTION.Factura_Registro WHERE freg_factura = fact_num),0)"
                                                    + ",isnull(fact_rendicion,0),"
                                                    + "(SELECT clie_apellido from CONGESTION.Cliente WHERE clie_id = fact_cliente)"
                                                    +" from CONGESTION.Factura");
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

            if (dgvFacturas.RowCount > 1)
            {
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
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            txtNumero.Text = "";
            txtCliente.Text = "";
            selectorEmpresa.Text = "";
            dtpAlta.Value = DateTime.Now;
            dtpVencimiento.Value = DateTime.Now;

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            dgvFacturas.Rows.Clear();

            //String consulta = "select suc_nombre,suc_direccion,suc_codPostal,suc_habilitado from CONGESTION.Sucursal "
                                //+ "WHERE suc_nombre LIKE '%" + txtNombre.Text + "%' and suc_codPostal LIKE '%" + txtCodigo.Text + "%' and suc_direccion LIKE '%" + txtDireccion.Text + "%'";

            //cargarFacturas(ClaseConexion.ResolverConsulta(consulta));
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
