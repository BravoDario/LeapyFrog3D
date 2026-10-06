namespace LeapyFrog3D.Server.DTOs
{
    public record MaterialDto(int IdMaterial, string Nombre, bool Activo);
    public record CrearMaterialDto(string Nombre);
    public record ActualizarMaterialDto(int IdMaterial, string Nombre);
}
