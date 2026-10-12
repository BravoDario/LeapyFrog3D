namespace LeapyFrog3D.Server.Model
{
    public class Filamento
    {
        public int IdFilamento { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public double Cantidad { get; set; }
        public int IdMarca { get; set; }
        public int IdMaterial { get; set; }
        public int IdDetalleCompra { get; set; }
        public Marca? Marca { get; set; }
        public Material? Material { get; set; }
        public DetalleCompra? DetalleCompra { get; set; }
    }
}
