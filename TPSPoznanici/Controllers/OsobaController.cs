using ApplicationLayer.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace TPSPoznanici.Controllers
{
    [Route("poznanici/")]
    [ApiController]
    public class OsobaController : ControllerBase
    {
        private readonly IOsobaService osobaService;

        //private readonly ILogger<OsobaController> _logger;

        public OsobaController(IOsobaService osobaService)
        {
            this.osobaService = osobaService;
            //this._logger = _logger;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            //_logger.LogInformation(">>> GET ALL");
            try
            {
                //_logger.LogInformation("vrati sve osobe");
                return Ok(osobaService.GetAll());
            }
            catch (Exception ex)
            {
                //_logger.LogWarning("greska pri vracanju svih osoba");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] long id)
        {
            try
            {
                return Ok(osobaService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("novi")]
        public IActionResult Save([FromBody] OsobaDTO dto)
        {
            try
            {
                return Ok(osobaService.Save(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] long id, [FromBody] OsobaDTO dto)
        {
            try
            {
                return Ok(osobaService.UpdateById(id, dto));
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
                osobaService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //---------------

        [HttpGet]
        [Route("maxvisina")]
        public IActionResult GetMaxVisina()
        {
            try
            {
                return Ok(osobaService.GetMaxVisina());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("srednjastarost")]
        public IActionResult GetSrednjaStarost()
        {
            try
            {
                return Ok(osobaService.GetSrednjaStarost());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //---------------

        [HttpGet]
        [Route("punoletni")]
        public IActionResult GetAllPunoletni()
        {
            try
            {
                return Ok(osobaService.GetAllPunoletni());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("smederevci")]
        public IActionResult GetAllSmederevci()
        {
            try
            {
                return Ok(osobaService.GetAllSmederevci());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
