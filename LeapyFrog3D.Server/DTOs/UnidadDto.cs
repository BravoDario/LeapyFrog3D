namespace LeapyFrog3D.Server.DTOs
{
    public record UnidadDto(int IdUnidad, string Nombre);
    public record CrearUnidadDto(string Nombre);
    public record ActualizarUnidadDto(int IdUnidad, string Nombre);
}
