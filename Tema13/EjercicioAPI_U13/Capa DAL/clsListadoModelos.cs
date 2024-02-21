using Capa_Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL
{
    public class clsListadoModelos
    {
        public List<clsModelo> listadoModelos()
        {
            List<clsModelo> listado = new List<clsModelo>();

            SqlConnection miConexion = clsMyConnection.getConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsModelo oModelo;

            try
            {

                miComando.CommandText = "SELECT * FROM Modelos";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        clsModelo mod = new clsModelo();

                        mod.Id = (int)miLector["id"];
                        mod.Nombre = (string)miLector["nombre"];
                        mod.IdMarca = (int)miLector["idMarca"];
                        mod.Precio = (float)miLector["precio"];

                        listado.Add(mod);
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
