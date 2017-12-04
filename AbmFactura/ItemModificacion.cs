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
    public partial class ItemModificacion : Form
    {
        public ItemModificacion(int numero,int id)
        {
            InitializeComponent();
            this.numero = numero;
            this.id = id;
        }
        private int numero,id;

        private void ItemModificacion_Load(object sender, EventArgs e)
        {
            cargarItems(this.leerItems());
        }

        private void cargarItems(SqlDataReader reader)
        {
            while (reader.Read())
            {
                txtConcepto.Text = reader.GetString(0).Trim();
                txtMonto.Text = reader.GetDecimal(1).ToString();
                txtCantidad.Text = reader.GetDecimal(2).ToString();
            }

            reader.Close();
        }

        private SqlDataReader leerItems()
        {
            return ClaseConexion.ResolverConsulta("select isnull(item_concepto,''),item_monto,item_cantidad from CONGESTION.Item_Factura where item_id = " + id.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Items(numero).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtCantidad.Text = "";
            txtConcepto.Text = "";
            txtMonto.Text = "";
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCantidad.Text) || String.IsNullOrWhiteSpace(txtConcepto.Text) || String.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MessageBox.Show("Debe completar todos los campos", "Error");
            }
            else
            {
                try
                {
                    this.guardarItem();
                    MessageBox.Show("Item guardado correctamente", "Ok");
                    this.Close();
                    new Items(numero).Show();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void guardarItem()
        {
            int cant = Int32.Parse(txtCantidad.Text);
            Decimal monto = Decimal.Parse(txtMonto.Text);

            SqlCommand cmd = new SqlCommand("CONGESTION.sp_modificarItem", ClaseConexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@numero", numero);
            cmd.Parameters.AddWithValue("@monto", monto);
            cmd.Parameters.AddWithValue("@cantidad", cant);
            cmd.Parameters.AddWithValue("@concepto", txtConcepto.Text);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteReader().Close();
        }
    }
}
