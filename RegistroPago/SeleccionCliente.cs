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
            new BusquedaCliente(this).Show();
        }

        public void mostrarNombreCliente()
        {
            lblCliente.Text = Cliente.nombreCompleto();
            
            this.btnCobro.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

            new PagoAgilFrba.Menu.MenuFuncionalidades().Show();
        }


        private void cargarHeader()
        {
            this.cargarFecha();
            this.cargarSucursal();
            Registro.fechaCobro = this.traerFechaDeDB();
            Registro.sucursal = 1;
        }

        private void cargarFecha()
        {
            fecha.Text = this.traerFechaDeDB().ToString("dd/MM/yyyy");
        }

        private DateTime traerFechaDeDB()
        {
            SqlDataReader dr = ClaseConexion.ResolverConsulta("SELECT GETDATE()");
            dr.Read();

            DateTime f = dr.GetDateTime(0);

            dr.Close();

            return f;
        }

        private void cargarSucursal()
        {
            //TODO traer la sucursal de la bd
        }

        private void btnCobro_Click(object sender, EventArgs e)
        {
            this.Close();

            new PagoAgilFrba.RegistroPago.MenuCobros().Show();
        }   
    }
}
