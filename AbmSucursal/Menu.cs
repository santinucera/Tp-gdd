﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.Menu;

namespace PagoAgilFrba.AbmSucursal
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            Alta form = new Alta();
            this.Hide();
            form.Show();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            Listado form = new Listado();
            this.Hide();
            form.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuFuncionalidades form = new MenuFuncionalidades();
            form.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
