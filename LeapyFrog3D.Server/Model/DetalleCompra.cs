namespace LeapyFrog3D.Server.Model
{
    public class DetalleCompra
    {
        public int IdDetalleCompra { get; set; }
        public int IdCompra { get; set; }
        public int IdFilamento { get; set; }
        public double Costo { get; set; }
        public double Peso { get; set; }
        public Filamento? Filamento { get; set; }
    }
}
