﻿using L01_2019SM601.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace L01_2019SM601.Controllers
{
    public class motoristaController : ControllerBase
    {
        private readonly motoristaContext _entidadesContexto;

        public motoristaController(motoristaContext entidadesContexto)
        {
            _entidadesContexto = entidadesContexto; ;
        }

        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<motorista> listadoEntidades = (from e in _entidadesContexto.entidades
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
            motorista? motorista = (from e in _entidadesContexto.entidades
                                    where e.motoristaId == id
                                    select e).FirstOrDefault();

            if (motorista == null)
            {
                return NotFound();
            }
            return Ok(motorista);

        }
        [HttpGet]
        [Route("Find/{filtro}")]

        public IActionResult FindbyDescription(String filtro)
        {
            motorista? entidades = (from e in _entidadesContexto.entidades
                                    where e.nombreMotorista.Contains(filtro)
                                    select e).FirstOrDefault();

            if (entidades == null)
            {
                return NotFound();
            }
            return Ok(entidades);
        }

        [HttpPost]
        [Route("Add")]

        public IActionResult GuardarEntidades([FromBody] motorista entidades)
        {

            try
            {
                _entidadesContexto.entidades.Add(entidades);
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
            motorista? entidadesActual = (from e in _entidadesContexto.entidades
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

            motorista? entidades = (from e in _entidadesContexto.entidades
                                    where e.motoristaId == id
                                    select e).FirstOrDefault();

            if (entidades == null)
                return NotFound();

            _entidadesContexto.entidades.Attach(entidades);
            _entidadesContexto.entidades.Remove(entidades);
            _entidadesContexto.SaveChanges();

            return Ok(entidades);
        }



    }
}
