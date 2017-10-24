using System;
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
    public partial class Baja : Form
    {
        public Baja(String codigo,String direccion,String nombre,Boolean baja)
        {
            InitializeComponent();
            lblCodigo.Text= codigo;
            lblDireccion.Text = direccion;
            lblNombre.Text = nombre;
            if (baja)
            {
                button1.Text = "Bajar";
            }
            else
            {
                button1.Text = "Habilitar";
            }
            this.baja = baja;
        }

        private Boolean baja;
        
        private void button1_Click(object sender, EventArgs e)
        {
            int habiltacion = 1;
            if(baja)
            {
                habiltacion = 0;
            }
                        
            int numRegs = ClaseConexion.ResolverNonQuery("UPDATE CONGESTION.Sucursal SET  suc_habilitado= "+habiltacion.ToString()+" WHERE suc_codPostal ='"+lblCodigo.Text +"'" );
            if(numRegs==0){
                MessageBox.Show("No se pudo "+button1.Text);
            }
            this.Hide();
        }

        private void Baja_Load(object sender, EventArgs e)
        {

        }
    }
}
