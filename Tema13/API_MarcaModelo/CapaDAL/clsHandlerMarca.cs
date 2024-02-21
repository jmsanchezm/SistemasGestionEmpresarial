using CapaEntidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL
{
    public class clsHandlerMarca
    {
        /// <summary>
        /// Método que inserta una marca en la base de datos
        /// </summary>
        /// <param name="marca"></param>
        /// <returns></returns>
        public static int InsertarMarca(Marca marca)
        {
            int filas = 0;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            try
            {
                miConexion.ConnectionString = clsConexion.connection();
                miConexion.Open();
                miComando.CommandText = "INSERT INTO Marca (id, nombre) VALUES (@id, @nombre)";
                miComando.Parameters.Add("@id", SqlDbType.Int).Value = marca.Id;
                miComando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = marca.Nombre;
                miComando.Connection = miConexion;
                filas = miComando.ExecuteNonQuery();
                miConexion.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return filas;
        }

        /// <summary>
        /// Método que modifica una marca en la base de datos
        /// </summary>
        /// <param name="marca"></param>
        /// <returns></returns>
        public static int ModificarMarca(Marca marca)
        {
            int filas = 0;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            try
            {
                miConexion.ConnectionString = clsConexion.connection();
                miConexion.Open();
                miComando.CommandText = "UPDATE Marca SET nombre = @nombre WHERE id = @id";
                miComando.Parameters.Add("@id", SqlDbType.Int).Value = marca.Id;
                miComando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = marca.Nombre;
                miComando.Connection = miConexion;
                filas = miComando.ExecuteNonQuery();
                miConexion.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return filas;
        }

        /// <summary>
        /// Método que elimina una marca de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int EliminarMarca(int id)
        {
            int filas = 0;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            try
            {
                miConexion.ConnectionString = clsConexion.connection();
                miConexion.Open();
                miComando.CommandText = "DELETE FROM Marca WHERE id = @id";
                miComando.Parameters.Add("@id", SqlDbType.Int).Value = id;
                miComando.Connection = miConexion;
                filas = miComando.ExecuteNonQuery();
                miConexion.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return filas;
        }


        /// <summary>
        /// Método que busca una marca en la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Marca BuscarMarca(int id)
        {
            Marca marca = null;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            try
            {
                miConexion.ConnectionString = clsConexion.connection();
                miConexion.Open();
                miComando.CommandText = "SELECT * FROM Marca WHERE id = @id";
                miComando.Parameters.Add("@id", SqlDbType.Int).Value = id;
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    miLector.Read();
                    marca = new Marca((int)miLector["id"], (string)miLector["nombre"]);
                }
                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return marca;
        }

    }
}
