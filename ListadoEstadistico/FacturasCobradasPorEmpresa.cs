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
    public partial class FacturasCobradasPorEmpresa : Form
    {
        public FacturasCobradasPorEmpresa(string periodoR, int trimestreR)
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

        private void FacturasCobradasPorEmpresa_Load(object sender, EventArgs e)
        {
            cargarEmpresas(this.leerEmpresas());
        }

        private SqlDataReader leerEmpresas()
        {
            return ClaseConexion.ResolverConsulta("SELECT TOP 5 empr_nombre,CONGESTION.FN_CALCULAR_PORCENTAJE_FACT_COBRADAS_XEMPRESA(empr_id,'"+periodo+"',"+trimestre+")"
                                                 +" FROM CONGESTION.Empresa"
                                                 +" ORDER BY 2 DESC");

        }

        private void cargarEmpresas(SqlDataReader reader)
        {
            while (reader.Read())
            {
                dgvEmpresas.Rows.Add(reader.GetString(0).Trim(), reader.GetDecimal(1));
            }

            reader.Close();
        }
    }
}
