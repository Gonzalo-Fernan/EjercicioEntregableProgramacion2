using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Domain
{
    public class Forma_pago
    {
        public int Codigo { get; set; }
        public string Tipo_pago { get; set; }

        public Forma_pago() { }

        public Forma_pago(int Codigo, string Tipo_pago)
        {
            this.Codigo = Codigo;
            this.Tipo_pago = Tipo_pago;
        }


        public override string ToString()
        {
            return $"Codigo: {Codigo}, Forma de Pago: {Tipo_pago}";
        }
    }
}
