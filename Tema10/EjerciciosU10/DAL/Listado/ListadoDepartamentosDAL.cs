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
    public class ListadoDepartamentosDAL
    {
        /// <summary>
        /// Función que devuelve un listado completo de departamentos
        /// Prescondiciones: No hay
        /// Postcondiciones: Se devuelve un listado de departamentos
        /// </summary>
        /// <returns>Devuelve un listado de departamentos</returns>
        public static List<clsDepartamento> ListadoCompletoDepartamentos()
        {

            List<clsDepartamento> listadoDepartamentos = new List<clsDepartamento>();

            SqlCommand comando = new SqlCommand();

            SqlDataReader miLector;

            clsDepartamento dept;

            try
            {
                //Abrimos la conexión
                SqlConnection cxnOpen = clsMyConnection.establecerConexion();

                //Configuramos el comando
                comando.CommandText = "SELECT * FROM departamentos";
                comando.Connection = cxnOpen;

                //Ejecutamos el comando
                miLector = comando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    //Leemos cada linea
                    while (miLector.Read())
                    {
                        //Creamos un objeto a los que le damos los valores
                        dept = new clsDepartamento();
                        dept.IdDepartamento = (int)miLector["ID"];
                        dept.Nombre = (string)miLector["Nombre"];

                        //Añadimos el objeto al listado
                        listadoDepartamentos.Add(dept);

                    }
                }
                //Cerramos la conexión
                miLector.Close();
                cxnOpen.Close();


            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return listadoDepartamentos;

        }

        /// <summary>
        /// Función que devuelve un departamento detallado
        /// Prescondiciones: No hay
        /// Postcondiciones: Se devuelve un departamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static clsDepartamento departamentoDetallado(int id)
        {

            clsMyConnection cnxOpen = new clsMyConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader miLector;
            clsDepartamento dept = new clsDepartamento();

            comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                //Abrimos la conexion
                SqlConnection conexionAbierta = clsMyConnection.establecerConexion();

                comando.CommandText = "SELECT * FROM departamentos WHERE ID=@id";

                comando.Connection = conexionAbierta;

                //Ejecutamos el comando
                miLector = comando.ExecuteReader();


                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    //Leemos cada linea
                    while (miLector.Read())
                    {

                        //Damos valor a los atributos del objeto
                        dept.IdDepartamento = (int)miLector["ID"];
                        dept.Nombre = (string)miLector["Nombre"];

                    }
                }
                miLector.Close();
                conexionAbierta.Close();


            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return dept;


        }
    }
}
