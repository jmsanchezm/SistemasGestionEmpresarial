using Capa_Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL
{
    public class clsListadoDepartamentosDAL
    {
        /// <summary>
        /// Metodo que devuelve un listado de departamentos
        /// </summary>
        /// <returns></returns>
        public static List<clsDepartamento> listadoDepartamentos()
        {
            List<clsDepartamento> listado = new List<clsDepartamento>();

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            try
            {
                miConexion.ConnectionString = clsConexion.connection();
                miConexion.Open();
                miComando.CommandText = "SELECT * FROM Departamentos";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        clsDepartamento dep = new clsDepartamento();
                        dep.IdDepartamento = (int)miLector["ID"];
                        dep.Nombre = (string)miLector["Nombre"];
                        listado.Add(dep);
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
