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

        public int Activo { get; set; } = 1;

        public Forma_pago() { }

        public Forma_pago(int codigo, string tipo_pago, int activo)
        {
            Codigo = codigo;
            Tipo_pago = tipo_pago;
            Activo = activo;

        }


        public override string ToString()
        {
            return $"Codigo: {Codigo}, Forma de Pago: {Tipo_pago}";
        }
    }
}
