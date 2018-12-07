using Marfrig.Domain.Entities;
using System.Threading.Tasks;

namespace Marfrig.Domain.Interfaces.Services
{
    public interface ICompraGadoService
    {
        Task<int> CriarNovaCompraDeGado(CompraGado compraGado);
    }
}
