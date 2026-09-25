using LeapyFrog3D.Server.DTOs;

namespace LeapyFrog3D.Server.Services
{
    public class FilamentoService
    {
        public List<FilamentoDto> obtenerInventarioFilamentos()
        {
            return new List<FilamentoDto>
            {
                new(1, "PLA-BBL-001", "PLA Basic", "Blanco", "PLA", "Bambu Lab"),
                new(2, "PLA-ESUN-001", "PLA+", "Negro", "PLA+", "eSUN"),
                new(3, "PETG-PRU-001", "Prusament PETG", "Naranja", "PETG", "Prusament"),
                new(4, "ABS-ESUN-001", "ABS+", "Gris", "ABS", "eSUN"),
                new(5, "TPU-BBL-001", "TPU 95A HF", "Azul", "TPU", "Bambu Lab"),
                new(6, "PLA-POLY-001", "PolyTerra PLA", "Verde", "PLA", "Polymaker"),
                new(7, "PETG-BBL-001", "PETG HF", "Transparente", "PETG", "Bambu Lab"),
                new(8, "PLA-SILK-001", "PLA Silk", "Dorado", "PLA Silk", "eSUN")
            };
        }
    }
}
