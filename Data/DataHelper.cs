using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _421498_1w1_Gonzalo_Fernandez_Ejercicio_Entregable_1.Data
{
    public class DataHelper
    {
        private static DataHelper _instance;
        private SqlConnection _connection;
        public DataHelper()
        {
            _connection = new SqlConnection("Data Source=DESKTOP-QR5EERE\\SQLEXPRESS;Initial Catalog=Facturacion_programacion;Integrated Security=True");
        }
        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }
        public DataTable ExecuteSPQuery(string sp, Dictionary<string, object> parametros = null)
        {
            DataTable table = new DataTable();
            try
            {
                _connection.Open();
                SqlCommand command = new SqlCommand(sp, _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = sp;   

                // Agregar parámetros si existen
                if (parametros != null)
                {
                    foreach (var param in parametros)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }

                table.Load(command.ExecuteReader());
            }
            catch (Exception ex)
            {
                table = null;
            }
            finally
            {
                _connection.Close();
            }
            return table;
        }
    }
}
