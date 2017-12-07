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
            this.Text = "Elegir Rol";
            this.cargarRoles();
            this.cargarSelectorSucursales();
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
            Program.rol = selectorRol.SelectedItem.ToString();
            
            if(!this.rolSeleccionadoEsAdministrador())
                Program.sucursal = selectorSucursales.SelectedItem.ToString();
            
            new MenuFuncionalidades().Show();
            this.Close();
        }

        private void selectorRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rolSeleccionadoEsAdministrador())
            {
                this.mostrarSelectorSucursales(false);
                this.habilitarAcceso(true);
            }
            else
            {
                this.mostrarSelectorSucursales(true);
                this.habilitarAcceso(false);
            }
        }

        private Boolean rolSeleccionadoEsAdministrador()
        {
            return selectorRol.SelectedItem.ToString().Contains("Administrador");
        }

        private void mostrarSelectorSucursales(Boolean habil)
        {
            lblSucursal.Visible = habil;
            selectorSucursales.Visible = habil;
        }

        private void habilitarAcceso(Boolean habil)
        {
            btnAcceder.Enabled = habil;
        }

        private void cargarSelectorSucursales()
        {
            String select = "SELECT suc_nombre FROM CONGESTION.Sucursal";
            String joinSucUser = " JOIN CONGESTION.Usuario_Sucursal on (usuc_sucursal = suc_id)";
            String joinUser = " JOIN CONGESTION.Usuario on (usuc_usuario = usua_id)";
            String where = " WHERE usua_username = '" + Program.username + "' and suc_habilitado=1";

            SqlDataReader dr = ClaseConexion.ResolverConsulta(select + joinSucUser + joinUser + where);

            while (dr.Read())
                selectorSucursales.Items.Add(dr.GetString(0));

            dr.Close();
        }

        private void selectorSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.habilitarAcceso(true);
        }
    }
}
