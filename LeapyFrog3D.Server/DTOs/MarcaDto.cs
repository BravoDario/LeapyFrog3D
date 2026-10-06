namespace LeapyFrog3D.Server.DTOs
{
    public record MarcaDto(int IdMarca, string Nombre, bool Activo);
    public record CrearMarcaDto(string Nombre);
    public record ActualizarMarcaDto(int IdMarca, string Nombre);
}
