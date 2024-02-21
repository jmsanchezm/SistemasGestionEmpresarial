using Capa_DAL;
using Capa_Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Capa_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController
    {
        // GET: api/<DepartamentosController>
        [HttpGet]
        public IEnumerable<clsDepartamento> Get()
        {
            return clsListadoDepartamentosDAL.listadoDepartamentos();
        }

        // GET api/<DepartamentosController>/{id}
        [HttpGet("{id}")]
        public clsDepartamento Get(int id)
        {
            return clsHandlerDepartamentosDAL.ObtenerDepartamento(id);
        }

        // POST api/<DepartamentosController>
        [HttpPost]
        public void Post([FromBody] clsDepartamento value)
        {
            clsHandlerDepartamentosDAL.InsertarDepartamento(value);
        }

        // PUT api/<DepartamentosController>/{id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] clsDepartamento dep)
        {
            clsHandlerDepartamentosDAL.ActualizarDepartamento(dep);
        }

        // DELETE api/<DepartamentosController>/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            clsHandlerDepartamentosDAL.BorrarDepartamento(id);
        }


    }
}
