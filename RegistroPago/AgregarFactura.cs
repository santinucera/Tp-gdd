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
        private MenuCobros parent;

        public AgregarFactura(MenuCobros parent)
        {
            InitializeComponent();

            this.parent = parent;
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            this.parent.refrescarListaCobrosPendientes();
            this.Close();
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargarHeader()
        {
            fecha.Text = Registro.fechaCobro.ToString("dd / MM / yyyy");
            sucursal.Text = Registro.sucursal;
            
            this.mostrarCliente();
        }

        private void mostrarCliente()
        {
            lblApellido.Text = Cliente.getApellido();
            lblNombre.Text = Cliente.getNombre();
            lblDni.Text = Cliente.getDni();
        }

        private void cargarListaFacturasPendientes()
        {

            String consulta = "SELECT fact_num, fact_empresa, fact_fecha_venc, fact_total FROM CONGESTION.Factura "
                            +"WHERE fact_cliente = " + Cliente.getId().ToString().Trim() ;


            SqlDataReader dr = ClaseConexion.ResolverConsulta(consulta);

            while (dr.Read())
            {
                if (this.validarEntradaDelReader(dr))
                {
                    listaFacturas.Items.Add(new CobroPendiente(dr.GetInt32(0), dr.GetInt32(1), dr.GetDateTime(2), dr.GetDecimal(3)));
                }
            }

            dr.Close();
        }

        private Boolean validarEntradaDelReader(SqlDataReader dr)
        {
            Boolean fechaCorrecta = dr.GetDateTime(2).CompareTo(Registro.fechaCobro) <= 0;
            Boolean importeCorrecto = dr.GetDecimal(3) > 0;

            return fechaCorrecta && importeCorrecto && this.facturaImpagaDe(dr);
        }

        private Boolean facturaImpagaDe(SqlDataReader dr)
        {
            SqlDataReader drAux = ClaseConexion.ResolverConsulta("SELECT COUNT(*) FROM CONGESTION.Factura_Registro WHERE freg_factura = "+ dr.GetInt32(0));

            drAux.Read();

            int resultado = drAux.GetInt32(0);

            drAux.Close();

            return !Convert.ToBoolean(resultado);
        }

        private void habilitarBotonGuardar()
        {
            if (Registro.cobrosPendientes.Count() > 0)
                this.btnGuardar.Enabled = true;
        }

        private void listaFacturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listaFacturas.Items.Count > 0)
                this.btnAgregar.Enabled = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Registro.cobrosPendientes.Add(listaFacturas.SelectedItem as CobroPendiente);
            listaFacturas.Items.Remove(listaFacturas.SelectedItem);

            btnAgregar.Enabled = false;

            this.habilitarBotonGuardar();
        }

        private void AgregarFactura_Load(object sender, EventArgs e)
        {
            this.cargarHeader();
            this.cargarListaFacturasPendientes();
            btnAgregar.Enabled = true;
        }
    }
}
