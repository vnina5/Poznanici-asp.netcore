using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace TPSPoznanici.Controllers
{
    [Route("friends/")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonService personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }


        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            List<PersonDTO> persons = _personService.GetAll();
            if (persons.IsNullOrEmpty())
            {
                return NotFound("Persons do not exist.");
            }

            return Ok(persons);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            PersonDTO person = _personService.GetById(id);
            if (person == null)
            {
                return NotFound($"Person with id {id} does not exist.");
            }

            return Ok(person);
        }


        [HttpPost]
        [Route("")]
        public IActionResult Save([FromBody] PersonDTO dto)
        {
            PersonDTO response = _personService.Save(dto);
            return Ok(response);
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] PersonDTO dto)
        {
            PersonDTO person = _personService.GetById(id);
            if (person == null)
            {
                return NotFound($"Person with id {id} does not exist.");
            }

            PersonDTO response = _personService.UpdateById(id, dto);
            return Ok(response);
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            PersonDTO person = _personService.GetById(id);
            if (person == null)
            {
                return NotFound($"Person with id {id} does not exist.");
            }

            _personService.DeleteById(id);
            return Ok();
        }


        //---------------

        [HttpGet]
        [Route("maxHeight")]
        public IActionResult GetMaxVisina()
        {
            int response = _personService.GetMaxHeight();
            return Ok(response);
        }


        [HttpGet]
        [Route("averageAge")]
        public IActionResult GetSrednjaStarost()
        {
            int response = _personService.GetAverageAge();
            return Ok(response);
        }


        //---------------

        [HttpGet]
        [Route("adults")]
        public IActionResult GetAllPunoletni()
        {
            List<PersonDTO> persons = _personService.GetAllAdults();
            if (persons.IsNullOrEmpty())
            {
                return NotFound("There are no adults.");
            }

            return Ok(persons);           
        }


        [HttpGet]
        [Route("fromSmederevo")]
        public IActionResult GetAllSmederevci()
        {
            List<PersonDTO> persons = _personService.GetAllFromSmederevo();
            if (persons.IsNullOrEmpty())
            {
                return NotFound("There are no persons from Smederevo.");
            }

            return Ok(persons);
        }


    }
}
