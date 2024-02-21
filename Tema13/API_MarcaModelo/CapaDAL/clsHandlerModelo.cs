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
    public class clsHandlerModelo
    {
        /// <summary>
        /// Metdo que inserta un modelo en la base de datos
        /// </summary>
        /// <param name="idMarca"></param>
        /// <param name="nombre"></param>
        /// <param name="precio"></param>
        /// <returns></returns>
        public static int InsertarModelo(Modelo modelo)
        {
            int filas = 0;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            try
            {
                miConexion.ConnectionString = clsConexion.connection();
                miConexion.Open();
                miComando.CommandText = "INSERT INTO Modelo (id, idMarca, nombre, precio) VALUES (@id, @idMarca, @nombre, @precio)";
                miComando.Parameters.Add("@id", SqlDbType.Int).Value = modelo.Id;
                miComando.Parameters.Add("@idMarca", SqlDbType.Int).Value = modelo.IdMarca;
                miComando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = modelo.Nombre;
                miComando.Parameters.Add("@precio", SqlDbType.Float).Value = modelo.Precio;
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
       /// Método que modifica un modelo en la base de datos
       /// </summary>
       /// <param name="modelo"></param>
       /// <returns></returns>
        public static int ModificarModelo(Modelo modelo)
        {
            int filas = 0;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            try
            {
                miConexion.ConnectionString = clsConexion.connection();
                miConexion.Open();
                miComando.CommandText = "UPDATE Modelo SET idMarca = @idMarca, nombre = @nombre, precio = @precio WHERE id = @id";
                miComando.Parameters.Add("@id", SqlDbType.Int).Value = modelo.Id;
                miComando.Parameters.Add("@idMarca", SqlDbType.Int).Value = modelo.IdMarca;
                miComando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = modelo.Nombre;
                miComando.Parameters.Add("@precio", SqlDbType.Float).Value = modelo.Precio;

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
        /// Método que elimina un modelo de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int EliminarModelo(int id)
        {
            int filas = 0;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            try
            {
                miConexion.ConnectionString = clsConexion.connection();
                miConexion.Open();
                miComando.CommandText = "DELETE FROM Modelo WHERE id = @id";
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

        public static Modelo BuscarModelo(int id)
        {
            Modelo modelo=null;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            try
            {
                miConexion.ConnectionString = clsConexion.connection();
                miConexion.Open();
                miComando.CommandText = "SELECT * FROM Modelo WHERE id = @id";
                miComando.Parameters.Add("@id", SqlDbType.Int).Value = id;
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    miLector.Read();
                    modelo = new Modelo((int)miLector["id"], (int)miLector["idMarca"], (string)miLector["nombre"], Convert.ToSingle(miLector["precio"]));
                }
                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return modelo;
        }   
    }
}
