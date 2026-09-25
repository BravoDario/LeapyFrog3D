# Guía para implementar el modelo en SQL Server

Este proyecto ya define estas entidades principales:

- `Filamento`
- `Marca`
- `Material`

Actualmente el modelo está pensado como un dominio simple para un inventario de filamentos para impresión 3D.

## 1) Modelo conceptual

### Marca
- `IdMarca` (PK)
- `Nombre`
- `Activo`

### Material
- `IdMaterial` (PK)
- `Nombre`
- `Activo`

### Filamento
- `IdFilamento` (PK)
- `Codigo`
- `Nombre`
- `Color`
- `Activo`
- `IdMarca` (FK -> Marca)
- `IdMaterial` (FK -> Material)

## 2) Recomendación de estructura en SQL Server

```sql
CREATE TABLE Marcas (
    IdMarca INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE Materiales (
    IdMaterial INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE Filamentos (
    IdFilamento INT IDENTITY(1,1) PRIMARY KEY,
    Codigo NVARCHAR(50) NOT NULL UNIQUE,
    Nombre NVARCHAR(150) NOT NULL,
    Color NVARCHAR(50) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    IdMarca INT NOT NULL,
    IdMaterial INT NOT NULL,

    CONSTRAINT FK_Filamentos_Marcas FOREIGN KEY (IdMarca)
        REFERENCES Marcas(IdMarca),

    CONSTRAINT FK_Filamentos_Materiales FOREIGN KEY (IdMaterial)
        REFERENCES Materiales(IdMaterial)
);
```

## 3) Relación entre entidades

- Una `Marca` puede tener muchos `Filamento`.
- Un `Material` puede tener muchos `Filamento`.
- Un `Filamento` pertenece a una sola `Marca`.
- Un `Filamento` pertenece a un solo `Material`.

Esto es una relación de 1:N en ambos casos.

## 4) Datos iniciales sugeridos

```sql
INSERT INTO Marcas (Nombre, Activo) VALUES
('Bambu Lab', 1),
('eSUN', 1),
('Prusament', 1),
('Polymaker', 1);

INSERT INTO Materiales (Nombre, Activo) VALUES
('PLA', 1),
('PLA+', 1),
('PETG', 1),
('ABS', 1),
('TPU', 1),
('PLA Silk', 1);

INSERT INTO Filamentos (Codigo, Nombre, Color, Activo, IdMarca, IdMaterial) VALUES
('PLA-BBL-001', 'PLA Basic', 'Blanco', 1, 1, 1),
('PLA-ESUN-001', 'PLA+', 'Negro', 1, 2, 2),
('PETG-PRU-001', 'Prusament PETG', 'Naranja', 1, 3, 3),
('ABS-ESUN-001', 'ABS+', 'Gris', 1, 2, 4),
('TPU-BBL-001', 'TPU 95A HF', 'Azul', 1, 1, 5),
('PLA-POLY-001', 'PolyTerra PLA', 'Verde', 1, 4, 1),
('PETG-BBL-001', 'PETG HF', 'Transparente', 1, 1, 3),
('PLA-SILK-001', 'PLA Silk', 'Dorado', 1, 2, 6);
```

## 5) Cómo encaja con ASP.NET Core

Para usar SQL Server con EF Core, lo normal es crear un contexto como este:

```csharp
public class AppDbContext : DbContext
{
    public DbSet<Marca> Marcas { get; set; }
    public DbSet<Material> Materiales { get; set; }
    public DbSet<Filamento> Filamentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost;Database=LeapyFrog3D;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
```

Y luego mapear las relaciones con EF Core:

```csharp
modelBuilder.Entity<Filamento>()
    .HasOne(f => f.Marca)
    .WithMany()
    .HasForeignKey(f => f.IdMarca);

modelBuilder.Entity<Filamento>()
    .HasOne(f => f.Material)
    .WithMany()
    .HasForeignKey(f => f.IdMaterial);
```

## 6) Paquetes recomendados para .NET

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

## 7) Migración recomendada

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## 8) Recomendación práctica

Para este proyecto, el modelo más limpio es:

- `Marcas` como catálogo de proveedores o fabricantes.
- `Materiales` como catálogo de tipos de filamento.
- `Filamentos` como tabla principal del inventario.

Esto permite crecer después con más campos como:

- stock actual
- precio
- peso por rollo
- fecha de entrada
- ubicación en almacén
- proveedor
- color HexCode

## 9) Observación importante

Tu código actual usa DTOs para devolver una lista plana de filamentos con `material` y `marca` como texto, y no usa todavía una base de datos. Para SQL Server, lo más correcto sería migrar ese DTO a entidades reales con navegación o a una vista/consulta que traiga marca y material por FK.

## 10) Resumen

El diseño mínimo adecuado para SQL Server es:

- 3 tablas
- 2 relaciones 1:N
- claves primarias enteras con `IDENTITY`
- `Codigo` único en `Filamentos`
- `Activo` para habilitar/deshabilitar registros sin borrar datos

Si quieres, el siguiente paso puede ser que te prepare directamente:
1. el `DbContext` para SQL Server,
2. las entidades EF Core,
3. y la migración inicial lista para pegar en el proyecto.
