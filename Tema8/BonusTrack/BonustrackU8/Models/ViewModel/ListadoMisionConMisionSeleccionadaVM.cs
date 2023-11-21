using Biblioteca;
using BonustrackU8.DAL;

namespace BonustrackU8.Models.ViewModel
{
    public class ListadoMisionConMisionSeleccionadaVM : clsMision
    {

        public List<clsMision> listado = ListadoMisionesDAL.ListadoMisionesCompleto();

        public ListadoMisionConMisionSeleccionadaVM ()
        {
     
        }

        public ListadoMisionConMisionSeleccionadaVM(int id, string nombre, string detalles, int recompensa) : base(id, nombre, detalles, recompensa) 
        { 

        }

       






    }
}
