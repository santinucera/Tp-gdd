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
    public partial class Baja : Form
    {
        public Baja(String cuit,String direccion,String nombre,Boolean baja)
        {
            InitializeComponent();
            lblCuit.Text= cuit;
            lblDireccion.Text = direccion;
            lblNombre.Text = nombre;
            if (baja)
            {
                button1.Text = "Bajar";
                lblSeguro.Text = "¿Seguro que desea dar de baja esta sucursal?";
            }
            else
            {
                button1.Text = "Habilitar";
                lblSeguro.Text = "¿Seguro que desea habilitar esta sucursal?";
            }
            this.baja = baja;
        }

        private Boolean baja;
        
        private void button1_Click(object sender, EventArgs e)
        {
            int habilitacion = 1;
            if(baja)
            {
                habilitacion = 0;
            }
                        
            int numRegs = ClaseConexion.ResolverNonQuery("UPDATE CONGESTION.Empresa SET  empr_habilitado= "+habilitacion.ToString()+" WHERE empr_cuit ='"+lblCuit.Text +"'" );
            if(numRegs==0){
                MessageBox.Show("No se pudo "+button1.Text);
            }
            this.Hide();
            Listado form = new Listado();
            form.Show();
        }

        private void Baja_Load(object sender, EventArgs e)
        {

        }
    }
}
