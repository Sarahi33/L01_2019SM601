using L01_2019SM601.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace L01_2019SM601.Controllers
{
    public class motoristaController : ControllerBase
    {
        private readonly entidadesContext _entidadesContexto;

        public motoristaController(entidadesContext entidadesContexto)
        {
            _entidadesContexto = entidadesContexto; ;
        }
        // ALL
        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<motorista> listadoEntidades = (from e in _entidadesContexto.motoristas
                                                select e).ToList();

            if (listadoEntidades.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoEntidades);

        }

        [HttpGet]
        [Route("GetById/{name}")]

        public IActionResult Get(string name)
        {
            motorista? motorista = (from e in _entidadesContexto.motoristas
                                    where e.nombreMotorista == name
                                    select e).FirstOrDefault();

            if (motorista == null)
            {
                return NotFound();
            }
            return Ok(motorista);

        }

      
        [HttpPost]
        [Route("Add")]

        public IActionResult GuardarEntidades([FromBody] motorista entidades)
        {

            try
            {
                _entidadesContexto.motoristas.Add(entidades);
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

        public IActionResult ActualizarEntidades(int id, [FromBody] motorista entidadesModificar)
        {
            motorista? entidadesActual = (from e in _entidadesContexto.motoristas
                                          where e.motoristaId == id
                                          select e).FirstOrDefault();
            if (entidadesActual == null)
            {
                return NotFound(id);
            }

            entidadesActual.nombreMotorista = entidadesModificar.nombreMotorista;
           


            _entidadesContexto.Entry(entidadesActual).State = EntityState.Modified;
            _entidadesContexto.SaveChanges();
            return Ok(entidadesModificar);
        }

        [HttpDelete]
        [Route("eliminar/{id}")]

        public IActionResult EliminarEntidades(int id)
        {

            motorista? entidades = (from e in _entidadesContexto.motoristas
                                    where e.motoristaId == id
                                    select e).FirstOrDefault();

            if (entidades == null)
                return NotFound();

            _entidadesContexto.motoristas.Attach(entidades);
            _entidadesContexto.motoristas.Remove(entidades);
            _entidadesContexto.SaveChanges();

            return Ok(entidades);
        }



    }
}
