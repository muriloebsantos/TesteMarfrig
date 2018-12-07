using AutoMapper;
using Marfrig.Application.DTOs.ComprasGado;
using Marfrig.Application.Interfaces;
using Marfrig.Domain.Entities;
using Marfrig.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Marfrig.Application.AppServices
{
    public class CompraGadoAppService : ICompraGadoAppService
    {
        private readonly ICompraGadoService compraGadoService;

        public CompraGadoAppService(ICompraGadoService compraGadoService)
        {
            this.compraGadoService = compraGadoService;       
        }

        public async Task<int> CriarNovaCompraDeGado(CompraGadoInputDTO compraGadoDTO)
        {
            var compraGado = Mapper.Map<CompraGado>(compraGadoDTO);
            var idCompra = await compraGadoService.CriarNovaCompraDeGado(compraGado);
            return idCompra;
        }
    }
}
