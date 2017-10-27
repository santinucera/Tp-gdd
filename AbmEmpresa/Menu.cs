using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.Menu;

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
            this.Close();
            new Alta().Show();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            this.Close();
            new Listado().Show();
        }

        private void MenuEmpresas_Load(object sender, EventArgs e)
        {
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            new MenuFuncionalidades().Show();
        }

    }
}