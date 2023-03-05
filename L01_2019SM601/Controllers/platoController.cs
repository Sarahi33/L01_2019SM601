using L01_2019SM601.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L01_2019SM601.Controllers
{
    public class platoController : ControllerBase
    {
        private readonly entidadesContext _entidadesContexto;

        public platoController(entidadesContext entidadesContexto)
        {
            _entidadesContexto = entidadesContexto; ;
        }

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

        [HttpGet]

        [Route("GetById/{id}")]

        public IActionResult Get(int id)
        {
            plato? plato = (from e in _entidadesContexto.platos
                                    where e.platoId == id
                                    select e).FirstOrDefault();

            if (plato == null)
            {
                return NotFound();
            }
            return Ok(plato);

        }

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
