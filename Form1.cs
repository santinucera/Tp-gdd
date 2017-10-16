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

namespace PagoAgilFrba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = ClaseConexion.conexion;

            SqlCommand comando = new SqlCommand("GD2C2017.CONGESTION.sp_login", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", txtUsuario.Text);
            comando.Parameters.AddWithValue("@password", txtPassword.Text);
            
            conexion.Open();
                SqlDataReader leer = comando.ExecuteReader(CommandBehavior.CloseConnection);
                leer.Read();
                    // Guardo ID del usuario logueado
                    Program.idUsuarioLogueado = leer.GetInt32(leer.GetOrdinal("NRO"));
                leer.Close();
            conexion.Close();

            if (Program.idUsuarioLogueado != 0)
            {
                MessageBox.Show("Login correcto");
            }
            else
            {
                MessageBox.Show("Error usuario/contraseña");
            }

            txtPassword.Text = "";
            txtUsuario.Text = "";
        }
    }
}
