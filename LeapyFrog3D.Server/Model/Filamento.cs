namespace LeapyFrog3D.Server.Model
{
    public class Filamento
    {
        public int IdFilamento { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public bool Activo { get; set; }

        public int IdMarca { get; set; }
        public int IdMaterial { get; set; }

        public Marca? Marca { get; set; }
        public Material? Material { get; set; }
    }
}
