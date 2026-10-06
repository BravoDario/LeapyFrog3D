using LeapyFrog3D.Server.DTOs;
using LeapyFrog3D.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeapyFrog3D.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialesController : ControllerBase
    {
        private readonly MaterialService _materialService;
        private readonly ILogger<MaterialesController> _logger;

        public MaterialesController(MaterialService materialService, ILogger<MaterialesController> logger)
        {
            _materialService = materialService;
            _logger = logger;
        }

        [HttpGet(Name = "obtenerMateriales")]
        public ActionResult<List<MaterialDto>> obtenerMateriales()
        {
            try
            {
                return Ok(_materialService.obtenerMateriales());
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Error al obtener los materiales");
                return BadRequest("Error en el servidor");
            }
        }

        [HttpGet("{idMaterial:int}", Name = "obtenerMaterialPorId")]
        public ActionResult<MaterialDto> obtenerMaterialPorId(int idMaterial)
        {
            try
            {
                MaterialDto? material = _materialService.obtenerMaterialPorId(idMaterial);
                return material == null ? NotFound("Material no encontrado") : Ok(material);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Error al obtener el material");
                return BadRequest("Error en el servidor");
            }
        }

        [HttpPost(Name = "crearMaterial")]
        public ActionResult crearMaterial(CrearMaterialDto crearMaterialDto)
        {
            try
            {
                bool isMaterialCreado = _materialService.crearMaterial(crearMaterialDto);
                return isMaterialCreado ? Ok(isMaterialCreado) : BadRequest("No se pudo crear el material");
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Error al crear el material");
                return BadRequest("Error en el servidor");
            }
        }

        [HttpPut(Name = "actualizarMaterial")]
        public ActionResult actualizarMaterial(ActualizarMaterialDto actualizarMaterialDto)
        {
            try
            {
                bool isMaterialActualizado = _materialService.actualizarMaterial(actualizarMaterialDto);
                return isMaterialActualizado ? Ok(isMaterialActualizado) : BadRequest("No se pudo actualizar el material");
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Error al actualizar el material");
                return BadRequest("Error en el servidor");
            }
        }

        [HttpDelete("{idMaterial:int}", Name = "eliminarMaterial")]
        public ActionResult eliminarMaterial(int idMaterial)
        {
            try
            {
                bool isMaterialEliminado = _materialService.eliminarMaterial(idMaterial);
                return isMaterialEliminado ? Ok(isMaterialEliminado) : BadRequest("No se pudo eliminar el material");
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Error al eliminar el material");
                return BadRequest("Error en el servidor");
            }
        }
    }
}
