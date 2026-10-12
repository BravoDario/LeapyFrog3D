namespace LeapyFrog3D.Server.Model
{
    public class DetalleCompra
    {
        public int IdDetalleCompra { get; set; }
        public int IdCompra { get; set; }
        public int Piezas {  get; set; }
        public double Costo { get; set; }
        public double Cantidad { get; set; }
        public int IdUnidad { get; set; }
        public Compra? Compra { get; set; }
        public Unidad? Unidad { get; set; }
    }
}
