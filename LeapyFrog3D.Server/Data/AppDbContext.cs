using LeapyFrog3D.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace LeapyFrog3D.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Marca> Marcas => Set<Marca>();
        public DbSet<Material> Materiales => Set<Material>();
        public DbSet<Filamento> Filamentos => Set<Filamento>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.ToTable("Marcas");
                entity.HasKey(m => m.IdMarca);
                entity.Property(m => m.Nombre).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Materiales");
                entity.HasKey(m => m.IdMaterial);
                entity.Property(m => m.Nombre).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Filamento>(entity =>
            {
                entity.ToTable("Filamentos");
                entity.HasKey(f => f.IdFilamento);
                entity.Property(f => f.Codigo).IsRequired().HasMaxLength(50);
                entity.Property(f => f.Nombre).IsRequired().HasMaxLength(150);
                entity.Property(f => f.Color).IsRequired().HasMaxLength(50);

                entity.HasOne(f => f.Marca)
                    .WithMany()
                    .HasForeignKey(f => f.IdMarca)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(f => f.Material)
                    .WithMany()
                    .HasForeignKey(f => f.IdMaterial)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
