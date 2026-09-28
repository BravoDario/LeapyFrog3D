using LeapyFrog3D.Server.Model;

namespace LeapyFrog3D.Server.DTOs
{
    public record DetalleCompra(Filamento Filamento, double Costo, double Peso);
    public record CompraDto(List<DetalleCompra> DetallesCompra, string Fecha, int idCompra);
}
