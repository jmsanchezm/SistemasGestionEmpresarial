using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Conexion
{
    public class clsMyConnection
    {

        /// <summary>
        /// Método que establece la conexión con la BBDD
        /// Precondición: La conexión debe estar cerrada
        /// Postcondición: Se habrá establecido la conexión con la BBDD
        /// </summary>
        /// <returns>Devuelve la conexión abierta</returns>
        public static SqlConnection establecerConexion() 
        {

            SqlConnection miConexion = new SqlConnection();

            try
            {
                miConexion.ConnectionString = "server=juanma.database.windows.net;database=Personas;uid=prueba;pwd=fernandoG321;trustServerCertificate = true ";
    
                miConexion.Open();

            }
            catch (Exception e)
            {
                throw;
            }

            return miConexion;
        }

        
    }

}
