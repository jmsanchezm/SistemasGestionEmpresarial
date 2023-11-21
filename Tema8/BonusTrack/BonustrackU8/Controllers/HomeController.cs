using Biblioteca;
using Microsoft.AspNetCore.Mvc;
using BonustrackU8.DAL;
using BonustrackU8.Models.ViewModel;

namespace BonustrackU8.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Método que mandará un listado de misiones a la vista
        /// Precondiciones: ninguna 
        /// Postcondiciones: ninguna
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ListadoMisionConMisionSeleccionadaVM listMisConMisSel = new ListadoMisionConMisionSeleccionadaVM();

            return View(listMisConMisSel);
        }


        /// <summary>
        /// Método que le pasará un listado con misiones y una mision selecionada
        /// Precondiciones: debe llegar el id de la mision seleccionada
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
       public IActionResult Index(int Id) 
        {
            clsMision misionSeleccionada = ListadoMisionesDAL.ListadoMisionesCompleto().FirstOrDefault(m => m.Id == Id);

            ListadoMisionConMisionSeleccionadaVM listadoConMisionSeleccionada = new ListadoMisionConMisionSeleccionadaVM
            (
                misionSeleccionada.Id,
                misionSeleccionada.Nombre,
                misionSeleccionada.Detalles,
                misionSeleccionada.Recompensa
            ); 
         
            return View(listadoConMisionSeleccionada);
    
        }
        
    }
}