using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.RegistroPago
{
    public class CobroPendiente
    {
        private int cliente, sucursal;
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

        public float getImporte()
        {
            return this.importe;
        }
    }
}
