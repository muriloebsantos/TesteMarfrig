using Marfrig.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marfrig.Domain.Interfaces.Repositories
{
    public interface IPecuaristaRepository
    {
        Task<IEnumerable<Pecuarista>> ObterPecuaristas();
        Task<bool> Existe(int id);
    }
}
