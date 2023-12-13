using Capa_BL;
using Capa_Entities;
using Microsoft.AspNetCore.Mvc;

namespace Capa_UI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        // GET: api/<DepartamentosController>
        [HttpGet]
        public IEnumerable<clsDepartamento> Get()
        {
            return clsListaDepartamentosBL.ListadoCompletoDepartamentos();
        }

        // GET api/<DepartamentosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DepartamentosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DepartamentosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartamentosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
