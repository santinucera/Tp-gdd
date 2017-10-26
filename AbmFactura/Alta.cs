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

        private void Alta_Load(object sender, EventArgs e)
        {
            cargarEmpresas(this.leerEmpresas());
            calendar.MinDate= DateTime.Now;
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

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            int total=0;

            foreach (Item element in listaItems)
            {
                total =total+ (element.cantidad * element.monto);
            }

            String[] stringSeparators = new String[] {","};
            String[] cuit = selectorEmpresa.SelectedItem.ToString().Split(stringSeparators,StringSplitOptions.RemoveEmptyEntries);
            int dni = Int32.Parse(txtCliente.Text);
            int numRegs = ClaseConexion.ResolverNonQuery("INSERT INTO CONGESTION.Factura(fact_num,fact_fecha_alta,fact_fecha_venc,fact_total,fact_empresa,fact_cliente)"
                                                            +" Values("+txtNumero.Text+",'"+DateTime.Now.ToString()+"','"+calendar.Value.ToString()+"',"+total.ToString()+","
                                                            + "(SELECT empr_id from CONGESTION.Empresa WHERE empr_cuit = '" + cuit[1].Trim() + "'),"
                                                            + "(SELECT clie_id from CONGESTION.Cliente WHERE clie_dni = " + dni.ToString() + "))");

            foreach (Item element in listaItems)
            {
                ClaseConexion.ResolverNonQuery("INSERT INTO CONGESTION.Item_Factura (item_fact,item_concepto,item_cantidad,item_monto)"
                                                +"VALUES("+txtNumero.Text+",'"+element.concepto+"',"+element.cantidad.ToString()+","+element.monto.ToString()+")");
            }
            
            
            if (numRegs == 0)
            {
                MessageBox.Show("No se pudo agregar la empresa");
            }
            this.Hide();
            Listado form = new Listado();
            form.Show();
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
