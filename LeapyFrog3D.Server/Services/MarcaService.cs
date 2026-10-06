using LeapyFrog3D.Server.DTOs;
using LeapyFrog3D.Server.Model;
using LeapyFrog3D.Server.Repositorys;

namespace LeapyFrog3D.Server.Services
{
    public class MarcaService
    {
        private readonly MarcaRepository _marcaRepository;

        public MarcaService(MarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public List<MarcaDto> obtenerMarcas()
        {
            return _marcaRepository.obtenerMarcasActivas()
                .Select(toMarcaDto)
                .ToList();
        }

        public MarcaDto? obtenerMarcaPorId(int idMarca)
        {
            if (idMarca <= 0) return null;

            Marca? marca = _marcaRepository.obtenerMarcaPorId(idMarca);
            return marca == null ? null : toMarcaDto(marca);
        }

        public bool crearMarca(CrearMarcaDto crearMarcaDto)
        {
            if (crearMarcaDto == null || string.IsNullOrWhiteSpace(crearMarcaDto.Nombre)) return false;

            Marca marca = new Marca(0, crearMarcaDto.Nombre.Trim(), true);
            return _marcaRepository.insertarMarca(marca);
        }

        public bool actualizarMarca(ActualizarMarcaDto actualizarMarcaDto)
        {
            if (actualizarMarcaDto == null) return false;

            bool datosInvalidos = actualizarMarcaDto.IdMarca <= 0
                || string.IsNullOrWhiteSpace(actualizarMarcaDto.Nombre);
            if (datosInvalidos) return false;

            Marca? marca = _marcaRepository.obtenerMarcaPorId(actualizarMarcaDto.IdMarca);
            if (marca == null) return false;

            marca.Nombre = actualizarMarcaDto.Nombre.Trim();
            return _marcaRepository.actualizarMarca(marca);
        }

        public bool eliminarMarca(int idMarca)
        {
            if (idMarca <= 0) return false;
            return _marcaRepository.desactivarMarca(idMarca);
        }

        private MarcaDto toMarcaDto(Marca marca)
        {
            return new MarcaDto(marca.IdMarca, marca.Nombre, marca.Activo);
        }
    }
}
