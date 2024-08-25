using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TPSPoznanici.Controllers
{
    [Route("cities/")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            this._cityService = cityService;
        }


        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_cityService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                return Ok(_cityService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("")]
        public IActionResult Save([FromBody] CityDTO dto)
        {
            try
            {
                return Ok(_cityService.Save(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateById([FromRoute] int id, [FromBody] CityDTO dto)
        {
            try
            {
                return Ok(_cityService.UpdateById(id, dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            try
            {
                _cityService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
