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
    public partial class AgregarItem : Form
    {
        public AgregarItem(int numero)
        {
            InitializeComponent();
            this.numero = numero;
        }
        private int numero;

        private void btnAgregarItem_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCantidad.Text) && String.IsNullOrWhiteSpace(txtConcepto.Text) && String.IsNullOrWhiteSpace(txtMonto.Text))
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
            int monto= Int32.Parse(txtMonto.Text);
            
            SqlCommand cmd = new SqlCommand("CONGESTION.sp_guardarItem", ClaseConexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@numero", numero.ToString());
            cmd.Parameters.AddWithValue("@monto", monto.ToString());
            cmd.Parameters.AddWithValue("@cantidad", cant.ToString());
            cmd.Parameters.AddWithValue("@concepto", txtConcepto.Text);

            cmd.ExecuteReader().Close();
        }
    }
}
