using Marfrig.Application.DTOs.ComprasGado;
using System.Threading.Tasks;

namespace Marfrig.Application.Interfaces
{
    public interface ICompraGadoAppService
    {
        Task<int> CriarNovaCompraDeGado(CompraGadoInputDTO compraGado);
    }
}
