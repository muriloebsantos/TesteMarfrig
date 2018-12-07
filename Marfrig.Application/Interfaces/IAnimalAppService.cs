using Marfrig.Application.DTOs.Animais;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marfrig.Application.Interfaces
{
    public interface IAnimalAppService
    {
        Task<IEnumerable<AnimalDTO>> ObterAnimais();
    }
}
