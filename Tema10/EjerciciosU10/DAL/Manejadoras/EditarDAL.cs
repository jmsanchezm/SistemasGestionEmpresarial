using Biblioteca;
using DAL.Conexion;
using System.Data.SqlClient;

namespace DAL.Manejadoras
{
    public class EditarDAL
    {
        /// <summary>
        /// Función que edita una persona de la BBDD
        /// Precondiciones: No hay
        /// Postcondiciones: Se edita una persona
        /// </summary>
        /// <param name="pers"></param>
        /// <returns></returns>
        public static int actualizarPersona(clsPersona pers)
        {

            int numeroFilasAfectadas = 0;

            SqlCommand comando = new SqlCommand();

            //Añadimos un parámetro que luego necesitaremos en el comando sql.
            comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = pers.Id;
            comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 30).Value = pers.Nombre;
            comando.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar, 60).Value = pers.Apellido;
            comando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar, 15).Value = pers.Telefono;
            comando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar, 60).Value = pers.Direccion;
            comando.Parameters.Add("@foto", System.Data.SqlDbType.VarChar, 255).Value = pers.Foto;
            comando.Parameters.Add("@fechaNac", System.Data.SqlDbType.Date).Value = pers.FechaNacimiento;
            comando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = pers.IdDepartamento;

            try
            {
                //Abrimos la conexion 
                SqlConnection cnxOpen = clsMyConnection.establecerConexion();

                //Configuramos el comando
                comando.CommandText = "UPDATE Personas SET Nombre=@nombre, Apellidos=@apellido, Telefono=@tlf, Direccion=@direccion," +
                    "Foto=@foto, FechaNacimiento=@fechaNacimiento, IDDepartamento=@idDepartamento WHERE ID=@id";

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
