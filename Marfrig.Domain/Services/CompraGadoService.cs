﻿using Marfrig.Domain.Entities;
using Marfrig.Domain.Exceptions;
using Marfrig.Domain.Interfaces.Repositories;
using Marfrig.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Marfrig.Domain.Services
{
    public class CompraGadoService : ICompraGadoService
    {
        private readonly ICompraGadoRepository compraGadoRepository;
  
        public CompraGadoService(ICompraGadoRepository compraGadoRepository, IAnimalRepository animalRepository)
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

        public async Task<int> AtualizarCompraDeGado(CompraGado compraGado)
        {
            if (!compraGado.PodeSalvar())
                throw new EntityValidationException(compraGado.Validacoes);

            await compraGadoRepository.Atualizar(compraGado);

            return compraGado.Id;
        }

        public async Task<bool> Excluir(CompraGado compraGado)
        {
            if (compraGado.Impressa)
                return false;

            await compraGadoRepository.Excluir(compraGado.Id);
            return true;
        }
    }
}
