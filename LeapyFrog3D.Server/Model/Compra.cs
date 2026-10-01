namespace LeapyFrog3D.Server.Model
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Fecha { get; set; } = string.Empty;
        public List<DetalleCompra> DetallesCompra { get; set; } = new List<DetalleCompra>();
    }
}
