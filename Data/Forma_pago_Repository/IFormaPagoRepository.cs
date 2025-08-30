using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Domain;

namespace _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Data.Forma_pago_Repository
{
    public interface IFormaPagoRepository
    {
        List<Forma_pago> GetAll();
        Forma_pago GetById(int id);
        void Add(Forma_pago formaPago);
        void Update(Forma_pago formaPago);
        void Delete(int id);
    }
}
