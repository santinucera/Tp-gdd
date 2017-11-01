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

namespace PagoAgilFrba.RegistroPago
{
    public partial class MenuCobros : Form
    {
        public MenuCobros()
        {
            InitializeComponent();
            this.cargarHeader();
        }

        private void agregarFactura_Click(object sender, EventArgs e)
        {
            new PagoAgilFrba.RegistroPago.AgregarFactura().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new PagoAgilFrba.RegistroPago.SeleccionCliente().Show();
        }


        private void cargarHeader()
        {
            this.cargarFecha();
            this.mostrarCliente();
        }

        private void cargarFecha()
        {
            SqlDataReader dr = ClaseConexion.ResolverConsulta("SELECT GETDATE()");
            dr.Read();

            fecha.Text = dr.GetDateTime(0).ToString("dd/MM/yyyy");

            dr.Close();
        }

        private void cargarSucursal()
        {
            //TODO traer la sucursal de la bd
        }

        private void mostrarCliente()
        {
            lblCliente.Text = Cliente.nombreCompleto();
        }
    }
}
