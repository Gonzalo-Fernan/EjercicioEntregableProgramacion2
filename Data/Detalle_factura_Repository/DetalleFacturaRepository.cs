﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Data.Articulos_Repository;
using _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Data.Factura_Repository;
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
            Detalle_factura detalleFactura = new Detalle_factura();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@id_detalle_factura", id);
            DataTable table = _dataHelper.ExecuteSPQuery("sp_GetDetalleFacturaById", parametros);
            foreach (DataRow row in table.Rows)
            {
                detalleFactura.Codigo = Convert.ToInt32(row["id_detalle_factura"]);
                detalleFactura.Articulo = new ArticulosRepository(_dataHelper).GetById(Convert.ToInt32(row["id_articulo"]));
                detalleFactura.Factura = Convert.ToInt32(row["id_factura"]);
                detalleFactura.Cantidad = Convert.ToInt32(row["cantidad"]);
                detalleFactura.Activo = Convert.ToInt32(row["activo"]);
            }
            return detalleFactura;

           
        }
        public void Add(Detalle_factura detalleFactura)
        {
           

            _dataHelper.ExecuteSPNonQuery("sp_insertar_detalle_factura", new Dictionary<string, object>
            {   
                { "@id_articulo", detalleFactura.Articulo.Codigo },
                { "@id_factura", detalleFactura.Factura },
                { "@cantidad", detalleFactura.Cantidad },
                { "@activo", detalleFactura.Activo }
            });
            
        }
        public void Update(Detalle_factura detalleFactura)
        {
            _dataHelper.ExecuteSPNonQuery("sp_actualizar_detalle_factura", new Dictionary<string, object>
            {
                { "@id_detalle_factura", detalleFactura.Codigo },
                { "@id_articulo", detalleFactura.Articulo.Codigo },
                { "@id_factura", detalleFactura.Factura },
                { "@cantidad", detalleFactura.Cantidad },
                { "@activo", detalleFactura.Activo }
            });

        }
        public void Delete(int id)
        {
            _dataHelper.ExecuteSPNonQuery("sp_eliminar_detalle_factura", new Dictionary<string, object>
            {
                { "@id_detalle_factura", id },
                { "@activo", 0   }
            });
            
        }

    }
}
