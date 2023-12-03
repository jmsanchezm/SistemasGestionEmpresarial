using Biblioteca;
using DAL.Conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Listado
{
    public static class ListadoPersonasDAL
    {
        public static List<clsPersona> ListadoCompletoPersonas()
        {
            
            SqlConnection cnxOpen = clsMyConnection.establecerConexion();

            List<clsPersona> listadoPersonas = new List<clsPersona>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsPersona pers;
           

            try
            {

                miComando.CommandText = "SELECT * FROM personas";

                miComando.Connection = cnxOpen;

                //Ejecutamos el comando
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    //Leemos cada linea
                    while (miLector.Read())

                    {
                        //Creamos un objeto a los que le damos los valores
                        pers = new clsPersona();

                        pers.Id = (int)miLector["IDPersona"];

                        pers.Nombre = (string)miLector["nombre"];

                        pers.Apellido = (string)miLector["apellidos"];


                   
                        //Comprobamos que no sea null la fecha de nacimiento
                        if (miLector["fechaNacimiento"] != System.DBNull.Value)

                        {
                            //Le damos valores
                            pers.FechaNacimiento = (DateTime)miLector["fechaNacimiento"];

                            pers.Direccion = (string)miLector["direccion"];

                            pers.Telefono = (string)miLector["telefono"];

                            listadoPersonas.Add(pers);
                        }
                    }

                }

                miLector.Close();

                cnxOpen.Close();

            }

            catch (SqlException exSql)
            {
                throw exSql;
            }


            return listadoPersonas;

        }
        public static clsPersona personaDetallada(int id)
        {

            SqlCommand comando = new SqlCommand();

            SqlDataReader lector;

            clsPersona pers = new clsPersona();

            comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
 
                SqlConnection cnxOpen = clsMyConnection.establecerConexion();

                comando.CommandText = "SELECT * FROM Personas WHERE ID=@id";

                comando.Connection = cnxOpen;

                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {

                        pers.Id = (int)lector["ID"];
                        pers.Nombre = (string)lector["Nombre"];
                        pers.Apellido = (string)lector["Apellidos"];
                        pers.Telefono = (string)lector["Telefono"];
                        pers.Direccion = (string)lector["Direccion"];
                        pers.Foto = (string)lector["Foto"];
                        pers.FechaNacimiento = (DateTime)lector["FechaNacimiento"];
                        pers.IdDepartamento = (int)lector["IDDepartamento"];

                    }
                }
                lector.Close();
                //Cerramos la conexión
                cnxOpen.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return pers;


        }
    }
}
