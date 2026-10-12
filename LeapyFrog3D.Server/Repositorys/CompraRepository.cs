using LeapyFrog3D.Server.Data;
using LeapyFrog3D.Server.Model;

namespace LeapyFrog3D.Server.Repositorys
{
    public class CompraRepository(AppDbContext dbContext)
    {
        private readonly AppDbContext _dbContext = dbContext;

        public bool GuardarCompra(Compra compra)
        {
            _dbContext.Compras.Add(compra);
            int registrosAfectados = _dbContext.SaveChanges();
            return registrosAfectados > 0;
        }
    }
}
