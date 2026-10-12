using LeapyFrog3D.Server.Data;
using LeapyFrog3D.Server.Model;

namespace LeapyFrog3D.Server.Repositorys
{
    public class FilamentoRepository(AppDbContext AppDbContext)
    {
        private readonly AppDbContext _dbContext = AppDbContext;

        public bool GuardarFilamento(Filamento filamento)
        {
            _dbContext.Filamentos.Add(filamento);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
