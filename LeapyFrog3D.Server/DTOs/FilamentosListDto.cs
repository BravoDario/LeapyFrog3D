namespace LeapyFrog3D.Server.DTOs
{
    public record FilamentoDto(int idFilamento, string codigo, string nombre, string color, string material, string marca);

    public record FilamentosDto(List<FilamentoDto> filamentos);
}
