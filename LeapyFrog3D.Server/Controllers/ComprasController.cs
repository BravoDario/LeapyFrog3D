using LeapyFrog3D.Server.DTOs;
using LeapyFrog3D.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeapyFrog3D.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComprasController : ControllerBase
    {
        private readonly ComprasService _comprasService;
        private readonly ILogger<ComprasController> _logger;

        public ComprasController(ComprasService comprasService, ILogger<ComprasController> logger)
        {
            _comprasService = comprasService;
            _logger = logger;
        }

        [HttpPost("guardarCompra", Name = "guardarCompra")]
        public ActionResult guardarCompra(CompraDto compraDto)
        {
            try
            {
                bool isCompraGuardada = _comprasService.guardarCompra(compraDto);
                return isCompraGuardada ? Ok(isCompraGuardada) : BadRequest("No se pudo guardar la compra");
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Error al guardar la compra");
                return BadRequest("Error en el servidor");
            }
        }
    }
}
