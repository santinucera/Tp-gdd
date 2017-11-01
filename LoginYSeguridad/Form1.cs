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
using PagoAgilFrba.LoginYSeguridad;
using PagoAgilFrba.Menu;

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
            SqlDataReader reader,readerLogIn;
            SqlCommand cmd = new SqlCommand("CONGESTION.sp_login",ClaseConexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuario",txtUsuario.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);

            readerLogIn = cmd.ExecuteReader();
            readerLogIn.Read();
            int id = readerLogIn.GetInt32(readerLogIn.GetOrdinal("NRO"));
            readerLogIn.Close();

            if (id != 0)
            {
                ClaseConexion.ResolverNonQuery("UPDATE CONGESTION.Usuario SET usua_cantIntentos=0  WHERE usua_username = '" + txtUsuario.Text + "'");
                reader = ClaseConexion.ResolverConsulta("SELECT usua_habilitado FROM [CONGESTION].[Usuario] WHERE usua_id = " + id);
                reader.Read();
                bool habilitado = reader.GetBoolean(0);
                reader.Close();

                if (!habilitado)
                {
                    MessageBox.Show("El usuario no esta habilitado");
                }
                else
                {
                    Program.username = txtUsuario.Text;
                    ElegirRol form = new ElegirRol();
                    form.Show();
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("Contraseña incorrecta");
                reader = ClaseConexion.ResolverConsulta("SELECT usua_cantIntentos FROM [CONGESTION].[Usuario]  WHERE usua_username = '" + txtUsuario.Text + "'");
                reader.Read();
                if (reader.GetInt32(0) == 2)
                {
                    ClaseConexion.ResolverNonQuery("UPDATE CONGESTION.Usuario SET usua_habilitado = 0,usua_cantIntentos=0  WHERE usua_username = '" + txtUsuario.Text + "'");
                    MessageBox.Show("Has sobrepasado la cantidad de intentos posibles, el usuario " + txtUsuario.Text + "ha sido deshabilitado");
                }
                else
                {
                    ClaseConexion.ResolverNonQuery("UPDATE CONGESTION.Usuario SET usua_cantIntentos = "+(reader.GetInt32(0)+1).ToString()+" WHERE usua_username = '" + txtUsuario.Text + "'");
                }
                reader.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
