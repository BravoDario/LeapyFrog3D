namespace LeapyFrog3D.Server.DTOs
{
    public record InventarioFilamentosDTO(string Color, string Material, int Rollos, double Kilogramos);
    public record FilamentoDto(int idFilamento, string codigo, string nombre, string color, string material, string marca);

    public record FilamentosDto(List<FilamentoDto> filamentos);
}
