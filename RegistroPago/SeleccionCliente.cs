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
using System.Globalization;

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
        }

        private void cargarFecha()
        {
            fecha.Text = this.traerFechaDeDB().ToString("dd/MM/yyyy");
        }

        private DateTime traerFechaDeDB()
        {

            String fechaArchivo = ConfigurationManager.AppSettings["current_date"].ToString().TrimEnd();

            return DateTime.ParseExact(fechaArchivo,"yyyy-dd-MM",null);
        }

        private void cargarSucursal()
        {
            Registro.sucursal = Program.sucursal;
            this.sucursal.Text = Registro.sucursal;
        }

        private void btnCobro_Click(object sender, EventArgs e)
        {
            this.Close();

            new PagoAgilFrba.RegistroPago.MenuCobros().Show();
        }   
    }
}
