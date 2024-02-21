using Capa_Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL
{
    public  class clsHandlerDepartamentosDAL
    {
        /// <summary>
        /// Metodo que devuelve un listado de departamentos
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public static int InsertarDepartamento(clsDepartamento departamento)
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
                miComando.CommandText = "INSERT INTO Departamentos (Nombre) VALUES (@nombre)";

                //Definir los parametros
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = departamento.Nombre;

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
        /// Metodo que borra un departamento de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int BorrarDepartamento(int id)
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
                miComando.CommandText = "DELETE FROM Departamentos WHERE ID = @id";

                //Definir los parametros
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

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
        /// Metodo que actualiza un departamento
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public static int ActualizarDepartamento(clsDepartamento departamento)
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
                miComando.CommandText = "UPDATE Departamentos SET Nombre = @nombre WHERE ID = @id";

                //Definir los parametros
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = departamento.Nombre;
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = departamento.IdDepartamento;

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
        /// Metodo que devuelve un departamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static clsDepartamento ObtenerDepartamento(int id)
        {
            clsDepartamento departamento = new clsDepartamento();
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            try
            {
                //Abrir la conexion
                miConexion.ConnectionString = clsConexion.connection();
                miConexion.Open();
                //Definir el comando
                miComando.CommandText = "SELECT * FROM Departamentos WHERE ID = @id";

                //Definir los parametros
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                //Asignar la conexion al comando
                miComando.Connection = miConexion;

                //Ejecutar el comando
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    miLector.Read();
                    departamento.IdDepartamento = (int)miLector["ID"];
                    departamento.Nombre = (string)miLector["Nombre"];
                }
                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return departamento;
        }


    }
}
