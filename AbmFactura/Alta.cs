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
using System.Configuration;

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
            try
            {
                Item nuevoItem = new Item(txtConcepto.Text, Decimal.Parse(txtMonto.Text), Int32.Parse(txtCantidad.Text));
                listaItems.Add(nuevoItem);
                txtMonto.Text = "";
                txtConcepto.Text = "";
                txtCantidad.Text = "";
                listBox1.Items.Add("Item"+listaItems.Count);
                listBox1.Items.Add("Concepto: " + nuevoItem.concepto + ",Monto: " + nuevoItem.monto.ToString() + ",Cantidad: " + nuevoItem.cantidad.ToString());
                listBox1.Items.Add(" ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message);
            }
            
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            listaItems.Clear();
            listBox1.Items.Clear();
        }

        private void Alta_Load(object sender, EventArgs e)
        {
            cargarEmpresas(this.leerEmpresas());

            String fechaArchivo = ConfigurationManager.AppSettings["current_date"].ToString().TrimEnd();
            DateTime dt = DateTime.ParseExact(fechaArchivo, "dd-MM-yyyy", null);

            calendar.MinDate = dt.AddDays(1);
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
            if (String.IsNullOrWhiteSpace(txtCliente.Text) || String.IsNullOrWhiteSpace(txtNumero.Text) || String.IsNullOrWhiteSpace(selectorEmpresa.Text) || selectorEmpresa.Text == "")
            {
                MessageBox.Show("Debe completar todos los campos", "Error");
            }

            else
            {
                if(!listaItems.Any())
                {
                    MessageBox.Show("Debe ingresar algun item a la factura", "Error");
                }
                else
                {
                    try
                    {
                        this.guardarFactura();
                        this.Close();
                        new Menu().Show();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
                
            }
        }

        private void guardarFactura()
        {
            
                try
                {
                    String[] stringSeparators = new String[] { "," };
                    String[] cuit = selectorEmpresa.SelectedItem.ToString().Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                    int dni = Int32.Parse(txtCliente.Text);
                    DateTime fechaSistema = DateTime.ParseExact(ConfigurationManager.AppSettings["current_date"].ToString().TrimEnd(), "dd-MM-yyyy", null);

                    SqlCommand cmd = new SqlCommand("CONGESTION.sp_guardarFactura", ClaseConexion.conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@numero", txtNumero.Text);
                    cmd.Parameters.AddWithValue("@dni", dni.ToString());
                    cmd.Parameters.AddWithValue("@cuit", cuit[1].Trim());
                    cmd.Parameters.AddWithValue("@fechaVen", calendar.Value);
                    cmd.Parameters.AddWithValue("@fechaAlta", fechaSistema);

                    DataTable tabla = new DataTable();
                    tabla.Columns.Add("monto", typeof(int));
                    tabla.Columns.Add("cantidad", typeof(int));
                    tabla.Columns.Add("concepto", typeof(String));

                    DataRow fila;

                    foreach (Item item in listaItems)
                    {
                        fila = tabla.NewRow();
                        fila[0] = item.monto;
                        fila[1] = item.cantidad;
                        fila[2] = item.concepto;
                        tabla.Rows.Add(fila);
                    }

                    cmd.Parameters.AddWithValue("@listaFacturas", tabla);

                    cmd.ExecuteReader().Close();

                    MessageBox.Show("Factura guardada correctamente", "Ok");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCliente.Text = "";
            txtNumero.Text = "";
            selectorEmpresa.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Menu().Show();
        }

    }
    public class Item
    {
        public Item(String concepto, Decimal monto, int cantidad)
        {
            this.concepto = concepto;
            this.cantidad = cantidad;
            this.monto = monto;
        }
        
        public String concepto;
        public int cantidad;
        public Decimal monto;
    }
}
