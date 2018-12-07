using Marfrig.Application.DTOs.Pecuaristas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marfrig.Application.Interfaces
{
    public interface IPecuaristaAppService
    {
        Task<IEnumerable<PecuaristaDTO>> ObterPecuaristas();
    }
}
