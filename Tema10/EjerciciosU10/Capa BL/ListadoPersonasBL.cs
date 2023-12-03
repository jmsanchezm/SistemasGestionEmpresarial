using Biblioteca;
using DAL.Listado;

namespace Capa_BL
{
    public class ListadoPersonasBL
    {

        /// <summary>
        /// Función que devuelve un listado completo de personas
        ///Precondiciones: No hay
        ///Postcondiciones: Se devuelve un listado de personas
        /// </summary>
        /// <returns></returns>
        public static List<clsPersona> ListadoCompletoPersonasBL() 
        {
            return ListadoPersonasDAL.ListadoCompletoPersonas();
        }

        /// <summary>
        /// Función que devuelve una persona detallada
        /// Precondiciones: No hay
        /// Postcondiciones: Se devuelve una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve un objeto de tipo persona</returns>
        public static clsPersona personaDetalla(int id) 
        { 
            return ListadoPersonasDAL.personaDetallada(id);
        }
    }
}