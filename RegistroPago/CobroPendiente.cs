using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.RegistroPago
{
    public class CobroPendiente
    {
        private int cliente, sucursal, medioPago;
        private DateTime fechaCobro;

        private int factura, empresa;
        private DateTime fechaVto;
        private float importe;

        public CobroPendiente(int factura, int empresa, DateTime fechaVto, float importe)
        {
            this.factura = factura;
            this.empresa = empresa;
            this.fechaVto = fechaVto;
            this.importe = importe;

            this.cargarDatosCabecera();
        }

        public override string ToString()
        {
            return "FACT: " + this.factura + ", EMPRESA: " + this.empresa + ", MONTO: " + this.importe;
        }

        private void cargarDatosCabecera()
        {
            this.cliente = Registro.cliente;
            this.sucursal = Registro.sucursal;
            this.fechaCobro = Registro.fechaCobro;
        }

        public void setMedioPago(int medio)
        {
            this.medioPago = medio;
        }

        public int getCliente()
        {
            return this.cliente;
        }

        public int getSucursal()
        {
            return this.sucursal;
        }

        public int getMedioPago()
        {
            return this.medioPago;
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

        public float getImporte()
        {
            return this.importe;
        }
    }
}
