using Biblioteca;
using BonustrackU8.DAL;

namespace BonustrackU8.Models.ViewModel
{
    public class ListadoMisionConMisionSeleccionada : clsMision
    {

        public List<clsMision> listado = ListadoMisionesDAL.ListadoMisionesCompleto();

        public ListadoMisionConMisionSeleccionada ()
        {
     
        }

        public ListadoMisionConMisionSeleccionada(int id, string nombre, string detalles, int recompensa) : base(id, nombre, detalles, recompensa) 
        { 

        }

       






    }
}
