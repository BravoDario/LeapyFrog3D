namespace LeapyFrog3D.Server.Model
{
    public class Accesorio
    {
        public int IdAccesorio { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public double Cantidad { get; set; }
        public int IdDetalleCompra {  get; set; }
        public DetalleCompra? DetalleCompra { get; set; }
    }
}
