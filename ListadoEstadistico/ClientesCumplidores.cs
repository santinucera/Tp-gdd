﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.ListadoEstadistico
{
    public partial class ClientesCumplidores : Form
    {
        public ClientesCumplidores(string periodoR, string trimestreR)
        {
            InitializeComponent();
            periodo = periodoR;
            trimestre = trimestreR;

        }
        string periodo;
        string trimestre;
    }
}
