using LeapyFrog3D.Server.DTOs;
using LeapyFrog3D.Server.Model;
using LeapyFrog3D.Server.Repositorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LeapyFrog3D.Server.Services
{
    public class ComprasService(CompraRepository compraRepository, DbContext dbContext)
    {
        private readonly CompraRepository _compraRepository = compraRepository;
        private readonly DbContext _dbContext = dbContext;

        public async Task<bool> guardarCompra(CompraDto compraDto)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                if (compraDto == null || (compraDto.FilamentosComprados.IsNullOrEmpty() && compraDto.AccesoriosComprados.IsNullOrEmpty()))
                {
                    throw new Exception("Sin datos para guardar");
                }

                if (!compraDto.FilamentosComprados.IsNullOrEmpty()) guardarFilamentos(compraDto.FilamentosComprados);
                if (!compraDto.AccesoriosComprados.IsNullOrEmpty()) guardarAccesorios(compraDto.AccesoriosComprados);

                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("la compra no se pudo completar");
            }

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

        private bool guardarAccesorios()
        {

        }

        private bool guardarFilamentos(List<FilamentoCompra> filamentosCompra)
        {
            bool guardado = false;
            foreach (FilamentoCompra filamentoCompra in filamentosCompra)
            {
                DetalleCompra detalleCompra = new DetalleCompra();
                detalleCompra.Piezas= filamentoCompra.Piezas;
                detalleCompra.Costo = filamentoCompra.Costo;
                detalleCompra.Cantidad = filamentoCompra.Peso;
                detalleCompra.IdUnidad = filamentoCompra.IdUnidad;

                //GuardarDetalleCompra
                //detalleCompra = _dbContext.DetalleCompra.save(detalleCompra);

                Filamento filamento = new Filamento();
                filamento.IdDetalleCompra = detalleCompra.IdDetalleCompra;
                filamento.Codigo = generarCodigoFilamento();
                filamento.Color = filamentoCompra.Color;
                filamento.Cantidad = filamentoCompra.Peso;
                filamento.IdMarca = filamentoCompra.IdMarca;
                filamento.IdMaterial = filamentoCompra.IdMaterial;
                
            }

            return guardado;
        }

        private string generarCodigoCompra()
        {
            string codigo = "";

            return codigo;
        }

        private string generarCodigoAccesorio()
        {
            return "";
        }

        private string generarCodigoFilamento()
        {
            return "";
        }
    }
}
