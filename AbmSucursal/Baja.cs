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

namespace PagoAgilFrba.AbmSucursal
{
    public partial class Baja : Form
    {
        public Baja(String codigo,String direccion,String nombre,Boolean baja)
        {
            InitializeComponent();
            lblCodigo.Text= codigo;
            this.codigo = Int32.Parse(codigo);
            lblDireccion.Text = direccion;
            lblNombre.Text = nombre;
            if (baja)
            {
                button1.Text = "Bajar";
                lblSeguro.Text = "¿Seguro que desea dar de baja esta sucursal?";
            }
            else
            {
                button1.Text = "Habilitar";
                lblSeguro.Text = "¿Seguro que desea habilitar esta sucursal?";
            }
            this.baja = baja;
        }

        private Boolean baja;
        private int codigo;
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.modificarSucursal();
                String mensaje;
                if (baja)
                {
                    mensaje = "Baja realizada correctamente";
                }
                else
                {
                    mensaje = "Habilitacion realizada correctamente";
                }
                
                
                MessageBox.Show(mensaje);
                this.Close();
                new Listado().Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void Baja_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Listado().Show();
        }

        private void modificarSucursal()
        {
            int habilitacion = 1;
            if (baja)
            {
                habilitacion = 0;
            }
            
            SqlCommand cmd = new SqlCommand("CONGESTION.sp_modificarHabilitacionSucursal", ClaseConexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.AddWithValue("@habilitacion", habilitacion);

            cmd.ExecuteReader().Close();
        }
    }
}
