using Marfrig.Domain.Entities;
using Marfrig.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Marfrig.Domain.Interfaces.Repositories
{
    public interface ICompraGadoRepository
    {
        Task Inserir(CompraGado compraGado);
        Task Atualizar(CompraGado compraGado);
        Task Excluir(int id);
        Task<CompraGado> BuscarPorId(int id);
        Task<PagingResult<CompraGado>> Buscar(FilterOptions options, int id, int pecuaristaId, DateTime dataEntregaInicio, DateTime dataEntregaFim);
    }
}
