using L01_2019SM601.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L01_2019SM601.Controllers
{
    public class pedidoController : ControllerBase
    {
        private readonly entidadesContext _entidadesContexto;

        public pedidoController(entidadesContext entidadesContexto)
        {
            _entidadesContexto = entidadesContexto; ;
        }
        // ALL
        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<pedido> listadoEntidades = (from e in _entidadesContexto.pedidos
                                                select e).ToList();

            if (listadoEntidades.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoEntidades);

        }
        

       
        // ADD
        [HttpPost]
        [Route("Add")]

        public IActionResult GuardarEntidades([FromBody] pedido entidades)
        {

            try
            {
                _entidadesContexto.pedidos.Add(entidades);
                _entidadesContexto.SaveChanges();
                return Ok(entidades);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }
        // ACTUALIZAR
        [HttpPut]
        [Route("actualizar/{id}")]

        public IActionResult ActualizarEntidades(int id, [FromBody] pedido entidadesModificar)
        {
            pedido? entidadesActual = (from e in _entidadesContexto.pedidos
                                          where e.pedidoId == id
                                          select e).FirstOrDefault();
            if (entidadesActual == null)
            {
                return NotFound(id);
            }

            
            entidadesActual.motoristaId = entidadesModificar.motoristaId;
            entidadesActual.clienteId = entidadesModificar.clienteId;
            entidadesActual.platoId = entidadesModificar.platoId;
            entidadesActual.cantidad = entidadesModificar.cantidad;
            entidadesActual.precio= entidadesModificar.precio;


            _entidadesContexto.Entry(entidadesActual).State = EntityState.Modified;
            _entidadesContexto.SaveChanges();
            return Ok(entidadesModificar);
        }

        //ELIMINAR
        [HttpDelete]
        [Route("eliminar/{id}")]

        public IActionResult EliminarEntidades(int id)
        {

            pedido? entidades = (from e in _entidadesContexto.pedidos
                                    where e.pedidoId == id
                                    select e).FirstOrDefault();

            if (entidades == null)
                return NotFound();

            _entidadesContexto.pedidos.Attach(entidades);
            _entidadesContexto.pedidos.Remove(entidades);
            _entidadesContexto.SaveChanges();

            return Ok(entidades);
        }



    }
}
