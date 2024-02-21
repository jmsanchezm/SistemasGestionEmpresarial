using Capa_DAL;
using Capa_Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Capa_UI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController
    {

        // GET: api/<PersonasController>
        [HttpGet]
        public IEnumerable<clsPersona> Get()
        {
            return clsListadoPersonasDAL.listadoPersonas();
        }

        // GET api/<PersonasController>/{id}
        [HttpGet("{id}")]
        public clsPersona Get(int id)
        {
            return clsHandlerPersonasDAL.ObtenerPersona(id);
        }

        // POST api/<PersonasController>
        [HttpPost]
        public void Post([FromBody] clsPersona value)
        {
            clsHandlerPersonasDAL.InsertarPersona(value);
        }

        // PUT api/<PersonasController>/{id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] clsPersona pers)
        {
            clsHandlerPersonasDAL.ActualizarPersona(pers);
        }

        // DELETE api/<PersonasController>/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            clsHandlerPersonasDAL.BorrarPersona(id);
        }

    }
}
