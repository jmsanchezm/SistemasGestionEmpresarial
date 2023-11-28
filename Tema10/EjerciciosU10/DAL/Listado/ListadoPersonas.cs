using Biblioteca;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Listado
{
    public static class ListadoPersonas
    {
        public static List<clsPersona> ListadoCompletoPersonas()
        {
            SqlConnection miConnection = new SqlConnection();

            List<clsPersona> listadoPersonas = new List<clsPersona>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsPersona pers;

            miConnection.ConnectionString = ("server=juanma.database.windows.net;database=Personas;uid=prueba;pwd=fernandoG321;trustServerCertificate=true;");

            try
            {

                miConnection.Open();

                miComando.CommandText = "SELECT * FROM personas";

                miComando.Connection = miConnection;

                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector

                if (miLector.HasRows)

                {

                    while (miLector.Read())

                    {
                        pers = new clsPersona();

                        pers.Id = (int)miLector["IDPersona"];

                        pers.Nombre = (string)miLector["nombre"];

                        pers.Apellido = (string)miLector["apellidos"];


                        //Si sospechamos que el campo puede ser Null en la BBDD

                        if (miLector["fechaNac"] != System.DBNull.Value)

                        {
                            pers.FechaNacimiento = (DateTime)miLector["fechaNac"];

                            pers.Direccion = (string)miLector["direccion"];

                            pers.Telefono = (string)miLector["telefono"];

                            listadoPersonas.Add(pers);
                        }
                    }

                }

                miLector.Close();

                miConnection.Close();

            }

            catch (SqlException exSql)
            {
                throw exSql;
            }


            return listadoPersonas;

        }
    }
}
