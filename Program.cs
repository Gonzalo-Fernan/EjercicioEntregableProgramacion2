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
            /* Articulo articulo = new Articulo
             {
                 Nombre = "Monitor",
                 Precio_unitario = 250.75,
                 Activo = 1
             };*/
            // ArticulosRepository articulosRepository = new ArticulosRepository(dataHelper);
            //articulosRepository.Add(articulo);
            /* 
             ArticulosRepository articulosRepository = new ArticulosRepository(dataHelper);
             var articulos = articulosRepository.GetAll();
             foreach (var articulo in articulos)
             {
                 Console.WriteLine($"ID: {articulo.Codigo}, Nombre: {articulo.Nombre}, Precio Unitario: {articulo.Precio_unitario}, Activo: {articulo.Activo}");
             }
             Console.ReadLine();*/



            /* Articulo ar = articulosRepository.GetById(1);
            FormaPagoRepository formaPagoRepositiry = new FormaPagoRepository(dataHelper);
            FacturaRepository facturaRepository = new FacturaRepository(dataHelper);
            Forma_pago forma = formaPagoRepositiry.GetById(2);
            Console.WriteLine("listo");
            
            facturaRepository.Add(new Factura
            {
                Cliente = "Gonzalo Fernandez",
                Forma_pago = forma,
                Fecha = DateTime.Now,
                Detalles = //////agregar aca un detalle a la listo 
                Activo = 1
            });
            Console.WriteLine("Factura agregada correctamente.");*/




            /*Forma_pago forma_Pago = new Forma_pago
            {

                Tipo_pago = "Transferencia"
            };
            formaPagoRepositiry.Add(forma_Pago);
            Console.WriteLine("Forma de pago agregada correctamente.");*/
            // como agregar un detalle de factura en esta factura nueva
            /* DetalleFacturaRepository detalleFacturaRepository = new DetalleFacturaRepository(dataHelper);
             Detalle_factura detalle = new Detalle_factura
             {
                 Articulo = ar,
                 Factura = 1,
                 Cantidad = 2,
                 Activo = 1
             };
             detalleFacturaRepository.Add(detalle);
             Console.WriteLine("detalle agregado");*/

            /*facturaRepository.Add(new Factura
            {
                Cliente = "Gonzalo Fernandez",
                Forma_pago = forma_Pago,
                Fecha = DateTime.Now,
                Activo = 1
            });*/




            /*facturaRepository.Add(new Factura
            {
                Cliente = "Gonzalo Fernandez",
                Forma_pago = ,
                Fecha = DateTime.Now,
                Activo = 1
            });
            var facturas = facturaRepository.GetAll();
            foreach (var factura in facturas)
            {
                Console.WriteLine($"ID: {factura.Codigo}, Fecha: {factura.Fecha}, Activo: {factura.Activo}");
            }*/

            FacturaRepository facturaRepository = new FacturaRepository(dataHelper);
            Detalle_factura detalle = new Detalle_factura();
            detalle.Articulo = new ArticulosRepository(dataHelper).GetById(1);
            detalle.Cantidad = 3;
            detalle.Activo = 1;

            List<Detalle_factura> detalles = new List<Detalle_factura>();
            detalles.Add(detalle);

            Factura factura = new Factura();
            factura.Cliente = "Gonzalo Fernandez";
            factura.Forma_pago = new FormaPagoRepository(dataHelper).GetById(1);
            factura.Fecha = DateTime.Now;
            factura.Detalles = detalles;
            factura.Activo = 1;

            facturaRepository.Add(factura);

            Console.WriteLine("Factura agregada correctamente con detalles.");

            DataTable table = dataHelper.ExecuteSPQuery("sp_GetAllFacturas");
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"ID: {row["id_factura"]}, Cliente: {row["cliente"]}, Fecha: {row["fecha"]}, Activo: {row["activo"]}");
            }

        }
    }
}
