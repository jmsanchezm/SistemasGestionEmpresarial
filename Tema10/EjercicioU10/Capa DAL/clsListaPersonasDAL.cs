using Capa_Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL
{
    public class clsListaPersonasDAL
    {
        /// <summary>
        /// Función que devuelve un listado de personas
        /// Precondición : Ninguna
        /// Postcondición : Ninguna
        /// </summary>
        /// <returns>Lista de personas</returns>
        public static ObservableCollection<clsPersona> listadoCompletoPersonas()
        {
            SqlConnection miConexion = new SqlConnection();

            ObservableCollection<clsPersona> listadoPersonas = new ObservableCollection<clsPersona>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsPersona pers;

            miConexion.ConnectionString = clsConnection.connection();

            try
            {

                miConexion.Open();

                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos

                miComando.CommandText = "SELECT * FROM Personas";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector

                if (miLector.HasRows)

                {

                    while (miLector.Read())

                    {

                        pers = new clsPersona();

                        pers.Id = (int)miLector["ID"];

                        pers.Nombre = (string)miLector["Nombre"];

                        pers.Apellido = (string)miLector["Apellidos"];

                        pers.IdDepartamento = (int)miLector["IDDepartamento"];

                        if (miLector["FechaNacimiento"] != System.DBNull.Value)

                        { pers.FNac = (DateTime)miLector["FechaNacimiento"]; }

                        pers.Foto = (string)miLector["Foto"];

                        pers.Direccion = (string)miLector["Direccion"];

                        pers.Tlf = (string)miLector["Telefono"];

                        listadoPersonas.Add(pers);

                    }

                }

                miLector.Close();

                miConexion.Close();

            }

            catch (SqlException exSql)

            {
                throw exSql;

            }
            return listadoPersonas;
        }

        /// <summary>
        /// Función que devuelve una persona según su ID
        /// Precondición : Int ID > 0
        /// Postcondición : Ninguna
        /// </summary>
        /// <returns>Persona</returns>
        public static clsPersona PersonaPorId(int id)
        {

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsPersona pers = new clsPersona();

            miConexion.ConnectionString = clsConnection.connection();


            try
            {

                miConexion.Open();

                miComando.CommandText = "SELECT * FROM personas WHERE ID=@id";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    miLector.Read();
                    
                    pers.Id = (int)miLector["ID"];
                    pers.Nombre = (string)miLector["Nombre"];
                    pers.Apellido = (string)miLector["Apellidos"];
                    pers.IdDepartamento = (int)miLector["IDDepartamento"];

                    if (miLector["FechaNacimiento"] != System.DBNull.Value)
                    { 
                        pers.FNac = (DateTime)miLector["FechaNacimiento"]; 
                    }
                    pers.Foto = (string)miLector["Foto"];
                    pers.Direccion = (string)miLector["Direccion"];
                    pers.Tlf = (string)miLector["Telefono"];

                }

                miLector.Close();
                miConexion.Close();


            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return pers;

        }
         
    }
}
