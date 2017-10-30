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
    public partial class SeleccionCliente : Form
    {
        public SeleccionCliente()
        {
            InitializeComponent();
            this.cargarHeader();
        }

        private void buscarCliente_Click(object sender, EventArgs e)
        {
            new BusquedaCliente().Show();
            lblCliente.Text = Cliente.nombreCompleto();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new PagoAgilFrba.Menu.MenuFuncionalidades().Show();
        }


        private void cargarHeader()
        {
            this.cargarFecha();
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
    }
}
