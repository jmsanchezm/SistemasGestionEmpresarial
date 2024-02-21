using CapaEntidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using CapaDAL;

namespace APIMarcaModelo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController: ControllerBase
    {

        // GET: api/<clsMarcaController>
        //Devuelve el listado completo de marcas
        [HttpGet]
        public IEnumerable<Marca> Get()
        {
              return clsListadoMarca.ListadoCompletoMarcas();
        }

        // GET api/<clsMarcaController>/{id}
        //Devuelve una marca por su id
        [HttpGet("{id}")]
        public Marca Get(int id)
        {
            return clsHandlerMarca.BuscarMarca(id);
        }

        // POST api/<clsMarcaController>
        //Inserta una marca
        [HttpPost]
        public int Post([FromBody] Marca marca)
        {

            int code = 0;

            int fila = clsHandlerMarca.InsertarMarca(marca);

            if (fila != 0)
            {
                code = 200;
            }
            return code;

        }

        // PUT api/<clsMarcaController>/{id}
        //Modifica una marca
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Marca marca)
        {
            int code = 0;

            int fila = clsHandlerMarca.ModificarMarca(marca);
            
            if (fila != 0)
            {
                code = 200;
            }
            return code;
        }

        // DELETE api/<clsMarcaController>/{id}
        //Elimina una marca
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            int code = 0;

            int filas = clsHandlerMarca.EliminarMarca(id);

            if (filas != 0)
            {
                code = 200;
            }
            return code;
        }


    }
}
