using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Domain;

namespace _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Data.Forma_pago_Repository
{
    public class FormaPagoRepository : IFormaPagoRepository
    {
        private IDataHelper _dataHelper;
        public FormaPagoRepository(IDataHelper dataHelper)
        {
            _dataHelper = dataHelper;
        }
        public List<Forma_pago> GetAll()
        {
            throw new NotImplementedException();
        }
        public Forma_pago GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Add(Forma_pago formaPago)
        {
            throw new NotImplementedException();
        }
        public void Update(Forma_pago formaPago)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
