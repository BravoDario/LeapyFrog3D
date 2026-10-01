using LeapyFrog3D.Server.Data;
using LeapyFrog3D.Server.Model;

namespace LeapyFrog3D.Server.Repositorys
{
    public class CompraRepository
    {
        private readonly AppDbContext _dbContext;

        public CompraRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool guardarCompra(Compra compra)
        {
            _dbContext.Compras.Add(compra);
            int registrosAfectados = _dbContext.SaveChanges();
            return registrosAfectados > 0;
        }
    }
}
