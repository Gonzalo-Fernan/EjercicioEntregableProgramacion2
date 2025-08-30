using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Data.Detalle_factura_Repository;
using _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Data.Forma_pago_Repository;
using _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Domain;

namespace _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Data.Factura_Repository
{
    public class FacturaRepository : IFacturaRepository
    {
        private IDataHelper _dataHelper;
        public FacturaRepository(IDataHelper dataHelper) 
        {
            _dataHelper = dataHelper;
        }
        public List<Factura> GetAll()
        {
            List<Factura> lista = new List<Factura>();
            DataTable table = _dataHelper.ExecuteSPQuery("sp_GetAllFactura");
            foreach (DataRow row in table.Rows)
            {
                Factura factura = new Factura
                {
                    Codigo = Convert.ToInt32(row["id_factura"]),
                    Forma_pago = new FormaPagoRepository(_dataHelper).GetById(Convert.ToInt32(row["id_forma_pago"])),
                    Fecha = Convert.ToDateTime(row["fecha"]),
                    Cliente = (string)row["cliente"],
                    Detalles = new DetalleFacturaRepository(_dataHelper).GetAll().Where(d => d.Factura == Convert.ToInt32(row["id_factura"])).ToList()
                };
                lista.Add(factura);
            }
            return lista;
        }
        public Factura GetById(int id)
        {
            Factura factura = new Factura();
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@id", id }
            };
            DataTable table = _dataHelper.ExecuteSPQuery("sp_GetFacturaById", parameters);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                factura.Codigo = Convert.ToInt32(row["id_factura"]);
                factura.Forma_pago = new FormaPagoRepository(_dataHelper).GetById(Convert.ToInt32(row["id_forma_pago"]));
                factura.Fecha = Convert.ToDateTime(row["fecha"]);
                factura.Cliente = (string)row["cliente"];
                factura.Detalles = new DetalleFacturaRepository(_dataHelper).GetAll().Where(d => d.Factura == Convert.ToInt32(row["id_factura"])).ToList();
            }
            return factura;
        }
        public void Add(Factura factura)
        {
            throw new NotImplementedException();
        }
        public void Update(Factura factura)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
