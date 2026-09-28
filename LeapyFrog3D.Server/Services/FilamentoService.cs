using LeapyFrog3D.Server.DTOs;

namespace LeapyFrog3D.Server.Services
{
    public class FilamentoService
    {
        public List<InventarioFilamentosDTO> obtenerInventarioFilamentos()
        {
            List<InventarioFilamentosDTO> inventarioFilamentos = new List<InventarioFilamentosDTO> {
                new InventarioFilamentosDTO("", "", 1, 2)
            };
            return inventarioFilamentos;
        }
    }
}
