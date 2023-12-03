using DAL.Conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manejadoras
{
    public class BorrarDAL 
    {
        /// <summary>
        /// Función que borra una persona de la BBDD
        /// Precondiciones: No hay
        /// Postcondiciones: Se borra una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int borrarPersona(int id) 
        {
            int numeroFilasAfectadas = 0;

            SqlCommand comando = new SqlCommand();

            //Añadimos un parámetro que luego necesitaremos en el comando sql.
            comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                //Abrimos la conexión
                SqlConnection cnxOpen = clsMyConnection.establecerConexion();

                comando.CommandText = "DELETE FROM Personas WHERE ID=@id";
                
                //Le asignamos la conexión al comando
                comando.Connection = cnxOpen;
                
                //Ejecutamos el comando
                numeroFilasAfectadas = comando.ExecuteNonQuery();

                //Cerramos la conexión
                cnxOpen.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return numeroFilasAfectadas;


        }
    }
    
   
}
