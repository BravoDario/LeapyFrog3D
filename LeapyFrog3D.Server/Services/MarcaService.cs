using LeapyFrog3D.Server.Model;
using LeapyFrog3D.Server.Repositorys;
using Microsoft.IdentityModel.Tokens;

namespace LeapyFrog3D.Server.Services
{
    public class MarcaService
    {
        private readonly MarcaRepository marcaRepository;
        public bool guardarMarca(Marca marca)
        {
            if (marca.Equals(null) || marca.Nombre.IsNullOrEmpty() || !marca.Activo) return false;

            if (marca.IdMarca != 0) marcaRepository.actualizarMarca(marca);
            else marcaRepository.actualizarMarca(marca);

            return true;
        }

    }
}
