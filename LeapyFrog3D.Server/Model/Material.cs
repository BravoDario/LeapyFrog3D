namespace LeapyFrog3D.Server.Model
{
    public class Material(int idMaterial, string nombre, bool activo)
    {
        public int IdMaterial { get; set; } = idMaterial;
        public string Nombre { get; set; } = nombre;
        public bool Activo { get; set; } = activo;
    }
}
