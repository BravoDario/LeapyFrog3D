using LeapyFrog3D.Server.DTOs;
using LeapyFrog3D.Server.Model;
using LeapyFrog3D.Server.Repositorys;

namespace LeapyFrog3D.Server.Services
{
    public class MaterialService
    {
        private readonly MaterialRepository _materialRepository;

        public MaterialService(MaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public List<MaterialDto> obtenerMateriales()
        {
            return _materialRepository.obtenerMaterialesActivos()
                .Select(toMaterialDto)
                .ToList();
        }

        public MaterialDto? obtenerMaterialPorId(int idMaterial)
        {
            if (idMaterial <= 0) return null;

            Material? material = _materialRepository.obtenerMaterialPorId(idMaterial);
            return material == null ? null : toMaterialDto(material);
        }

        public bool crearMaterial(CrearMaterialDto crearMaterialDto)
        {
            if (crearMaterialDto == null || string.IsNullOrWhiteSpace(crearMaterialDto.Nombre)) return false;

            Material material = new Material(0, crearMaterialDto.Nombre.Trim(), true);
            return _materialRepository.insertarMaterial(material);
        }

        public bool actualizarMaterial(ActualizarMaterialDto actualizarMaterialDto)
        {
            if (actualizarMaterialDto == null) return false;

            bool datosInvalidos = actualizarMaterialDto.IdMaterial <= 0
                || string.IsNullOrWhiteSpace(actualizarMaterialDto.Nombre);
            if (datosInvalidos) return false;

            Material? material = _materialRepository.obtenerMaterialPorId(actualizarMaterialDto.IdMaterial);
            if (material == null) return false;

            material.Nombre = actualizarMaterialDto.Nombre.Trim();
            return _materialRepository.actualizarMaterial(material);
        }

        public bool eliminarMaterial(int idMaterial)
        {
            if (idMaterial <= 0) return false;
            return _materialRepository.desactivarMaterial(idMaterial);
        }

        private MaterialDto toMaterialDto(Material material)
        {
            return new MaterialDto(material.IdMaterial, material.Nombre, material.Activo);
        }
    }
}
