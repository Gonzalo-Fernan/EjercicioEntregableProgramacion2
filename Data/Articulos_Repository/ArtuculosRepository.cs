using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Domain;

namespace _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Data.Articulos_Repository
{
    public class ArtuculosRepository : IArticulosRepository
    {
        public List<Articulo> GetAll()
        {
            List<Articulo> articulos = new List<Articulo>();
            DataTable table = DataHelper.GetInstance().ExecuteSPQuery("sp_GetAllArticulos");
            foreach (DataRow row in table.Rows)
            {
                Articulo articulo = new Articulo
                {
                    Codigo = Convert.ToInt32(row["id_articulo"]),
                    Nombre = row["nombre"].ToString(),
                    Precio_unitario = Convert.ToDouble(row["precio_unitario"])
                };
                articulos.Add(articulo);
            }
            return articulos;
        }
        public Articulo GetById(int id)
        {

            Articulo articulo = new Articulo();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@id_articulo", id);
            
            DataTable table = DataHelper.GetInstance().ExecuteSPQuery("sp_GetArticuloById", parametros);
            foreach (DataRow row in table.Rows) {
                {
                    articulo.Codigo = Convert.ToInt32(row["id_articulo"]);
                    articulo.Nombre = row["nombre"].ToString();
                    articulo.Precio_unitario = Convert.ToDouble(row["precio_unitario"]);
                };
            }
            return articulo;

        }
        public void Add(Articulo articulo)
        {
            throw new NotImplementedException();
        }
        public void Update(Articulo articulo)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
