using Marfrig.Domain.Entities;
using Marfrig.Domain.Exceptions;
using Marfrig.Domain.Interfaces.Repositories;
using Marfrig.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Marfrig.Domain.Services
{
    public class CompraGadoService : ICompraGadoService
    {
        public readonly ICompraGadoRepository compraGadoRepository;

        public CompraGadoService(ICompraGadoRepository compraGadoRepository)
        {
            this.compraGadoRepository = compraGadoRepository;
        }

        public async Task<int> CriarNovaCompraDeGado(CompraGado compraGado)
        {
            if (!compraGado.PodeSalvar())
                throw new EntityValidationException(compraGado.Validacoes);

            await compraGadoRepository.Inserir(compraGado);

            return compraGado.Id;
        }
    }
}
