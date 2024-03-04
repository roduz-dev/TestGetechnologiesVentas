using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioRest.Models;
using ServicioRest.Repositories.Implementations;
using ServicioRest.Repositories.Interfaces;

namespace ServicioRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private IFactura _facturaRepository;
        private readonly ILogger<VentasController> _logger;
        public VentasController(IFactura facturaRepository, ILogger<VentasController> logger)
        {
            _facturaRepository = facturaRepository;
            _logger = logger;
        }

        [HttpGet("findFacturas")]
        public IActionResult Index()
        {
            var result = _facturaRepository.GetAllFacturas();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("findFacturasByPersona/{identificacion}")]
        public IActionResult GetByIdentificacion(string identificacion)
        {
            var result = _facturaRepository.GetFacturaByPersona(identificacion);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("storeFactura")]
        public IActionResult Post([FromBody] Factura factura)
        {
            int result = _facturaRepository.CreateFactura(factura);
            if (result <= 0)
            {
                return BadRequest("Failed");
            }

            return Ok(factura);
        }


    }
}
