using Biblioteca;
using DAL.Listado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL
{
    public class ListadoDepartamentosBL
    {
        /// <summary>
        /// Función que devuelve un listado completo de departamentos
        /// Con reglas de negocio
        /// Precondiciones: No hay
        /// Postcondiciones: Se devuelve un listado de departamentos
        /// </summary>
        /// <returns>Devuelve el listado de departamentos</returns>
        public static List<clsDepartamento> listadoCompletoDepartamentos()
        {
            return ListadoDepartamentosDAL.ListadoCompletoDepartamentos(); ;
        }   

        /// <summary>
        /// Función que devuelve un departamento detallado
        /// con reglas de negocio
        /// Precondiciones: No hay
        /// Postcondiciones: Se devuelve un departamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Se devuelve un departamento</returns>
        public static clsDepartamento departamentoSelect(int id)
        {
            return ListadoDepartamentosDAL.departamentoDetallado(id);
        }
    }
}
