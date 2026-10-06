using LeapyFrog3D.Server.Data;
using LeapyFrog3D.Server.Model;

namespace LeapyFrog3D.Server.Repositorys
{
    public class MaterialRepository
    {
        private readonly AppDbContext _dbContext;

        public MaterialRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Material> obtenerMaterialesActivos()
        {
            return _dbContext.Materiales
                .Where(material => material.Activo)
                .ToList();
        }

        public Material? obtenerMaterialPorId(int idMaterial)
        {
            return _dbContext.Materiales.FirstOrDefault(material => material.IdMaterial == idMaterial);
        }

        public bool insertarMaterial(Material material)
        {
            _dbContext.Materiales.Add(material);
            return _dbContext.SaveChanges() > 0;
        }

        public bool actualizarMaterial(Material material)
        {
            _dbContext.Materiales.Update(material);
            return _dbContext.SaveChanges() > 0;
        }

        public bool desactivarMaterial(int idMaterial)
        {
            Material? material = obtenerMaterialPorId(idMaterial);
            if (material == null) return false;

            material.Activo = false;
            _dbContext.Materiales.Update(material);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
