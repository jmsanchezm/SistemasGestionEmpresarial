using Capa_BL;
using Capa_Entities;
using Microsoft.AspNetCore.Mvc;

namespace Capa_UI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/<PersonasController>
        [HttpGet]
        public IEnumerable<clsPersona> Get()
        {
            return clsListaPersonasBL.ListadoCompletoPersonas();
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PersonasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            int numFilasAfectadas = 0;

            try
            {
                numFilasAfectadas = HandlerPersonaBL.deletePersona(id);
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
