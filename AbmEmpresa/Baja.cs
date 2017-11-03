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

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class Baja : Form
    {
        private String cuit;
        private Boolean estaHabilitada;

        public Baja(String cuit)
        {
            InitializeComponent();
            this.cuit = cuit;
        }

        private void Baja_Load(object sender, EventArgs e)
        {
            this.mostrarEmpresa();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.estaHabilitada)
            {
                if (!this.puedeDeshabilitar())
                    MessageBox.Show("La empresa tiene facturas pagadas sin rendir", "Error");
                else
                {
                    this.setHabilitacionA(false);
                    MessageBox.Show("Empresa deshabilitada", "Ok");
                }
            }
            else
            {
                this.setHabilitacionA(true);
                MessageBox.Show("Empresa habilitada", "Ok");
            }
            
            this.Close();
            new Listado().Show();
        }

        private Boolean puedeDeshabilitar()
        {
            MessageBox.Show(ClaseConexion.ResolverFuncion("SELECT CONGESTION.controlarFacturasPagadasRendidasDe(" + this.cuit + ")").ToString());

            return (int)ClaseConexion.ResolverFuncion("SELECT CONGESTION.controlarFacturasPagadasRendidasDe(" + this.cuit + ")") == 1;
        }

        private void mostrarEmpresa()
        {
            SqlDataReader empresaConRubro =
                ClaseConexion.ResolverConsulta("SELECT * FROM CONGESTION.listado_empresas WHERE empr_cuit = '" + cuit + "'");

            empresaConRubro.Read();

            lblNombre.Text = empresaConRubro.GetString(1);
            lblDireccion.Text = empresaConRubro.GetString(2);
            lblCuit.Text = empresaConRubro.GetString(3);
            lblRubro.Text = empresaConRubro.GetString(5);
            this.estaHabilitada = empresaConRubro.GetBoolean(4);

            if (!this.estaHabilitada)  //si ya esta habilitada
            {
                button1.Text = "Habilitar";
            }

            empresaConRubro.Close();
        }

        private void setHabilitacionA(Boolean habilitacion)
        {
            SqlCommand cmd = new SqlCommand("CONGESTION.sp_cambiarHabilitacionDe", ClaseConexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cuit", cuit);
            cmd.Parameters.AddWithValue("@habilitacion", habilitacion);

            cmd.ExecuteReader().Close();
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            new Listado().Show();
        }
        
    }
}
