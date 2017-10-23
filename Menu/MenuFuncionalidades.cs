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

namespace PagoAgilFrba.Menu
{
    public partial class MenuFuncionalidades : Form
    {
        private String username;
        private String rol;
        
        public MenuFuncionalidades(String user, String roll)
        {
            InitializeComponent();
            this.username = user;
            this.rol = roll;
        }
        

        private void MenuFuncionalidades_Load(object sender, EventArgs e)
        {
            cargarFuncionalidades();
        }

        private void cargarFuncionalidades()
        {
            SqlDataReader funcionalidadesReader = this.leerFuncionalidades();

            while (funcionalidadesReader.Read())
            {
                habilitarBotones(funcionalidadesReader.GetString(0));
                
            }

            funcionalidadesReader.Close();
        }

        private SqlDataReader leerFuncionalidades()
        {
            return ClaseConexion.ResolverConsulta("select DISTINCT func_descripcion from CONGESTION.Funcionalidad JOIN CONGESTION.Funcionalidad_Rol on (func_id = fr_funcionalidad)"
	                                                +"JOIN CONGESTION.Rol on (fr_rol= rol_id) WHERE rol_descripcion = '"+rol +"'");
        }

        private void habilitarBotones(String nombre)
        {
            try
            {
                foreach (Control control in this.Controls)
                {
                    MessageBox.Show(control.Text);
                    if (control.Text == nombre)
                    {
                        control.Visible = true;
                    }
                }                         
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
