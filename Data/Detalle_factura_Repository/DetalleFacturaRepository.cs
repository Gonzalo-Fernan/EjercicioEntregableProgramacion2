using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Data.Articulos_Repository;
using _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Domain;

namespace _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Data.Detalle_factura_Repository
{
    public class DetalleFacturaRepository : IDetalleFacturaRepository
    {
        private IDataHelper _dataHelper;

        public DetalleFacturaRepository(IDataHelper datahelper) 
        {
            _dataHelper = datahelper;
        }
        public List<Detalle_factura> GetAll()
        {
            List<Detalle_factura> lista = new List<Detalle_factura>();
            DataTable table = _dataHelper.ExecuteSPQuery("sp_GetAllDetalleFactura");
            foreach (DataRow row in table.Rows) 
            {
                Detalle_factura detalleFactura = new Detalle_factura
                {
                    Codigo = Convert.ToInt32(row["id_detalle_factura"]),
                    Articulo = new ArticulosRepository(_dataHelper).GetById(Convert.ToInt32(row["id_articulo"])),
                    Factura = Convert.ToInt32(row["id_factura"]),
                    Cantidad = Convert.ToInt32(row["cantidad"])
                };
                lista.Add(detalleFactura);
            }
            return lista;
   
        }
        public Detalle_factura GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Add(Detalle_factura detalleFactura)
        {
            throw new NotImplementedException();
        }
        public void Update(Detalle_factura detalleFactura)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
