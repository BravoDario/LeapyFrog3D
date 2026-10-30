using LeapyFrog3D.Server.DTOs;
using LeapyFrog3D.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeapyFrog3D.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnidadesController : ControllerBase
    {
        private readonly UnidadService _unidadService;
        private readonly ILogger<UnidadesController> _logger;

        public UnidadesController(UnidadService unidadService, ILogger<UnidadesController> logger)
        {
            _unidadService = unidadService;
            _logger = logger;
        }

        [HttpGet(Name = "obtenerUnidades")]
        public ActionResult<List<UnidadDto>> obtenerUnidades()
        {
            try
            {
                return Ok(_unidadService.obtenerUnidades());
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Error al obtener las unidades");
                return BadRequest("Error en el servidor");
            }
        }
    }
}
