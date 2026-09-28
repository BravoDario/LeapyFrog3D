namespace LeapyFrog3D.Server.Model
{
    public class Compra
    {
        private int IdCompra { get; set; }
        private string Codigo { get; set; } = string.Empty;
        private string Fecha { get; set; } = string.Empty;
        public List<DetalleCompra>? detallesCompra;
    }
}
