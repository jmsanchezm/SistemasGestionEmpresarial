using Capa_Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL
{
    public class clsHandlerPersonasDAL
    {
        /// <summary>
        /// Metodo que inserta una persona en la base de datos
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static int InsertarPersona(clsPersona persona)
        {
            int filas = 0;
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            try
            {
                //Abrir la conexion
                miConexion.ConnectionString = clsConexion.connection();
                miConexion.Open();
                //Definir el comando
                miComando.CommandText = "INSERT INTO Personas (Nombre, Apellidos, IDDepartamento, FechaNacimiento, Foto, Telefono, Direccion) VALUES (@nombre, @apellidos, @idDepartamento, @fechaNacimiento, @foto, @telefono, @direccion)";
               
                //Definir los parametros
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
                miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellido;
                miComando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;
                miComando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.DateTime).Value = persona.FNac;
                miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = persona.Foto;
                miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Tlf;
                miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;

                //Asignar la conexion al comando
                miComando.Connection = miConexion;

                //Ejecutar el comando
                filas = miComando.ExecuteNonQuery();

                //Cerrar la conexion
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return filas;
        }

        /// <summary>
        /// Metodo que borra una persona de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int BorrarPersona(int id)
        {
            int resultado = 0;
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            try
            {
                //Abrir la conexion
                miConexion.ConnectionString = clsConexion.connection();
                miConexion.Open();

                //Definir el comando
                miComando.CommandText = "DELETE FROM Personas WHERE ID = @id";
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                //Asignar la conexion al comando y ejecutar el comando
                miComando.Connection = miConexion;
                resultado = miComando.ExecuteNonQuery();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return resultado;
        }   

        /// <summary>
        /// Metodo que actualiza una persona en la base de datos
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static int ActualizarPersona(clsPersona persona)
        {
            int resultado = 0;
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            try
            {
                //Abrir la conexion
                miConexion.ConnectionString = clsConexion.connection();
                miConexion.Open();

                //Definir el comando (teniendo en cuenta que debe existir la persona)
                miComando.CommandText = "UPDATE Personas SET Nombre = @nombre, Apellidos = @apellidos, IDDepartamento = @idDepartamento, FechaNacimiento = @fechaNacimiento, Foto = @foto, Telefono = @telefono, Direccion = @direccion WHERE ID = @id";
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
                miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellido;
                miComando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;
                miComando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.DateTime).Value = persona.FNac;
                miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = persona.Foto;
                miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Tlf;
                miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.Id;

                //Asignar la conexion al comando y ejecutar el comando
                miComando.Connection = miConexion;
                resultado = miComando.ExecuteNonQuery();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return resultado;
        }

        /// <summary>
        /// Metodo que obtiene una persona de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static clsPersona ObtenerPersona(int id)
        {
            clsPersona persona = new clsPersona();
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            try
            {
                //Abrir la conexion
                miConexion.ConnectionString = clsConexion.connection();
                miConexion.Open();

                //Definir el comando
                miComando.CommandText = "SELECT * FROM Personas WHERE ID = @id";
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                //Asignar la conexion al comando y ejecutar el comando
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();
                if (miLector.HasRows)
                {
                    miLector.Read();
                    persona.Id = (int)miLector["ID"];
                    persona.Nombre = (string)miLector["Nombre"];
                    persona.Apellido = (string)miLector["Apellidos"];
                    persona.IdDepartamento = (int)miLector["IDDepartamento"];
                    persona.FNac = (DateTime)miLector["FechaNacimiento"];
                    persona.Foto = (string)miLector["Foto"];
                    persona.Tlf = (string)miLector["Telefono"];
                    persona.Direccion = (string)miLector["Direccion"];
                }
                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return persona;
        }

    }
}
