using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using L01_2019SM601.Models;
using Microsoft.AspNetCore.Http;


namespace L01_2019SM601.Controllers
{
    public class clientesController : ControllerBase
    {
        private readonly entidadesContext _entidadesContexto;

        public clientesController(entidadesContext entidadesContexto)
        {
            _entidadesContexto = entidadesContexto; ;
        }

        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<clientess> listadoEntidades = (from e in _entidadesContexto.clientesses
                                             select e).ToList();

            if (listadoEntidades.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoEntidades);

        }

        [HttpGet]
        [Route("GetById/{name}")]

        public IActionResult GetNombre(String name)
        {
            clientess? entidades = (from e in _entidadesContexto.clientesses
                                    where e.nombreCliente == name
                                    select e).FirstOrDefault();

            if (entidades == null)
            {
                return NotFound();
            }
            return Ok(entidades);

        }
       
        [HttpPost]
        [Route("Add")]

        public IActionResult GuardarEntidades([FromBody] clientess entidades)
        {

            try
            {
                _entidadesContexto.clientesses.Add(entidades);
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

        public IActionResult ActualizarEntidades(int id, [FromBody] clientess entidadesModificar)
        {
            clientess? entidadesActual = (from e in _entidadesContexto.clientesses
                                      where e.clienteId == id
                                      select e).FirstOrDefault();
            if (entidadesActual == null)
            {
                return NotFound(id);
            }

            entidadesActual.nombreCliente = entidadesModificar.nombreCliente;
            entidadesActual.direccion = entidadesModificar.direccion;
            

            _entidadesContexto.Entry(entidadesActual).State = EntityState.Modified;
            _entidadesContexto.SaveChanges();
            return Ok(entidadesModificar);
        }

        [HttpDelete]
        [Route("eliminar/{id}")]

        public IActionResult EliminarEntidades(int id)
        {

            clientess? entidades = (from e in _entidadesContexto.clientesses
                               where e.clienteId == id
                               select e).FirstOrDefault();

            if (entidades == null)
                return NotFound();

            _entidadesContexto.clientesses.Attach(entidades);
            _entidadesContexto.clientesses.Remove(entidades);
            _entidadesContexto.SaveChanges();

            return Ok(entidades);
        }

    }



}

