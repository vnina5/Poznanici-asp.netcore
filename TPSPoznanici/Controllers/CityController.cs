using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace TPSPoznanici.Controllers
{
    [Route("cities/")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }


        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            List<CityDTO> cities = _cityService.GetAll();
            if (cities.IsNullOrEmpty())
            {
                return NotFound("Cities do not exist.");
            }

            return Ok(cities);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            CityDTO city = _cityService.GetById(id);
            if (city == null)
            {
                return NotFound($"City with id {id} does not exist.");
            }

            return Ok(city);
        }


        [HttpPost]
        [Route("")]
        public IActionResult Save([FromBody] CityDTO dto)
        {
            CityDTO response = _cityService.Save(dto);
            return Ok(response);
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateById([FromRoute] int id, [FromBody] CityDTO dto)
        {
            CityDTO response = _cityService.UpdateById(id, dto);
            if (response == null)
            {
                return NotFound($"City with id {id} does not exist.");
            }
            return Ok(response);
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdateByIdPatch([FromRoute] int id, [FromBody] CityDTO dto)
        {
            CityDTO response = _cityService.UpdateById(id, dto);
            if (response == null)
            {
                return NotFound($"City with id {id} does not exist.");
            }
            return Ok(response);
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            CityDTO city = _cityService.GetById(id);
            if (city == null)
            {
                return NotFound($"City with id {id} does not exist.");
            }

            _cityService.DeleteById(id);
            return Ok();
        }


    }
}
