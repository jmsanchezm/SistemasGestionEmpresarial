﻿using Microsoft.AspNetCore.Mvc;

namespace Ejercicio1.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult ListaProductos()
        {
            return View();
        }
    }
}
