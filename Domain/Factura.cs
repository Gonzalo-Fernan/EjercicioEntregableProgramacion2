using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Domain
{
    public class Factura
    {
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public Forma_pago Forma_pago { get; set; }
        public string Cliente { get; set; }

        public Factura() { }

        public Factura(int codigo, DateTime fecha, string cliente, Forma_pago forma_pago)
        {
            Codigo = codigo;
            Fecha = fecha;
            Cliente = cliente;
            Forma_pago = forma_pago;
        }
        public override string ToString()
        {
            return $"Codigo: {Codigo}, Fecha: {Fecha.ToShortDateString()}, Cliente: {Cliente}, Forma de Pago: [{Forma_pago}]";
        }
    }
}
