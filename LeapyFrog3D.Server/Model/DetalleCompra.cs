namespace LeapyFrog3D.Server.Model
{
    public class DetalleCompra
    {
        private int IdDetalleCompra {  get; set; }
        private int IdCompra { get; set; }
        private int IdFilamento { get; set; }
        private double Precio {  get; set; }
        public Filamento? Filamento { get; set; }
    }
}
