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
            bool tieneDetalles = compraDto?.DetallesCompra != null && compraDto.DetallesCompra.Count > 0;
            if (compraDto == null || string.IsNullOrWhiteSpace(compraDto.Fecha) || !tieneDetalles) return false;

            Compra compra = toCompra(compraDto);
            return _compraRepository.guardarCompra(compra);
        }

        private Compra toCompra(CompraDto compraDto)
        {
            return new Compra
            {
                IdCompra = compraDto.IdCompra,
                Fecha = compraDto.Fecha,
                DetallesCompra = toLstDetallesCompra(compraDto.DetallesCompra)
            };
        }

        private List<Model.DetalleCompra> toLstDetallesCompra(List<DTOs.DetalleCompra> detallesCompra)
        {
            List<Model.DetalleCompra> lstDetallesCompra = new List<Model.DetalleCompra>();
            foreach (DTOs.DetalleCompra detalle in detallesCompra)
            {
                lstDetallesCompra.Add(new Model.DetalleCompra
                {
                    IdFilamento = detalle.Filamento?.IdFilamento ?? 0,
                    Costo = detalle.Costo,
                    Peso = detalle.Peso
                });
            }
            return lstDetallesCompra;
        }
    }
}
