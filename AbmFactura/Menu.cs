using PagoAgilFrba.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmFactura
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmFactura.Alta form = new Alta();
            form.Show();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmFactura.Listado form = new Listado();
            form.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuFuncionalidades form = new MenuFuncionalidades();
            form.Show();
        }
    }
}
