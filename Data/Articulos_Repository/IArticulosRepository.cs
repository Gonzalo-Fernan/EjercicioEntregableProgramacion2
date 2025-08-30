using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Domain;

namespace _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Data.Articulos_Repository
{
    public interface IArticulosRepository
    {
        List<Articulo> GetAll();
        Articulo GetById(int id);
        void Add(Articulo articulo);
        void Update(Articulo articulo);
        void Delete(int id);
    }
}
