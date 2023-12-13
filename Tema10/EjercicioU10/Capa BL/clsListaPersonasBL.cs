using Capa_DAL;
using Capa_Entities;
using System.Collections.ObjectModel;

namespace Capa_BL
{
    public class clsListaPersonasBL
    {
        public static ObservableCollection<clsPersona> ListadoCompletoPersonas()
        {
            return clsListaPersonasDAL.listadoCompletoPersonas();
        }

        public static clsPersona PersonaPorId(int id)
        {
            return clsListaPersonasDAL.PersonaPorId(id);
        }
      
     
    }
}