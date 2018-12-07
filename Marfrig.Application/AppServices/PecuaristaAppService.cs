using Marfrig.Application.DTOs.Pecuaristas;
using Marfrig.Application.Interfaces;
using Marfrig.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace Marfrig.Application.AppServices
{
    public class PecuaristaAppService : IPecuaristaAppService
    {
        private readonly IPecuaristaRepository pecuaristaRepository;

        public PecuaristaAppService(IPecuaristaRepository pecuaristaRepository)
        {
            this.pecuaristaRepository = pecuaristaRepository;
        }

        public async Task<IEnumerable<PecuaristaDTO>> ObterPecuaristas()
        {
            var pecuaristas = await pecuaristaRepository.ObterPecuaristas();
            var pecuaristasDTO = Mapper.Map<IEnumerable<PecuaristaDTO>>(pecuaristas);
            return pecuaristasDTO;
        }
    }
}
