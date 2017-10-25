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
    public partial class ElegirRol : Form
    {
        public ElegirRol()
        {
            InitializeComponent();
        }

        private void ElegirRol_Load(object sender, EventArgs e)
        {
            this.cargarRoles();
        }

        private void cargarRoles()
        {
            SqlDataReader roles = this.leerRoles();

            while (roles.Read())
                selectorRol.Items.Add(roles.GetString(0));

            roles.Close();
        }

        private SqlDataReader leerRoles()
        {
            return ClaseConexion.ResolverConsulta("SELECT rol_descripcion FROM CONGESTION.Rol_Usuario JOIN CONGESTION.Rol on (ru_rol = rol_id)"
	                       + "JOIN CONGESTION.Usuario  on (ru_usuario=usua_id) where usua_username = '"+Program.username+"'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectorRol.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un rol para seguir");
            }
            else
            {
                Program.rol = selectorRol.SelectedItem.ToString();
                MenuFuncionalidades form = new MenuFuncionalidades();
                form.Show();
                this.Hide();
            }
        }
    }
}
