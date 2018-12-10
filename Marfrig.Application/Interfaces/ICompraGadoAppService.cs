using Marfrig.Application.DTO.ComprasGado;
using Marfrig.Application.DTOs;
using Marfrig.Application.DTOs.ComprasGado;
using System;
using System.Threading.Tasks;

namespace Marfrig.Application.Interfaces
{
    public interface ICompraGadoAppService
    {
        Task<int> CriarNovaCompraDeGado(CompraGadoInputDTO compraGado);
        Task<int> AtualizarCompraDeGado(CompraGadoInputDTO compraGado);
        Task<CompraGadoInputDTO> ObterPorId(int id);
        Task<bool> Excluir(int id);
        Task<PagedResultDTO<CompraGadoConsultaDTO>> Buscar(int paginaAtual, int tamanhoPagina, int id, int pecuaristaId, DateTime? dataEntregaInicial, DateTime? dataEntregaFinal);
        Task<CompraGadoRelatorioDTO> RelatorioCompra(int id);
    }
}
