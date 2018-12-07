using AutoMapper;
using Marfrig.Application.DTOs.Animais;
using Marfrig.Application.Interfaces;
using Marfrig.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marfrig.Application.AppServices
{
    public class AnimalAppService : IAnimalAppService
    {
        private readonly IAnimalRepository animalRepository;

        public AnimalAppService(IAnimalRepository animalRepository)
        {
            this.animalRepository = animalRepository;
        }

        public async Task<IEnumerable<AnimalDTO>> ObterAnimais()
        {
            var animais = await animalRepository.ObterAnimais();
            var animaisDTO = Mapper.Map <IEnumerable<AnimalDTO>>(animais);
            return animaisDTO;
        }
    }
}
