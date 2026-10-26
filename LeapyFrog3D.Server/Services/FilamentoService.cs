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

        public List<FilamentosDto> obtenerFilamentos()
        {
            List<FilamentoDto> filamentosDto = new List<FilamentoDto> {
                new FilamentoDto(1, "FIL001", "PLA Blue", "Azul", "PLA", "Generic"),
                new FilamentoDto(2, "FIL002", "PETG White", "Blanco", "PETG", "Generic")
            };
            return new List<FilamentosDto> { new FilamentosDto(filamentosDto) };
        }
    }
}
