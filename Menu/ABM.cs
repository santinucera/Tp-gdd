using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Menu
{
    public partial class ABM : Form
    {
        public ABM(FuncionalidadABM funcion)
        {
            InitializeComponent();
            this.funcionalidad = funcion;
        }

        private FuncionalidadABM funcionalidad;

        private void ABM_Load(object sender, EventArgs e)
        {

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            this.funcionalidad.abrirVentanaAlta();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            this.funcionalidad.abrirVentanaListado();
        }


    }
}
