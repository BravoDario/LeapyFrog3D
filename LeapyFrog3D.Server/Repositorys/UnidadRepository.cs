using LeapyFrog3D.Server.Data;
using LeapyFrog3D.Server.Model;

namespace LeapyFrog3D.Server.Repositorys
{
    public class UnidadRepository
    {
        private readonly AppDbContext _dbContext;

        public UnidadRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Unidad> obtenerUnidades()
        {
            return _dbContext.Unidades.ToList();
        }
    }
}
