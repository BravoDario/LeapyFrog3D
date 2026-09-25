using LeapyFrog3D.Server.DTOs;
using LeapyFrog3D.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeapyFrog3D.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilamentosController : ControllerBase
    {
        private readonly FilamentoService _filamentoService;

        public FilamentosController(FilamentoService filamentoService)
        {
            _filamentoService = filamentoService;
        }

        [HttpGet("inventarioFilamentos", Name = "inventarioFilamentos")]
        public ActionResult<FilamentosDto> GetInventarioFilamentos()
        {
            return Ok(new FilamentosDto(_filamentoService.obtenerInventarioFilamentos()));
        }
    }
}
