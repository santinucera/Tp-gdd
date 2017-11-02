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
    public partial class AgregarFactura : Form
    {
        private Empresa empresa;
        private DateTime fechaVto;

        public AgregarFactura()
        {
            InitializeComponent();
            this.cargarHeader();
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
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

            fecha.Text = dr.GetDateTime(0).ToString("dd / MM / yyyy");

            dr.Close();
        }

        private void cargarSucursal()
        {
            //TODO traer la sucursal de la bd
        }

        private void mostrarCliente()
        {
            lblApellido.Text = Cliente.getApellido();
            lblNombre.Text = Cliente.getNombre();
            lblDni.Text = Cliente.getDni();
        }

        private void btnFecha_Click(object sender, EventArgs e)
        {
            new SeleccionarFecha(this).Show();
        }

        public void setFechaVto(DateTime unaFecha)
        {
            this.fechaVto = unaFecha;
            lblFechaVto.Text = fechaVto.Date.ToString("dd/MM/yyyy");

            this.habilitarBotonGuardar();
        }

        private void btnEmpresas_Click(object sender, EventArgs e)
        {
            new PagoAgilFrba.RegistroPago.BuscarEmpresa(this).Show();
        }

        public void setEmpresa(Empresa empr)
        {
            this.empresa = empr;
            lblEmpresa.Text = empresa.ToString();

            this.habilitarBotonGuardar();
        }

        private void habilitarBotonGuardar()
        {
            if (this.fecha != null && this.empresa != null)
                this.btnGuardar.Enabled = true;
        }
    }
}
