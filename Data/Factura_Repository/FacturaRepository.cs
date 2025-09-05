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
            DataTable table = _dataHelper.ExecuteSPQuery("sp_GetAllFacturas");
            foreach (DataRow row in table.Rows)
            {
               
                Factura factura = new Factura
                {
                    Codigo = Convert.ToInt32(row["id_factura"]),
                    Forma_pago = new FormaPagoRepository(_dataHelper).GetById(Convert.ToInt32(row["id_forma_pago"])),
                    Fecha = Convert.ToDateTime(row["fecha"]),
                    Cliente = (string)row["cliente"],
                    
                };
                lista.Add(factura);
            }
            return lista;
        }
        public Factura GetById(int id)
        {
            Factura factura = new Factura();
            DetalleFacturaRepository detalleFacturaRepository = new DetalleFacturaRepository(_dataHelper);
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id_factura", id);   

            DataTable table = _dataHelper.ExecuteSPQuery("sp_GetFacturaById", parameters);

            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                factura.Codigo = Convert.ToInt32(row["id_factura"]);
                factura.Forma_pago = new FormaPagoRepository(_dataHelper).GetById(Convert.ToInt32(row["id_forma_pago"]));
                factura.Fecha = Convert.ToDateTime(row["fecha"]);
                factura.Cliente = (string)row["cliente"];
                int id_factura = Convert.ToInt32(row["id_factura"]);
                factura.Detalles = detalleFacturaRepository.GetById(id_factura);
                factura.Activo = Convert.ToInt32(row["Activo"]);
            }
            return factura;
        }
        public void Add(Factura factura)
        {
            var parametros = new Dictionary<string, object>
            {
                { "@id_forma_pago", factura.Forma_pago.Codigo },
                { "@fecha", factura.Fecha },
                { "@cliente", factura.Cliente },
                { "@activo", 1 }
            };
            
           int result = _dataHelper.ExecuteSPNonQuery("sp_insertar_factura", parametros);
        
           factura.Codigo = result;
            
            foreach (var detalle in factura.Detalles)
            {
                _dataHelper.ExecuteSPNonQuery("sp_insertar_detalle_factura", new Dictionary<string, object>
                {
                    { "@id_articulo", detalle.Articulo.Codigo },
                    { "@id_factura", factura.Codigo },
                    { "@cantidad", detalle.Cantidad },
                    { "@activo", 1 }
                });
            }
        }
        public void Update(Factura factura)
        {
            _dataHelper.ExecuteSPNonQuery("sp_actualizar_factura", new Dictionary<string, object>
            {
                { "@id_factura", factura.Codigo },
                { "@id_forma_pago", factura.Forma_pago.Codigo },
                { "@fecha", factura.Fecha },
                { "@cliente", factura.Cliente },
                { "@activo", factura.Activo }
            });

        }
        public void Delete(int id)
        {
            _dataHelper.ExecuteSPNonQuery("sp_eliminar_factura", new Dictionary<string, object>
            {
                { "@id_factura", id },
                { "@activo", 0 }
            });
            
        }
    }
}
