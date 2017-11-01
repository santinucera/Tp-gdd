using System;
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
    public partial class ClientesMasPagos : Form
    {
        public ClientesMasPagos(string periodoR, int trimestreR)
        {
            InitializeComponent();
            periodo = periodoR;
            trimestre = trimestreR;
        }

        string periodo;
        int trimestre;

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
