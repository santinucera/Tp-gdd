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
            try
            {
                if (this.estaHabilitada)
                {
                    this.setHabilitacionA(false);
                    MessageBox.Show("Empresa deshabilitada", "Ok");
                }
                else
                {
                    this.setHabilitacionA(true);
                    MessageBox.Show("Empresa habilitada", "Ok");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            
            this.Close();
            new Listado().Show();
        }

        private void mostrarEmpresa()
        {
            SqlDataReader empresaConRubro =
                ClaseConexion.ResolverConsulta("SELECT * FROM CONGESTION.listado_empresas WHERE empr_cuit = '" + cuit + "'");

            empresaConRubro.Read();

            lblNombre.Text = empresaConRubro.GetString(0);
            lblDireccion.Text = empresaConRubro.GetString(1);
            lblCuit.Text = empresaConRubro.GetString(2);
            rubro.Text = empresaConRubro.GetString(4);
            this.estaHabilitada = empresaConRubro.GetBoolean(3);

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
