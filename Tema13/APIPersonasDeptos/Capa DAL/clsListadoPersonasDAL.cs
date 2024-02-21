using Capa_Entidades;
using Microsoft.Data.SqlClient;

namespace Capa_DAL
{
    public class clsListadoPersonasDAL
    {
        public static List<clsPersona> listadoPersonas()
        {
            List<clsPersona> listado = new List<clsPersona>();

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            try
            {
                miConexion.ConnectionString = clsConexion.connection();
                miConexion.Open();
                miComando.CommandText = "SELECT * FROM Personas";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        clsPersona pers = new clsPersona();
                        pers.Id = (int)miLector["ID"];
                        pers.Nombre = (string)miLector["Nombre"];
                        pers.Apellido = (string)miLector["Apellidos"];
                        pers.IdDepartamento = (int)miLector["IDDepartamento"];
                        pers.FNac = (DateTime)miLector["FechaNacimiento"];
                        pers.Foto = (string)miLector["Foto"];
                        pers.Tlf = (string)miLector["Telefono"];
                        pers.Direccion = (string)miLector["Direccion"];
                        listado.Add(pers);
                    }
                }
                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return listado;
        }
    }
}
