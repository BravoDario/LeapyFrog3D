using LeapyFrog3D.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace LeapyFrog3D.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Marca> Marcas => Set<Marca>();
        public DbSet<Material> Materiales => Set<Material>();
        public DbSet<Filamento> Filamentos => Set<Filamento>();
        public DbSet<Compra> Compras => Set<Compra>();
        public DbSet<DetalleCompra> DetallesCompra => Set<DetalleCompra>();
        public DbSet<Unidad> Unidades => Set<Unidad>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.ToTable("Marcas");
                entity.HasKey(m => m.IdMarca);
                entity.Property(m => m.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(m => m.Activo).HasDefaultValue(true);
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Materiales");
                entity.HasKey(m => m.IdMaterial);
                entity.Property(m => m.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(m => m.Activo).HasDefaultValue(true);
            });

            modelBuilder.Entity<Filamento>(entity =>
            {
                entity.ToTable("Filamentos");
                entity.HasKey(f => f.IdFilamento);
                entity.Property(f => f.Codigo).IsRequired().HasMaxLength(50);
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

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.ToTable("Compras");
                entity.HasKey(c => c.IdCompra);
                entity.Property(c => c.Codigo).HasMaxLength(50);
                entity.Property(c => c.Fecha).IsRequired().HasMaxLength(50);

                entity.HasMany(c => c.DetallesCompra)
                    .WithOne(d => d.Compra)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<DetalleCompra>(entity =>
            {
                entity.ToTable("DetallesCompra");
                entity.HasKey(d => d.IdDetalleCompra);
                entity.Property(d => d.Piezas).IsRequired();
                entity.Property(d => d.Costo).IsRequired();
                entity.Property(d => d.Cantidad).IsRequired();
                entity.Property(d => d.IdUnidad).IsRequired();

                entity.HasOne(d => d.Filamento)
                    .WithOne(f => f.DetalleCompra)
                    .HasForeignKey<Filamento>(f => f.IdDetalleCompra)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Unidad)
                    .WithMany()
                    .HasForeignKey(d => d.IdUnidad)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Unidad>(entity =>
            {
                entity.ToTable("Unidades");
                entity.HasKey(u => u.IdUnidad);
                entity.Property(u => u.Nombre).IsRequired().HasMaxLength(100);
            });
        }
    }
}
