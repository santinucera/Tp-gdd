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
            this.refrescarListaCobrosPendientes();
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
            fecha.Text = Registro.fechaCobro.ToString("dd/MM/yyyy");
        }

        private void cargarSucursal()
        {
            //algo = Registro.sucursal
        }

        private void mostrarCliente()
        {
            lblCliente.Text = Cliente.nombreCompleto();
        }
        
        private void cargarDatosCabeceraDeRegistro()
        {
            Registro.cliente = Cliente.getId();
        }

        public void refrescarListaCobrosPendientes()
        {
            listaCobros.Items.Clear();

            if (Registro.cobrosPendientes.Count > 0)
            {
                Registro.cobrosPendientes.ForEach(delegate(CobroPendiente cobro) { listaCobros.Items.Add(cobro); });    //Wollok version manaos
                btnCobro.Enabled = true;
            }
        }

        private void btnCobro_Click(object sender, EventArgs e)
        {
            this.Close();
            new EfectuarCobro().Show();
        }
    }
}
