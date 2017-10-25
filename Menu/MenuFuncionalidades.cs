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
using PagoAgilFrba.Menu;

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
                    if (nombre.StartsWith(control.Text))
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

        private void btnABMSucursal_Click(object sender, EventArgs e)
        {
            AbmSucursal.Menu form = new AbmSucursal.Menu();
            this.Hide();
            form.Show();
        }

        private void btnABMEmpresa_Click(object sender, EventArgs e)
        {
            AbmEmpresa.MenuEmpresas form = new AbmEmpresa.MenuEmpresas();
            this.Hide();
            form.Show();
        }
        
    }
}
