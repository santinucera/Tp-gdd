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
        List<String> intentosFallidos = new List<String>();
        
        public Form1()
        {
            InitializeComponent();
            ClaseConexion.Conectar();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            try
            {
                SqlDataReader reader;
                reader = ClaseConexion.ResolverConsulta("SELECT usua_username, usua_password, usua_habilitado FROM [CONGESTION].[Usuario] WHERE usua_username = '" + txtUsuario.Text + "'");
                reader.Read();
                String password = reader.GetString(1);
                bool habilitado = reader.GetBoolean(2);
                reader.Close();

                if (!habilitado)
                    throw new UsuarioDeshabilitadoException("El usuario no esta habilitado");
                if (false)//!this.ValidarPassword(txtPassword.Text))
                {
                    intentosFallidos.Add(txtUsuario.Text);
                    if (intentosFallidos.Count(user => user == txtUsuario.Text) == 3)
                    {
                        ClaseConexion.ResolverNonQuery("UPDATE CONGESTION.Usuario SET usua_habilitado = 0 WHERE usua_username = '" + txtUsuario.Text + "'");
                        MessageBox.Show("Has sobrepasado la cantidad de intentos posibles, el usuario " + txtUsuario.Text + "ha sido deshabilitado");
                    }
                    else
                    {
                        throw new PasswordInvalidaException("Password incorrecta");
                    }
                }
                else
                {
                    ElegirRol form= new ElegirRol(txtUsuario.Text);
                    form.Show();
                    this.Hide();
                }

            }
            catch (PasswordInvalidaException t)
            {
                MessageBox.Show(t.Message);

            }
            catch (UsuarioDeshabilitadoException ud)
            {
                MessageBox.Show(ud.Message);
            }
            catch (SqlException sqle)
            {
                MessageBox.Show("No se pudo deshabilitar el usuario");
            }
            catch (Exception m)
            {
                MessageBox.Show("No existe un usuario con ese nombre");
            }
        }

        private bool ValidarPassword(String password)
        {
            String s = (String)ClaseConexion.ResolverFuncion("SELECT CONGESTION.Hashear_Password('" + password+ "')");
            return s.Equals(password);
        }
    }
}
