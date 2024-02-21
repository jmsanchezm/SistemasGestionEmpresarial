using Capa_Entidades;
using Microsoft.Data.SqlClient;

namespace Capa_DAL
{
    public class clsListadoMarcas
    {

        public List<clsMarca> listadoMarcas()
        {
            List<clsMarca> listado = new List<clsMarca>();

            SqlConnection miConexion = clsMyConnection.getConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsMarca oMarca;

            try 
            { 

                miComando.CommandText = "SELECT * FROM Marcas";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oMarca = new clsMarca();
                        oMarca.Id = (int)miLector["id"];
                        oMarca.Nombre = (string)miLector["nombre"];

                        listado.Add(oMarca);
                    }
                }

                miLector.Close();
           
            }catch(SqlException e)
            {
                throw e;
            }
            finally
            {
                clsMyConnection.closeConnection(ref miConexion);
            }

            return listado;

        }   

    }
}