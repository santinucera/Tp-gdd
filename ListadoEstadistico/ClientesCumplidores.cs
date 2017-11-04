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
            return ClaseConexion.ResolverConsulta("SELECT TOP 5 clie_nombre,CONGESTION.FN_CALCULAR_PORCENTAJE_FACT_PAGADAS(clie_id,'"+periodo+"',"+trimestre+")"
                                                    + "FROM CONGESTION.Cliente"
                                                        +" ORDER BY 2 DESC");
     
        }

        private void cargarClientes(SqlDataReader reader)
        {
            while (reader.Read())
            {
                dgvClientes.Rows.Add(reader.GetString(0).Trim(),reader.GetDecimal(1));
            }

            reader.Close();
        }


        private void ClientesCumplidores_Load(object sender, EventArgs e)
        {
            cargarClientes(this.leerClientes());
            
        }

      
    }
}
