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
        private Boolean estaPagaORendida;
        public Items(int numero, Boolean estaPagaORendida)
        {
            InitializeComponent();
            this.numero = numero;
            this.estaPagaORendida = estaPagaORendida;
        }

        private void Items_Load(object sender, EventArgs e)
        {
            label1.Text = "Items de la Factura numero: "+numero.ToString();
            cargarItems(this.leerItems());
            dgvItems.AllowUserToAddRows = false;
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dgvItems.CurrentCell.ColumnIndex;
            int rowIndex = dgvItems.CurrentCell.RowIndex;
            int item = (int)dgvItems.Rows[rowIndex].Cells[0].Value;
            int cantRows = dgvItems.RowCount;

            if (estaPagaORendida)
            {
                MessageBox.Show("No se puede modificar o eliminar factura que fue paga alguna vez o rendida");
                return;
            }

            if (columnIndex == 5)
                {//columna items
                    if(cantRows > 1)
                    {
                        AbmFactura.ItemBaja form = new ItemBaja(numero,item);
                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("No puede quedar factura sin items");
                    }

                    
                }
                else if (columnIndex == 4)
                {//columna baja
                    ItemModificacion form = new ItemModificacion(numero,item);
                    form.Show();
                    this.Hide();
                }
         
        }

        private void cargarItems(SqlDataReader reader)
        {
            while (reader.Read())
            {

                dgvItems.Rows.Add(reader.GetInt32(0), reader.GetString(1).Trim(), reader.GetDecimal(2), reader.GetDecimal(3), "Modificar", "Eliminar");
            }

            reader.Close();

        }
        
        private SqlDataReader leerItems()
        {
            return ClaseConexion.ResolverConsulta("select item_id,isnull(item_concepto,''),item_monto,item_cantidad from CONGESTION.Item_Factura where item_fact = "+numero.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (estaPagaORendida)
            {
                MessageBox.Show("No se puede modificar o eliminar factura que fue paga alguna vez o rendida");
                return;
            }
            new AgregarItem(numero).Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Listado().Show();
        }
    }
}
