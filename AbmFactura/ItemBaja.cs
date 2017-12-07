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
    public partial class ItemBaja : Form
    {
        public ItemBaja(int numero,int id)
        {
            InitializeComponent();
            this.numero = numero;
            this.id = id;
        }
        private int numero;
        private int id; 

        private void ItemBaja_Load(object sender, EventArgs e)
        {
            cargarItems(leerItems());
        }

        private void cargarItems(SqlDataReader reader)
        {
            while (reader.Read())
            {

                lblConcepto.Text = reader.GetString(0).Trim();
                lblMonto.Text = reader.GetDecimal(1).ToString();
                lblCantidad.Text = reader.GetDecimal(2).ToString();
            }

            reader.Close();

        }

        private SqlDataReader leerItems()
        {
            return ClaseConexion.ResolverConsulta("select isnull(item_concepto,''),item_monto,item_cantidad from CONGESTION.Item_Factura where item_fact = " + numero.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Items(numero,false).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.bajarItem();
                MessageBox.Show("Item eliminado correctamente", "Ok");
                this.Close();
                new Items(numero,false).Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void bajarItem()
        {
            SqlCommand cmd = new SqlCommand("CONGESTION.sp_eliminarItem", ClaseConexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id.ToString());
            cmd.Parameters.AddWithValue("@numero", numero.ToString());
            
            cmd.ExecuteReader().Close();
        }
    }
}
