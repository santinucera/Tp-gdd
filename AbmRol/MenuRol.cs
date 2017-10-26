using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmRol
{
    public partial class MenuRol : Form
    {
        public MenuRol()
        {
            InitializeComponent();
        }

        private void MenuRol_Load(object sender, EventArgs e)
        {

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmRol.Alta form = new AbmRol.Alta();
            form.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu.MenuFuncionalidades form = new Menu.MenuFuncionalidades();
            form.Show();
        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmRol.Listado form = new AbmRol.Listado();
            form.Show();
        }


    }
}
