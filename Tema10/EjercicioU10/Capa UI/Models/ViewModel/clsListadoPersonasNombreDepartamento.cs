using Capa_BL;
using Capa_Entities;
using System.Collections.ObjectModel;

namespace Capa_UI.Models.ViewModel
{
    public class clsListadoPersonasNombreDepartamento
    {
        /// <summary>
        /// Listado de personas obtenido en la capa BL
        /// </summary>
        public static ObservableCollection<clsPersona> ListadoPersonas()
        {
            return clsListaPersonasBL.ListadoCompletoPersonas();
        }

        /// <summary>
        /// Función que devuelve el nombre del departamento
        /// </summary>
        /// <param name="idDepart">Id del departamento</param>
        /// <returns>Nombre del departamento</returns>
        public static ObservableCollection<clsDepartamento> ListadoDepartamentos()
        {
            return clsListaDepartamentosBL.ListadoCompletoDepartamentos();
        }
    }
}
