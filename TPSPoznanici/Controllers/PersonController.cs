using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TPSPoznanici.Controllers
{
    [Route("friends/")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        //private readonly ILogger<OsobaController> _logger;

        public PersonController(IPersonService personService)
        {
            this._personService = personService;
            //this._logger = _logger;
        }


        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_personService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] long id)
        {
            try
            {
                return Ok(_personService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("")]
        public IActionResult Save([FromBody] PersonDTO dto)
        {
            try
            {
                return Ok(_personService.Save(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] long id, [FromBody] PersonDTO dto)
        {
            try
            {
                return Ok(_personService.UpdateById(id, dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] long id)
        {
            try
            {
                _personService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //---------------

        [HttpGet]
        [Route("maxHeight")]
        public IActionResult GetMaxVisina()
        {
            try
            {
                return Ok(_personService.GetMaxHeight());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("averageAge")]
        public IActionResult GetSrednjaStarost()
        {
            try
            {
                return Ok(_personService.GetAverageAge());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //---------------

        [HttpGet]
        [Route("adults")]
        public IActionResult GetAllPunoletni()
        {
            try
            {
                return Ok(_personService.GetAllAdults());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("fromSmederevo")]
        public IActionResult GetAllSmederevci()
        {
            try
            {
                return Ok(_personService.GetAllFromSmederevo());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
