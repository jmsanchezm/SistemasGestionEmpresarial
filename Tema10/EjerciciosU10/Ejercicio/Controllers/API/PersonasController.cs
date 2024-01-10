using Microsoft.AspNetCore.Mvc;
using Capa_BL;
using System.Collections.ObjectModel;
using Biblioteca;
using Capa_BL.ManejadorasBL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Capa_UI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/<PersonasController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<clsPersona> lista = new List<clsPersona>();
            try
            {
                lista = ListadoPersonasBL.ListadoCompletoPersonasBL();

                if (lista.Count == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(lista);
                }
            }
            catch (Exception e)
            {
                salida = BadRequest();
            }

            return salida;
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            clsPersona persona = new clsPersona();
            try
            {
                persona = ListadoPersonasBL.personaDetalla(id);
                if (persona == null)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok(persona);
                }
            }
            catch (Exception e)
            {
                salida = BadRequest();
            }
            return salida;
        }

        // POST api/<PersonasController>
        [HttpPost]
        public void Post([FromBody] clsPersona pers)
        {

            try 
            { 

                InsertarBL.createPersonaBL(pers);

            }catch (Exception e) 
            { 
              
            }

        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] clsPersona pers)
        {

            try
            {
                if (id != pers.Id)
                {
                    BadRequest();
                }
                else 
                {
                    EditarBL.editPersonaBL(pers);
                }

            }
            catch (Exception e)
            {

            }


        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            int numFilasAfectadas = 0;
            BorrarBL miManejadoraPersona;

            try
            {
                miManejadoraPersona = new BorrarBL();
                numFilasAfectadas = BorrarBL.borraPersona(id);
                if (numFilasAfectadas == 0)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok();
                }
            }
            catch (Exception e)
            {
                salida = BadRequest();
            }

            return salida;
        }

    }
}
