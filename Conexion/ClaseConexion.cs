using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Configuration;

namespace PagoAgilFrba
{
    class ClaseConexion
    {
        
        static string server = ConfigurationManager.AppSettings["server"].ToString();
        static string user = ConfigurationManager.AppSettings["user"].ToString();
        static string password = ConfigurationManager.AppSettings["password"].ToString();

        // declaro una variable de conexion global
        public static SqlConnection conexion = getConnection();


        public static void Conectar()
        {
            try
            {
                conexion.Open();
            }
            catch (SqlException e)
            {
                MessageBox.Show("No se pudo establecer la conexion a la base de datos." + e.Message);
            }
        }
       
        public static SqlDataReader ResolverConsulta(String query)
        {
            return new SqlCommand(query, conexion).ExecuteReader();
        }

        public static int ResolverNonQuery(String nonQuery)
        {
            return new SqlCommand(nonQuery, conexion).ExecuteNonQuery();
        }

        public static object ResolverFuncion(String query)
        {
            return new SqlCommand(query, conexion).ExecuteScalar();
        }

        public static void ActualizarGrid(DataGridView dg, string tabla, string consulta)
        {
            // instancio el dataset que va a llenar de datos el datagridview
            System.Data.DataSet ds = new System.Data.DataSet();
            // instancio un adaptador de datos entre el dataset y la bd
            SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
            // llenar el dataSet con los datos de la tabla NN a través del adapter     
            da.Fill(ds, tabla);
            dg.DataSource = ds;
            // para traer todo el contenido de la tabla NN al dataGridView
            dg.DataMember = tabla;
        }

        public static SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "SERVER=" + server + "\\SQLSERVER2012;DATABASE=GD2C2017;UID=" + user + ";PASSWORD=" + password + ";" + "MultipleActiveResultSets=True";
            return con;
        }
    }
}
