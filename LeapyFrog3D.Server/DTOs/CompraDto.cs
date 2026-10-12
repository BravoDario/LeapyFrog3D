namespace LeapyFrog3D.Server.DTOs
{
    public record AccesorioCompra(string Nombre, double Cantidad, int Unidad, int Piezas);
    public record FilamentoCompra(int IdMarca, int IdMaterial, String Color, double Costo, double Peso, int IdUnidad, int Piezas);
    public record CompraDto(List<FilamentoCompra> FilamentosComprados, List<AccesorioCompra> AccesoriosComprados);
}
