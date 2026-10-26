using LeapyFrog3D.Server.DTOs;
using LeapyFrog3D.Server.Model;
using LeapyFrog3D.Server.Repositorys;

namespace LeapyFrog3D.Server.Services
{
    public class ComprasService
    {
        private readonly CompraRepository _compraRepository;

        public ComprasService(CompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }

        public bool guardarCompra(CompraDto compraDto)
        {
            if (compraDto == null) return false;

            bool tieneFilamentos = compraDto.FilamentosComprados != null && compraDto.FilamentosComprados.Count > 0;
            bool tieneAccesorios = compraDto.AccesoriosComprados != null && compraDto.AccesoriosComprados.Count > 0;

            if (!tieneFilamentos && !tieneAccesorios) return false;

            try
            {
                Compra compra = toCompra(compraDto);
                return _compraRepository.GuardarCompra(compra);
            }
            catch
            {
                return false;
            }
        }

        private Compra toCompra(CompraDto compraDto)
        {
            Compra compra = new Compra
            {
                Codigo = "COM-" + DateTime.Now.ToString("yyyyMMdd-HHmmss"),
                Fecha = DateTime.Now.ToString("yyyy-MM-dd"),
                DetallesCompra = new List<DetalleCompra>()
            };

            if (compraDto.FilamentosComprados != null)
            {
                foreach (FilamentoCompra fc in compraDto.FilamentosComprados)
                {
                    DetalleCompra detalle = new DetalleCompra
                    {
                        Piezas = fc.Piezas,
                        Costo = fc.Costo,
                        Cantidad = fc.Peso,
                        IdUnidad = fc.IdUnidad
                    };
                    compra.DetallesCompra.Add(detalle);

                    Filamento filamento = new Filamento
                    {
                        IdDetalleCompra = detalle.IdDetalleCompra,
                        Codigo = generarCodigoFilamento(),
                        Color = fc.Color,
                        Cantidad = fc.Peso,
                        IdMarca = fc.IdMarca,
                        IdMaterial = fc.IdMaterial
                    };
                    detalle.Filamento = filamento;
                }
            }

            return compra;
        }

        private string generarCodigoFilamento()
        {
            return "FIL-" + DateTime.Now.ToString("yyyyMMdd-HHmmss-") + new Random().Next(1000, 9999);
        }
    }
}
