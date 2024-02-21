using CapaEntidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL
{
    public class clsListadoModelo
    {

        public static List<Modelo> ListadoCompletoModelos()
        {
            List<Modelo> listado = new List<Modelo>();

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            

            try
            {
                miConexion.ConnectionString = clsConexion.connection();
                miConexion.Open();
                miComando.CommandText = "SELECT * FROM Modelo";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        Modelo modelo = new Modelo((int)miLector["id"], (int)miLector["idMarca"], (string)miLector["nombre"], Convert.ToSingle(miLector["precio"]));
                        listado.Add(modelo);
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
