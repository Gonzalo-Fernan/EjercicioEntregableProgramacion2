using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Domain
{
    public class Articulo
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public double Precio_unitario { get; set; }
        public Articulo() { }

        public Articulo(int codigo, string nombre, double precio_unitario)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio_unitario = precio_unitario;
        }

        public override string ToString()
        {
            return $"Codigo: {Codigo}, Nombre: {Nombre}, Precio Unitario: {Precio_unitario}";
        }
    }
}
