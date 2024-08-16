using ApplicationLayer.Interfaces;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TPSPoznanici.Controllers
{
    [Route("mesta/")]
    [ApiController]
    public class MestoController : ControllerBase
    {
        private readonly IMestoService mestoService;

        public MestoController(IMestoService mestoService)
        {
            this.mestoService = mestoService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(mestoService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] long id)
        {
            try
            {
                return Ok(mestoService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("novo")]
        public IActionResult Save([FromBody] MestoDTO dto)
        {
            try
            {
                return Ok(mestoService.Save(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateById([FromRoute] long id, [FromBody] MestoDTO dto)
        {
            try
            {
                return Ok(mestoService.UpdateById(id, dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteById([FromRoute] long id)
        {
            try
            {
                mestoService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
