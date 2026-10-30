using LeapyFrog3D.Server.DTOs;
using LeapyFrog3D.Server.Model;
using LeapyFrog3D.Server.Repositorys;

namespace LeapyFrog3D.Server.Services
{
    public class UnidadService
    {
        private readonly UnidadRepository _unidadRepository;

        public UnidadService(UnidadRepository unidadRepository)
        {
            _unidadRepository = unidadRepository;
        }

        public List<UnidadDto> obtenerUnidades()
        {
            return _unidadRepository.obtenerUnidades()
                .Select(toUnidadDto)
                .ToList();
        }

        private UnidadDto toUnidadDto(Unidad unidad)
        {
            return new UnidadDto(unidad.IdUnidad, unidad.Nombre);
        }
    }
}
