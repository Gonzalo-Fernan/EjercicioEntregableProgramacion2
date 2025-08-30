using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Domain;

namespace _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Data.Detalle_factura_Repository
{
    public interface IDetalleFacturaRepository
    {
        List<Detalle_factura> GetAll();
        Detalle_factura GetById(int id);
        void Add(Detalle_factura detalleFactura);
        void Update(Detalle_factura detalleFactura);
        void Delete(int id);
    }
}
