﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PagoAgilFrba;

namespace PagoAgilFrba.Menu
{
    public partial class MenuFuncionalidades : Form
    {
        public MenuFuncionalidades()
        {
            InitializeComponent();
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
	                                                +"JOIN CONGESTION.Rol on (fr_rol= rol_id) WHERE rol_descripcion = '"+Program.rol +"'");
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

        private void btnABMFactura_Click(object sender, EventArgs e)
        {
            AbmFactura.Menu form = new AbmFactura.Menu();
            this.Hide();
            form.Show();
        }

        private void btnABMEmpresa_Click_1(object sender, EventArgs e)
        {
            AbmEmpresa.MenuEmpresas form = new AbmEmpresa.MenuEmpresas();
            this.Hide();
            form.Show();
        }

        private void btnABMRol_Click(object sender, EventArgs e)
        {
            AbmRol.MenuRol form = new AbmRol.MenuRol();
            this.Hide();
            form.Show();
        }

        private void btnRegistroFactura_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PagoAgilFrba.RegistroPago.SeleccionCliente().Show();
        }

        private void btnABMCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmCliente.Cliente form = new AbmCliente.Cliente();
            form.Show();
        }

        private void btnRendicionFactura_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rendicion.Rendicion form = new Rendicion.Rendicion();
            form.Show();
        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListadoEstadistico.Listados form = new ListadoEstadistico.Listados();
            form.Show();
        }

        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Devolucion.Devolucion().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ElegirRol().Show();
        }

        
        
    }
}
