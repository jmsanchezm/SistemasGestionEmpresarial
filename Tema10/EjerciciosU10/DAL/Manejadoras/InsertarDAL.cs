using Biblioteca;
using DAL.Conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manejadoras
{
    public class InsertarDAL
    {

        /// <summary>
        /// Función que inserta una persona en la BBDD
        /// Precondiciones: No hay
        /// Postcondiciones: Se inserta una persona
        /// </summary>
        /// <param name="pers"></param>
        /// <returns></returns>
        public static int insertarPersona(clsPersona pers)
        {

            int numeroFilasAfectadas = 0;

            SqlCommand comando = new SqlCommand();

            //Añadimos un parámetro que luego necesitaremos en el comando sql.
            comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 30).Value = pers.Nombre;
            comando.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar, 60).Value = pers.Apellido;
            comando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar, 15).Value = pers.Telefono;
            comando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar, 60).Value = pers.Direccion;
            comando.Parameters.Add("@foto", System.Data.SqlDbType.VarChar, 255).Value = pers.Foto;
            comando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.Date).Value = pers.FechaNacimiento;
            comando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = pers.IdDepartamento;

            try
            {
                //Abrimos la conexión
                SqlConnection conexionAbierta = clsMyConnection.establecerConexion();

                //Configuramos el comando
                comando.CommandText = "INSERT INTO Personas(Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IdDepartamento)" +
                    "values (@nombre, @apellido, @telefono, @direccion, @foto, @fechaNac,@idDepartamento)";

                //Le asignamos la conexión al comando
                comando.Connection = conexionAbierta;

                //Ejecutamos el comando
                numeroFilasAfectadas = comando.ExecuteNonQuery();

                //Cerramos la conexión
                conexionAbierta.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return numeroFilasAfectadas;

        }
    }
}
