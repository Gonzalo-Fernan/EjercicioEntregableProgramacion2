using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Data
{
    public interface IDataHelper
    {

        DataTable ExecuteSPQuery(string sp, Dictionary<string, object> parametros = null);
        int ExecuteSPNonQuery(string sp, Dictionary<string, object> parametros = null);
    }
}
