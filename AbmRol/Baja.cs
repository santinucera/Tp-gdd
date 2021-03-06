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

namespace PagoAgilFrba.AbmRol
{
    public partial class Baja : Form
    {
        public Baja(string nombre,Boolean habilitado)
        {
            estaHabilitado = habilitado;
            InitializeComponent();
            labelNombre.Text = nombre;
        }

        private Boolean estaHabilitado;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            AbmRol.Listado form = new AbmRol.Listado();
            this.Hide();
            form.Show();
        }

        private void Baja_Load(object sender, EventArgs e)
        {
            cargarFunciones(this.leerFunciones());

            if (estaHabilitado)
            {
                btnBaja.Text = "Dar baja";
            }
            else
            {
                btnBaja.Text = "Habilitar";
            }

        }

        private SqlDataReader leerFunciones()
        {
            //trae las funcionalidades del rol
            return ClaseConexion.ResolverConsulta("SELECT func_descripcion FROM CONGESTION.Funcionalidad JOIN CONGESTION.Funcionalidad_Rol"
            + " ON func_id = fr_funcionalidad JOIN CONGESTION.Rol ON rol_id = fr_rol AND rol_descripcion LIKE'%" + labelNombre.Text + "%'");
        }

        private void cargarFunciones(SqlDataReader reader)
        {
            while (reader.Read())
            {
                dgvFuncionalidades.Rows.Add(reader.GetString(0), "Eliminar");
            }

            reader.Close();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            this.darDeBaja();
        }

        private void darDeBaja()
        {
            //a traves del numRegs verifica que se haya cambiado una fila en la bd cuando quiere deshabilitar ese rol

            string consulta;

            if (estaHabilitado)
            {
                consulta= "UPDATE CONGESTION.Rol SET rol_habilitado = 0 WHERE rol_descripcion = '"
                + labelNombre.Text + "'";
            }
            else
            {
                consulta= "UPDATE CONGESTION.Rol SET rol_habilitado = 1 WHERE rol_descripcion = '"
                + labelNombre.Text + "'";
            }



            int numRegs = ClaseConexion.ResolverNonQuery(consulta);

            if (numRegs == 0)
            {
                MessageBox.Show("No se pudo modificar estado");
            }
            else
            {
                AbmRol.Listado form = new AbmRol.Listado();
                this.Hide();
                form.Show();
            }
        }

    }
}
