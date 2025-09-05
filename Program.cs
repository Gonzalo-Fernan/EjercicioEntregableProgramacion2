using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Data;
using _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Data.Articulos_Repository;
using _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Data.Factura_Repository;
using _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Domain;
using _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Data.Forma_pago_Repository;
using _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Data.Detalle_factura_Repository;
using System.Data;

namespace _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDataHelper dataHelper = new DataHelper();

            ///Articulos Todo Terminado hijos de puta 
            //Detalles Todo Terminado hijos de puta
            //Factura Todo Terminado hijos de puta
            // FormaPago Todo Terminado
            FacturaRepository facturaRepo = new FacturaRepository(dataHelper);
            Factura lista= facturaRepo.GetById(3);
            Console.WriteLine(lista.ToString());





        }
    }
}
