using Marfrig.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marfrig.Domain.Interfaces.Repositories
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animal>> ObterAnimais();
        Task<Animal> ObterAnimalPorId(int id);
    }
}
