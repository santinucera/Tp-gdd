﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmSucursal
{
    public partial class Modificacion : Form
    {
        public Modificacion(String codigo)
        {
            InitializeComponent();
            this.codigo = codigo;
        }

        private String codigo;

        private void Modificacion_Load(object sender, EventArgs e)
        {

        }
    }
}
