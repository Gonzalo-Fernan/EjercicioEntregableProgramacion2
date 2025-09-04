using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Data.Detalle_factura_Repository;
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
            List<Forma_pago> lista = new List<Forma_pago>();
            DataTable table =_dataHelper.ExecuteSPQuery("sp_GetAllFormaPago");
            foreach (DataRow row in table.Rows )
            {
                Forma_pago formaPago = new Forma_pago
                {
                    Codigo = Convert.ToInt32(row["id_forma_pago"]),
                    Tipo_pago = row["descripcion"].ToString(),
                    Activo = Convert.ToInt32(row["activo"]),
                    
                }; 
                lista.Add(formaPago);
            }
            return lista;
        }
        public Forma_pago GetById(int id)
        {
            Forma_pago formaPago = new Forma_pago();
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@id_forma_pago", id }
            };
            DataTable table = _dataHelper.ExecuteSPQuery("sp_GetFormaPagoById", parameters);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                formaPago.Codigo = Convert.ToInt32(row["id_forma_pago"]);
                formaPago.Tipo_pago = row["forma_pago"].ToString();
            


            }
            return formaPago;
           
        }
        public void Add(Forma_pago formaPago)
        {
            _dataHelper.ExecuteSPNonQuery("sp_insertar_forma_pago", new Dictionary<string, object>
            {
                { "@forma_pago", formaPago.Tipo_pago },
                { "@Activo", 1 }
            });
        }
        public void Update(Forma_pago formaPago)
        {
            _dataHelper.ExecuteSPNonQuery("sp_actualizar_forma_pago", new Dictionary<string, object>
            {
                { "@id_forma_pago", formaPago.Codigo },
                { "@forma_pago", formaPago.Tipo_pago },
                { "@Activo", formaPago.Activo }
            });
           
        }
        public void Delete(int id)
        {
            _dataHelper.ExecuteSPNonQuery("sp_eliminar_forma_pago", new Dictionary<string, object>
            {
                { "@id_forma_pago", id },
                { "@Activo", 0 }
            });
        }
    }
}
