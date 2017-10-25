using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class MenuEmpresas : Form
    {
        public MenuEmpresas()
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

        private void MenuEmpresas_Load(object sender, EventArgs e)
        {

        }

    }
}