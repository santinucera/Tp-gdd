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
    public partial class EmpresasConMayorMontoRendido : Form
    {
        public EmpresasConMayorMontoRendido(String periodoR, int trimestreR)
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

        private void EmpresasConMayorMontoRendido_Load(object sender, EventArgs e)
        {
            cargarEmpresas(this.leerEmpresas());
        }

        private void cargarEmpresas(SqlDataReader reader)
        {
            while (reader.Read())
            {
                dgvEmpresas.Rows.Add(reader.GetString(0).Trim(),reader.GetDecimal(1));
            }

            reader.Close();
        }

        private SqlDataReader leerEmpresas()
        {      
            return ClaseConexion.ResolverConsulta("SELECT TOP 5 empr_nombre, (sum(rend_total) - sum(rend_comision))"
                                                   + " FROM CONGESTION.viewAuxiliar"
                                                   +" WHERE YEAR(rend_fecha) = " + periodo + "AND (MONTH(rend_fecha) = " + (trimestre * 3).ToString()
                                                   +" OR MONTH(rend_fecha) = " + (trimestre * 3 - 1).ToString() + " OR MONTH(rend_fecha) = " + (trimestre * 3 - 2).ToString()
                                                   + ") GROUP BY empr_nombre ORDER BY 2 DESC");
        }

    }
}
