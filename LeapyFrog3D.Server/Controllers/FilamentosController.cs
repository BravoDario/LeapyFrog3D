using LeapyFrog3D.Server.DTOs;
using LeapyFrog3D.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LeapyFrog3D.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilamentosController(FilamentoService filamentoService, Logger<FilamentosController> logger) : ControllerBase
    {
        private readonly FilamentoService _filamentoService = filamentoService;
        private readonly Logger<FilamentosController> _logger = logger;

        [HttpGet("inventarioFilamentos", Name = "inventarioFilamentos")]
        public ActionResult<List<InventarioFilamentosDTO>> GetInventarioFilamentos()
        {
            try
            {
                List<InventarioFilamentosDTO> InventarioFilamentos = new List<InventarioFilamentosDTO>();
                InventarioFilamentos = _filamentoService.obtenerInventarioFilamentos();
                if (InventarioFilamentos.IsNullOrEmpty()) return BadRequest("Filamentos no encontrados");
                return Ok(InventarioFilamentos);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return BadRequest("Algo salió mal...");
            }
        }
    }
}
