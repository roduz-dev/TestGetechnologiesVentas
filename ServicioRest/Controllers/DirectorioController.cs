using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioRest.Models;
using ServicioRest.Repositories.Interfaces;

namespace ServicioRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorioController : ControllerBase
    {
        private IPersona _personaRepository;
        private readonly ILogger<DirectorioController> _logger;
        public DirectorioController(IPersona personaRepository, ILogger<DirectorioController> logger)
        {
            _personaRepository = personaRepository;
            _logger = logger;
        }

        [HttpGet("findPersonas")]
        public IActionResult Index()
        {
            var result = _personaRepository.GetAllPersonas();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("findPersonaById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _personaRepository.GetPersonaById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        [HttpGet("FindPersonaByIdentificacion/{identificacion}")]
        public IActionResult GetByIdentificacion(string identificacion)
        {
            var result = _personaRepository.GetPersonaByIdentificacion(identificacion);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        [HttpPost("storePersona")]
        public IActionResult Post([FromBody] Persona persona)
        {
            int result = _personaRepository.CreatePersona(persona);
            if (result <= 0)
            {
                return BadRequest("Failed");
            }

            return Ok(persona);
        }

        [HttpDelete("deletePersonaByIdentificacion/{identificacion}")]
        public IActionResult Delete(string identificacion)
        {
            int resp = _personaRepository.DeletePersonaByIdentificacion(identificacion);
            if (resp <= 0)
            {
                return BadRequest("Failed");
            }

            return Ok("Identificacion Eliminado : " + identificacion);
        }
    }
}
