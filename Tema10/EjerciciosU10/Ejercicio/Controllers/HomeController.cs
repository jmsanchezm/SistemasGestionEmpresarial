using Ejercicio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Ejercicio.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {

            SqlConnection miConexion = new SqlConnection();

            try
            {
                miConexion.ConnectionString = "server=juanma.database.windows.net;database=Personas;uid=prueba;pwd=fernandoG321;trustServerCertificate = true";

                miConexion.Open();

                ViewBag.Connection = miConexion.State;

            } catch (Exception e) 
            {
                ViewBag.Connection = $"Error: {e.Message}";
            }

            return View();
        }

        public ActionResult ListaPersonas()
        {

            return View();
        }

       
    }
}