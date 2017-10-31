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
    public partial class Listados : Form
    {
        public Listados()
        {
            InitializeComponent();
        }

        private void Listados_Load(object sender, EventArgs e)
        {
            this.cargarTrimestre();
            this.cargarListado();
            selectorTrimestre.SelectedIndex = -1;
            selectorListado.SelectedItem = -1;
        }

        private void cargarTrimestre()
        {
            selectorTrimestre.Items.Add("1");
            selectorTrimestre.Items.Add("2");
            selectorTrimestre.Items.Add("3");
            selectorTrimestre.Items.Add("4");
        }

        private void cargarListado()
        {
            selectorListado.Items.Add("Porcentaje de facturas cobradas por empresa");
            selectorListado.Items.Add("Empresas con mayor monto rendido");
            selectorListado.Items.Add("Clientes con mas pagos");
            selectorListado.Items.Add("Clientes mas cumplidores");
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

           if (this.chequear())
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else{
                this.revisarSeleccion();
            }
        }

        private bool chequear()
        {
            return (txtAnio.Text.Equals("") || selectorTrimestre.SelectedIndex == -1 || selectorListado.SelectedIndex == -1);
        }

        private void revisarSeleccion()
        {
            if (selectorListado.SelectedItem.ToString().Equals("Clientes con mas pagos"))
            {
                ListadoEstadistico.ClientesMasPagos form = new ListadoEstadistico.ClientesMasPagos(txtAnio.Text, selectorTrimestre.SelectedItem.ToString());
                form.Show();
            }
            else {
                if (selectorListado.SelectedItem.ToString().Equals("Clientes mas cumplidores"))
                {
                    ListadoEstadistico.ClientesCumplidores form = new ListadoEstadistico.ClientesCumplidores(txtAnio.Text, selectorTrimestre.SelectedItem.ToString());
                    form.Show();
                }
                else
                {
                    if (selectorListado.SelectedItem.ToString().Equals("Porcentaje de facturas cobradas por empresa"))
                    {
                        ListadoEstadistico.FacturasCobradasPorEmpresa form = new ListadoEstadistico.FacturasCobradasPorEmpresa(txtAnio.Text, selectorTrimestre.SelectedItem.ToString());
                        form.Show();
                    }
                    else
                    {
                        if (selectorListado.SelectedItem.ToString().Equals("Empresas con mayor monto rendido"))
                        {
                            ListadoEstadistico.EmpresasConMayorMontoRendido form = new ListadoEstadistico.EmpresasConMayorMontoRendido(txtAnio.Text, selectorTrimestre.SelectedItem.ToString());
                            form.Show();
                        }
                    }
                }
                }
        }

    }
}
