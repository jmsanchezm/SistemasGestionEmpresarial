using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using Microsoft.Data.SqlClient;

namespace CapaDAL
{
    public class clsListadoMarca
    {

        public static List<Marca> ListadoCompletoMarcas()
        {
            List<Marca> listado = new List<Marca>();

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;
            try
            {
                miConexion.ConnectionString = clsConexion.connection();
                miConexion.Open();
                miComando.CommandText = "SELECT * FROM Marca";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        Marca marca = new Marca((int)miLector["id"], (string)miLector["nombre"]);
                        listado.Add(marca);
                    }
                }
                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }   

            return listado;
        }

    }
}
