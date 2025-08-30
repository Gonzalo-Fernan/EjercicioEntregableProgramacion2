using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Domain;

namespace _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Data.Factura_Repository
{
    public interface IFacturaRepository
    {
        List<Factura> GetAll();
        Factura GetById(int id);
        void Add(Factura factura);
        void Update(Factura factura);
        void Delete(int id);
    }
}
