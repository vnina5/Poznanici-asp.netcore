using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace TPSPoznanici.Controllers
{
    [Route("persons/")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }


        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            try
            {
                List<PersonDTO> persons = _personService.GetAll();
                if (persons.IsNullOrEmpty())
                {
                    return NotFound("Persons do not exist.");
                }

                return Ok(persons);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                PersonDTO person = _personService.GetById(id);
                if (person == null)
                {
                    return NotFound($"Person with id {id} does not exist.");
                }

                return Ok(person);
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
                PersonDTO response = _personService.Save(dto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] PersonDTO dto)
        {
            try
            {
                PersonDTO response = _personService.UpdateById(id, dto);
                if (response == null)
                {
                    return NotFound($"Person with id {id} does not exist.");
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                PersonDTO person = _personService.GetById(id);
                if (person == null)
                {
                    return NotFound($"Person with id {id} does not exist.");
                }

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
                int response = _personService.GetMaxHeight();
                return Ok(response);
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
                int response = _personService.GetAverageAge();
                return Ok(response);
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
                List<PersonDTO> persons = _personService.GetAllAdults();
                if (persons.IsNullOrEmpty())
                {
                    return NotFound("There are no adults.");
                }

                return Ok(persons);
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
                List<PersonDTO> persons = _personService.GetAllFromSmederevo();
                if (persons.IsNullOrEmpty())
                {
                    return NotFound("There are no persons from Smederevo.");
                }

                return Ok(persons);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
