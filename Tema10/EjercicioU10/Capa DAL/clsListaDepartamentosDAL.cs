using Capa_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL
{
    public class clsListaDepartamentosDAL
    {

        public static ObservableCollection<clsDepartamento> ListadoCompletoDepartamentos()
        { 
            SqlConnection miConexion = new SqlConnection();

            ObservableCollection<clsDepartamento> listadoDepartamentos = new ObservableCollection<clsDepartamento>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsDepartamento depto;

            try
            {
                //abrimos la conexion y la guardamos en una variable
                miConexion.ConnectionString = clsConnection.connection();

                miConexion.Open();

                miComando.CommandText = "SELECT * FROM departamentos";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        depto = new clsDepartamento();
                        depto.IdDepartamento = (int)miLector["ID"];
                        depto.Nombre = (string)miLector["Nombre"];


                        listadoDepartamentos.Add(depto);

                    }
                }
                miLector.Close();
                miConexion.Close();

               

            }
            catch (SqlException ex) 
            { 
                throw ex;
            }

            return listadoDepartamentos;

        }

        public static clsDepartamento DepartamentoPorId(int id)
        {

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsDepartamento depto = new clsDepartamento();

            miConexion.ConnectionString = clsConnection.connection();

            try 
            {
            
                miConexion.Open();

                miComando.CommandText = "SELECT * FROM departamentos WHERE ID=@id";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    miLector.Read();

                    depto.IdDepartamento = (int)miLector["ID"];
                    depto.Nombre = (string)miLector["Nombre"];

                }

                miLector.Close();
                miConexion.Close();

            }
            catch (SqlException ex)
            {
                throw ex;
            
            }

            return depto;
            
        }

    }
}
