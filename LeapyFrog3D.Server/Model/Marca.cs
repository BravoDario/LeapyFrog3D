namespace LeapyFrog3D.Server.Model
{
    public class Marca(int idMarca, string nombre, bool activo)
    {
        public int IdMarca { get; set; } = idMarca;
        public string Nombre { get; set; } = nombre;
        public bool Activo { get; set; } = activo;
    }
}
