using LeapyFrog3D.Server.Data;
using LeapyFrog3D.Server.Model;

namespace LeapyFrog3D.Server.Repositorys
{
    public class MarcaRepository
    {
        private readonly AppDbContext _dbContext;

        public MarcaRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Marca> obtenerMarcasActivas()
        {
            return _dbContext.Marcas
                .Where(marca => marca.Activo)
                .ToList();
        }

        public Marca? obtenerMarcaPorId(int idMarca)
        {
            return _dbContext.Marcas.FirstOrDefault(marca => marca.IdMarca == idMarca);
        }

        public bool insertarMarca(Marca marca)
        {
            _dbContext.Marcas.Add(marca);
            return _dbContext.SaveChanges() > 0;
        }

        public bool actualizarMarca(Marca marca)
        {
            _dbContext.Marcas.Update(marca);
            return _dbContext.SaveChanges() > 0;
        }

        public bool desactivarMarca(int idMarca)
        {
            Marca? marca = obtenerMarcaPorId(idMarca);
            if (marca == null) return false;

            marca.Activo = false;
            _dbContext.Marcas.Update(marca);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
