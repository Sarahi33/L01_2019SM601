using L01_2019SM601.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace L01_2019SM601.Controllers
{
    public class platoController : ControllerBase
    {
        private readonly entidadesContext _entidadesContexto;

        public platoController(entidadesContext entidadesContexto)
        {
            _entidadesContexto = entidadesContexto; ;
        }

        //ALL
        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<plato> listadoEntidades = (from e in _entidadesContexto.platos
                                                select e).ToList();

            if (listadoEntidades.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoEntidades);

        }

        // GET
        [HttpGet]
        [Route("GetByNombre/{name}")]

        public IActionResult GetNombre(string name)
        {
            List<plato> listadoPlatos = (from e in _entidadesContexto.platos
                                    where e.nombrePlato == name
                                    select e).ToList();

            if (listadoPlatos.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoPlatos);

        }

        //FILTRO
        [HttpGet]
        [Route("Find/{filtro}")]

        public IActionResult FindbyDescription(String filtro)
        {
            plato? entidades = (from e in _entidadesContexto.platos
                                    where e.nombrePlato.Contains(filtro)
                                    select e).FirstOrDefault();

            if (entidades == null)
            {
                return NotFound();
            }
            return Ok(entidades);
        }

        // ADD
        [HttpPost]
        [Route("Add")]

        public IActionResult GuardarEntidades([FromBody] plato entidades)
        {

            try
            {
                _entidadesContexto.platos.Add(entidades);
                _entidadesContexto.SaveChanges();
                return Ok(entidades);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        //ACTUALIZAR
        [HttpPut]
        [Route("actualizar/{id}")]

        public IActionResult ActualizarEntidades(int id, [FromBody] plato entidadesModificar)
        {
            plato? entidadesActual = (from e in _entidadesContexto.platos
                                          where e.platoId == id
                                          select e).FirstOrDefault();
            if (entidadesActual == null)
            {
                return NotFound(id);
            }
            
            entidadesActual.nombrePlato = entidadesModificar.nombrePlato;
            entidadesActual.precio = entidadesModificar.precio;


            _entidadesContexto.Entry(entidadesActual).State = EntityState.Modified;
            _entidadesContexto.SaveChanges();
            return Ok(entidadesModificar);
        }

        // ELIMINAR
        [HttpDelete]
        [Route("eliminar/{id}")]

        public IActionResult EliminarEntidades(int id)
        {

            plato? entidades = (from e in _entidadesContexto.platos
                                    where e.platoId == id
                                    select e).FirstOrDefault();

            if (entidades == null)
                return NotFound();

            _entidadesContexto.platos.Attach(entidades);
            _entidadesContexto.platos.Remove(entidades);
            _entidadesContexto.SaveChanges();

            return Ok(entidades);
        }
    }
}
