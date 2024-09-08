using ApplicationLayer.DTO;
using ApplicationLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace TPSPoznanici.Controllers
{
    [Route("homes/")]
    [ApiController]
    public class HomeController : Controller
    {
        public readonly IHomeService _homeService;

        public HomeController(IHomeService homeService) 
        {
            _homeService = homeService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            List<HomeDTO> homes = _homeService.GetAll();
            if (homes.IsNullOrEmpty())
            {
                return NotFound("Homes do not exist.");
            }

            return Ok(homes);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            HomeDTO home = _homeService.GetById(id);
            if (home == null)
            {
                return NotFound($"Home with id {id} does not exist.");
            }

            return Ok(home);
        }


        [HttpPost]
        [Route("")]
        public IActionResult Save([FromBody] HomeDTO dto)
        {
            HomeDTO response = _homeService.Save(dto);
            return Ok(response);
        }
    }
}
