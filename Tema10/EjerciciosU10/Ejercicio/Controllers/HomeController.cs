using Biblioteca;
using Capa_BL;
using Capa_BL.ManejadorasBL;
using Capa_UI.Models.ViewModels;
using Ejercicio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Ejercicio.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Función que muestra el listado completo de personas
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
           
            return View(ListadoPersonasBL.ListadoCompletoPersonasBL());

        }


        /// <summary>
        /// Función que muestra los detalles de una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Detalles(int id)
        {

            try
            {
                clsPersona pers = ListadoPersonasBL.personaDetalla(id);

                PersonaConDepartamento viewmodel = new PersonaConDepartamento(pers);

                return View(viewmodel);
            }
            catch (Exception ex)
            {
                return View("Error");
            }

        }

        /// <summary>
        /// Función que muestra el formulario para crear una persona
        /// </summary>
        /// <returns></returns>
        public ActionResult Insertar()
        {
           
            PersonaConListadoDepartamento viewmodel = new PersonaConListadoDepartamento();
            return View(viewmodel);
        }


        /// <summary>
        /// Función que crea una persona
        /// </summary>
        /// <param name="pers"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insertar(clsPersona pers)
        {

            try
            {

                int numFilasAfectadas = InsertarBL.createPersonaBL(pers);

                if (numFilasAfectadas == 0)
                {
                    ViewBag.Info = "No se ha podido la persona";
                }

                else
                {
                    ViewBag.Info = "La persona se ha creado correctamente";
                }

                return View("Index", ListadoPersonasBL.ListadoCompletoPersonasBL());




            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        /// <summary>
        /// Función que muestra el formulario para editar una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Editar(int id)
        {
            
            clsPersona pers = ListadoPersonasBL.personaDetalla(id);

            
            PersonaConListadoDepartamento viewmodel = new PersonaConListadoDepartamento(pers);

            return View(viewmodel);
        }

        /// <summary>
        /// Función que edita una persona
        /// </summary>
        /// <param name="pers"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Editar(clsPersona pers)
        {
            
            int numFilasAfectadas = EditarBL.editPersonaBL(pers);

            try
            {

                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                return View("Error");
            }



        }

        /// <summary>
        /// Función que muestra el formulario para borrar una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Borrar(int id)
        {
            try
            {
                clsPersona pers = ListadoPersonasBL.personaDetalla(id);
               
                PersonaConDepartamento viewmodel = new PersonaConDepartamento(pers);

                return View(viewmodel);
            }
            catch (Exception ex)
            {
                return View("Error");
            }



        }

        /// <summary>
        /// Función que borra una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ActionName("Borrar")]
        [HttpPost]
        public ActionResult BorrarPost(int id)
        {
            try
            {
                int numFilas = BorrarBL.borraPersona(id);

                if (numFilas == 0)
                {
                    ViewBag.Info = "No existe en la BBDD";
                }
                else if (numFilas == -1)
                {
                    ViewBag.Info = "Hoy es miércoles, no se pueden borrar personas";
                }
                else
                {
                    ViewBag.Info = "La persona se ha borrado correctamente";
                }

                return View("Index", ListadoPersonasBL.ListadoCompletoPersonasBL());



            }
            catch (Exception e)
            {
                return View("Error");
            }

        }


    }
}