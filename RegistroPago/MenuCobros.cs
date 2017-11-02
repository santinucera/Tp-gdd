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
            new PagoAgilFrba.RegistroPago.AgregarFactura(this).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Registro.cobrosPendientes.Clear();

            new PagoAgilFrba.RegistroPago.SeleccionCliente().Show();
        }


        private void cargarHeader()
        {
            this.cargarFecha();
            this.mostrarCliente();
            this.cargarDatosCabeceraDeRegistro();
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

        private void mostrarCliente()
        {
            lblCliente.Text = Cliente.nombreCompleto();
        }
        
        private void cargarDatosCabeceraDeRegistro()
        {
            Registro.cliente = Cliente.getId();
            Registro.fechaCobro = this.traerFechaDeDB();
            //Registro.sucursal = algo;
        }

        public void refrescarListaCobrosPendientes()
        {
            listaCobros.Items.Clear();

            Registro.cobrosPendientes.ForEach(delegate(CobroPendiente cobro) {listaCobros.Items.Add(cobro);});    //Wollok version manaos

            btnCobro.Enabled = true; //si entran a este metodo, es porque hay al menos una factura cargada, por lo que habilito el boton
        }

        private void btnCobro_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Registro.cobrosPendientes.Sum(cobro => cobro.getImporte()).ToString());
        }
    }
}
