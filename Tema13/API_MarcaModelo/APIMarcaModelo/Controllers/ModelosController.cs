using CapaDAL;
using CapaEntidades;
using Microsoft.AspNetCore.Mvc;

namespace APIMarcaModelo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelosController: ControllerBase
    {
        // GET: api/<ModelosController>
        //Devuelve el listado completo de modelos
        public IEnumerable<Modelo> Get()
        {
            return clsListadoModelo.ListadoCompletoModelos();
        }

        // GET api/<ModelosController>/{id}
        //Devuelve un modelo por su id
        [HttpGet("{id}")]
        public Modelo Get(int id)
        {
            return clsHandlerModelo.BuscarModelo(id);
        }

        // POST api/<ModelosController>
        //Inserta un modelo
        [HttpPost]
        public int Post([FromBody] Modelo modelo)
        {
            int code = 0;
            int fila = clsHandlerModelo.InsertarModelo(modelo);
            if (fila != 0)
            {
                code = 200;
            }
            return code;
        }

        // PUT api/<ModelosController>/{id}
        //Modifica un modelo
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Modelo modelo)
        {
            int code = 0;
            int fila = clsHandlerModelo.ModificarModelo(modelo);
            if (fila != 0)
            {
                code = 200;
            }
            return code;
        }

        // DELETE api/<ModelosController>/{id}
        //Elimina un modelo
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            int code = 0;
            int fila = clsHandlerModelo.EliminarModelo(id);
            if (fila != 0)
            {
                code = 200;
            }
            return code;
        }



    }
}
