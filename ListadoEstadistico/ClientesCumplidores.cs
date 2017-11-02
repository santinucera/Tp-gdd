using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoAgilFrba.ListadoEstadistico
{
    public partial class ClientesCumplidores : Form
    {
        public ClientesCumplidores(String periodoR, int trimestreR)
        {
            InitializeComponent();
            periodo = periodoR;
            trimestre = trimestreR;

        }
        String periodo;
        int trimestre;

       

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private SqlDataReader leerClientes()
        {

            String subSelect = "SELECT count(*) FROM CONGESTION.clientesCumplidores  WHERE c.clie_id=clie_id AND YEAR(reg_fecha_cobro) = " + periodo
                + " AND (MONTH(reg_fecha_cobro) = " + (trimestre * 3).ToString() + " OR MONTH(reg_fecha_cobro) = "
                + (trimestre * 3 - 1).ToString() + " OR MONTH(reg_fecha_cobro) = " + (trimestre * 3 - 2).ToString()+ ")";

            String subSelect2 = "SELECT count(*) FROM CONGESTION.Factura WHERE fact_cliente = c.clie_id AND "
                + "YEAR(fact_fecha_alta) = " + periodo + " AND (MONTH(fact_fecha_alta) = " + (trimestre * 3).ToString()
                + " OR MONTH(fact_fecha_alta) = " + (trimestre * 3 - 1).ToString() +
                " OR MONTH(fact_fecha_alta) = " + (trimestre * 3 - 2).ToString() + ")";

            String consulta = "SELECT TOP 5 clie_nombre,((" + subSelect + ")*100/(" + subSelect2 + "))"
                + " FROM CONGESTION.Cliente c ORDER BY 2 DESC";
            MessageBox.Show(consulta);

            return ClaseConexion.ResolverConsulta("SELECT TOP 5 clie_nombre,(("+subSelect+")*100/("+subSelect2+"))"
             +" FROM CONGESTION.Cliente c ORDER BY 2 DESC");
     
        }

        private void cargarClientes(SqlDataReader reader)
        {
            while (reader.Read())
            {
                dgvClientes.Rows.Add(reader.GetString(0).Trim());
            }

            reader.Close();
        }


        private void ClientesCumplidores_Load(object sender, EventArgs e)
        {
            cargarClientes(this.leerClientes());
            
        }

      
    }
}
