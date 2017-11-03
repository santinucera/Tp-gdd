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
    public partial class EfectuarCobro : Form
    {
        int medioPagoSeleccionado;

        public EfectuarCobro()
        {
            InitializeComponent();
            this.cargarHeader();
            this.cargarComboMedios();
        }

        private void cargarHeader()
        {
            this.lblFecha.Text = Registro.fechaCobro.ToString("dd/MM/yyyy");
            this.lblCliente.Text = Cliente.nombreCompleto();
            //this.lblSucursal.Text = Registro.sucursal;
            this.lblImporte.Text = Registro.cobrosPendientes.Sum(cobro => cobro.getImporte()).ToString();
        }

        private void cargarComboMedios()
        {
            SqlDataReader dr = ClaseConexion.ResolverConsulta("SELECT med_descripcion FROM CONGESTION.Medio_Pago WHERE med_descripcion IS NOT NULL");

            while (dr.Read())
            {
                listaMedios.Items.Add(dr.GetString(0));
            }

            dr.Close();
        }

        private void listaMedios_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataReader dr = ClaseConexion.ResolverConsulta("SELECT med_id FROM CONGESTION.Medio_Pago WHERE med_descripcion = '" + listaMedios.SelectedItem + "'");

            dr.Read();
            medioPagoSeleccionado = dr.GetInt32(0);
            dr.Close();

            btnGuardar.Enabled = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            new MenuCobros().Show();
        }

        private DataTable armarTablaParaGuardar()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("cliente", typeof(int));
            tabla.Columns.Add("sucursal", typeof(int));
            tabla.Columns.Add("fechaCobro", typeof(DateTime));
            tabla.Columns.Add("factura", typeof(int));
            tabla.Columns.Add("empresa", typeof(int));
            tabla.Columns.Add("fechaVto", typeof(DateTime));
            tabla.Columns.Add("medioPago", typeof(int));
            tabla.Columns.Add("importe", typeof(float));

            DataRow fila;

            foreach (CobroPendiente unCobro in Registro.cobrosPendientes)
            {
                fila = tabla.NewRow();
                fila["cliente"] = unCobro.getCliente();
                fila["sucursal"] = unCobro.getSucursal();
                fila["fechaCobro"] = unCobro.getFechaCobro();
                fila["factura"] = unCobro.getFactura();
                fila["empresa"] = unCobro.getEmpresa();
                fila["fechaVto"] = unCobro.getFechaVto();
                fila["medioPago"] = this.medioPagoSeleccionado;
                fila["importe"] = unCobro.getImporte();

                tabla.Rows.Add(fila);
            }

            return tabla;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DataTable tabla = this.armarTablaParaGuardar();

            SqlCommand cmd = new SqlCommand("CONGESTION.sp_guardarRegistroCobros", ClaseConexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@listaCobros", tabla);
            
            try
            {
                cmd.ExecuteReader().Close();
                MessageBox.Show("Registro efectuado correctamente", "OK");

                this.Close();
                new PagoAgilFrba.RegistroPago.SeleccionCliente().Show();
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message,"Error");
            }
        }
    }
}
