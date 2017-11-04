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
    public partial class ClientesMasPagos : Form
    {
        public ClientesMasPagos(String periodoR, int trimestreR)
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

        private void ClientesMasPagos_Load(object sender, EventArgs e)
        {
            cargarClientes(this.leerClientes());
        }

        private void cargarClientes(SqlDataReader reader)
        {
            while (reader.Read())
            {
                dgvClientes.Rows.Add(reader.GetString(0).Trim(), reader.GetInt32(1));
            }

            reader.Close();
        }

        private SqlDataReader leerClientes()
        {

            return ClaseConexion.ResolverConsulta("SELECT TOP 5 clie_nombre, count(*) FROM CONGESTION.viewClientesConMasPagos"
                + " WHERE YEAR(reg_fecha_cobro) = " + periodo + "AND (MONTH(reg_fecha_cobro) = " + (trimestre * 3).ToString()
                    + " OR MONTH(reg_fecha_cobro) = " + (trimestre * 3 - 1).ToString() + " OR MONTH(reg_fecha_cobro) = " + (trimestre * 3 - 2).ToString()
                    + ") GROUP BY clie_nombre ORDER BY 2 DESC");
        }

    }
}
