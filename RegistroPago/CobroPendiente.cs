using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PagoAgilFrba.RegistroPago
{
    public class CobroPendiente
    {
        private int cliente, sucursal;
        private DateTime fechaCobro;

        private int factura, empresa;
        private DateTime fechaVto;
        private decimal importe;

        public CobroPendiente(int factura, int empresa, DateTime fechaVto, decimal importe)
        {
            this.factura = factura;
            this.empresa = empresa;
            this.fechaVto = fechaVto;
            this.importe = importe;

            this.cargarDatosCabecera();
        }

        public override string ToString()
        {
            return "FACT: " + this.factura + ", EMPRESA: " + this.nombreDeEmpresa() + ", MONTO: " + this.importe + ", F.VTO: " + this.fechaVto.ToString("dd/MM/yy");
        }

        private void cargarDatosCabecera()
        {
            this.cliente = Registro.cliente;
            this.sucursal = Registro.getIdSucursal();
            this.fechaCobro = Registro.fechaCobro;
        }

        private String nombreDeEmpresa()
        {
            SqlDataReader dr = ClaseConexion.ResolverConsulta("SELECT empr_nombre FROM CONGESTION.Empresa WHERE empr_id = " + this.empresa);
            
            dr.Read();
            String nombre = dr.GetString(0);
            dr.Close();

            return nombre;
        }

        public int getCliente()
        {
            return this.cliente;
        }

        public int getSucursal()
        {
            return this.sucursal;
        }

        public DateTime getFechaCobro()
        {
            return this.fechaCobro;
        }

        public int getFactura()
        {
            return this.factura;
        }

        public int getEmpresa()
        {
            return this.empresa;
        }

        public DateTime getFechaVto()
        {
            return this.fechaVto;
        }

        public decimal getImporte()
        {
            return this.importe;
        }

    }
}
