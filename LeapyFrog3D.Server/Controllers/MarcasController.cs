using LeapyFrog3D.Server.DTOs;
using LeapyFrog3D.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeapyFrog3D.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcasController : ControllerBase
    {
        private readonly MarcaService _marcaService;
        private readonly ILogger<MarcasController> _logger;

        public MarcasController(MarcaService marcaService, ILogger<MarcasController> logger)
        {
            _marcaService = marcaService;
            _logger = logger;
        }

        [HttpGet(Name = "obtenerMarcas")]
        public ActionResult<List<MarcaDto>> obtenerMarcas()
        {
            try
            {
                return Ok(_marcaService.obtenerMarcas());
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Error al obtener las marcas");
                return BadRequest("Error en el servidor");
            }
        }

        [HttpGet("{idMarca:int}", Name = "obtenerMarcaPorId")]
        public ActionResult<MarcaDto> obtenerMarcaPorId(int idMarca)
        {
            try
            {
                MarcaDto? marca = _marcaService.obtenerMarcaPorId(idMarca);
                return marca == null ? NotFound("Marca no encontrada") : Ok(marca);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Error al obtener la marca");
                return BadRequest("Error en el servidor");
            }
        }

        [HttpPost(Name = "crearMarca")]
        public ActionResult crearMarca(CrearMarcaDto crearMarcaDto)
        {
            try
            {
                bool isMarcaCreada = _marcaService.crearMarca(crearMarcaDto);
                return isMarcaCreada ? Ok(isMarcaCreada) : BadRequest("No se pudo crear la marca");
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Error al crear la marca");
                return BadRequest("Error en el servidor");
            }
        }

        [HttpPut(Name = "actualizarMarca")]
        public ActionResult actualizarMarca(ActualizarMarcaDto actualizarMarcaDto)
        {
            try
            {
                bool isMarcaActualizada = _marcaService.actualizarMarca(actualizarMarcaDto);
                return isMarcaActualizada ? Ok(isMarcaActualizada) : BadRequest("No se pudo actualizar la marca");
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Error al actualizar la marca");
                return BadRequest("Error en el servidor");
            }
        }

        [HttpDelete("{idMarca:int}", Name = "eliminarMarca")]
        public ActionResult eliminarMarca(int idMarca)
        {
            try
            {
                bool isMarcaEliminada = _marcaService.eliminarMarca(idMarca);
                return isMarcaEliminada ? Ok(isMarcaEliminada) : BadRequest("No se pudo eliminar la marca");
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Error al eliminar la marca");
                return BadRequest("Error en el servidor");
            }
        }
    }
}
