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
    public partial class Items : Form
    {
        private int numero;
        public Items(int numero)
        {
            InitializeComponent();
            this.numero = numero;
        }

        private void Items_Load(object sender, EventArgs e)
        {
            label1.Text = "Items de la Factura numero: "+numero.ToString();
            cargarItems(this.leerItems());
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
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
            return ClaseConexion.ResolverConsulta("select isnull(item_concepto,''),item_monto,item_cantidad from CONGESTION.Item_Factura where item_fact = "+numero.ToString());
        }
    }
}
