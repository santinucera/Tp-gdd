using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmFactura
{
    public partial class Alta : Form
    {
        public Alta()
        {
            InitializeComponent();
        }

        private List<Item> listaItems = new List<Item>();

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            Item nuevoItem = new Item(txtConcepto.Text, Int32.Parse(txtCantidad.Text), Int32.Parse(txtMonto.Text));
            listaItems.Add(nuevoItem);
            txtMonto.Text = "";
            txtConcepto.Text = "";
            txtCantidad.Text = "";
            listBox1.Items.Add("Item"+listaItems.Count);
            listBox1.Items.Add("Concepto: " + nuevoItem.concepto + ",Monto: " + nuevoItem.monto.ToString() + ",Cantidad: " + nuevoItem.cantidad.ToString());
            listBox1.Items.Add(" ");
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            listaItems.Clear();
            listBox1.Items.Clear();
        }
    }
    public class Item
    {
        public Item(String concepto, int monto,int cantidad)
        {
            this.concepto = concepto;
            this.cantidad = cantidad;
            this.monto = monto;
        }
        
        public String concepto;
        public int cantidad;
        public int monto;
    }
}
