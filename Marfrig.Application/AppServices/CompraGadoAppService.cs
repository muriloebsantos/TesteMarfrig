using AutoMapper;
using Marfrig.Application.DTO.ComprasGado;
using Marfrig.Application.DTOs;
using Marfrig.Application.DTOs.ComprasGado;
using Marfrig.Application.Exceptions;
using Marfrig.Application.Interfaces;
using Marfrig.Domain.Entities;
using Marfrig.Domain.Interfaces.Repositories;
using Marfrig.Domain.Interfaces.Services;
using Marfrig.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marfrig.Application.AppServices
{
    public class CompraGadoAppService : ICompraGadoAppService
    {
        private readonly ICompraGadoService compraGadoService;
        private readonly ICompraGadoRepository compraGadoRepository;
        private readonly IAnimalRepository animalRepository;
        private readonly IPecuaristaRepository pecuaristaRepository;

        public CompraGadoAppService(ICompraGadoService compraGadoService, 
                                    ICompraGadoRepository compraGadoRepository,
                                    IAnimalRepository animalRepository,
                                    IPecuaristaRepository pecuaristaRepository)
        {
            this.compraGadoService = compraGadoService;
            this.compraGadoRepository = compraGadoRepository;
            this.animalRepository = animalRepository;
            this.pecuaristaRepository = pecuaristaRepository;
        }

        private async Task ValidarCompraDeGado(CompraGado compraGado)
        {
            if (!await pecuaristaRepository.Existe(compraGado.PecuaristaId))
            {
                throw new NotFoundException($"Pecuarista com Id {compraGado.PecuaristaId} não existe");
            }

            foreach (var item in compraGado.CompraGadoItens)
            {
                var animal = await animalRepository.ObterAnimalPorId(item.AnimalId);

                if (animal == null)
                    throw new NotFoundException($"Animal com Id {item.AnimalId} não cadastrado");

                item.Preco = animal.Preco;
            }
        }

        public async Task<int> CriarNovaCompraDeGado(CompraGadoInputDTO compraGadoDTO)
        {
            var compraGado = Mapper.Map<CompraGado>(compraGadoDTO);
            await ValidarCompraDeGado(compraGado);
            var idCompra = await compraGadoService.CriarNovaCompraDeGado(compraGado);
            return idCompra;
        }

        public async Task<int> AtualizarCompraDeGado(CompraGadoInputDTO compraGadoDTO)
        {
            var compraGado = Mapper.Map<CompraGado>(compraGadoDTO);
            await ValidarCompraDeGado(compraGado);
            var idCompra = await compraGadoService.AtualizarCompraDeGado(compraGado);
            return idCompra;
        }

        public async Task<CompraGadoInputDTO> ObterPorId(int id)
        {
            var compraGado = await compraGadoRepository.BuscarPorId(id);
            var compraGadoDTO = Mapper.Map<CompraGadoInputDTO>(compraGado);
            return compraGadoDTO;
        }


        public async Task<PagedResultDTO<CompraGadoConsultaDTO>> Buscar(int paginaAtual, int tamanhoPagina, int id, int pecuaristaId, DateTime? dataEntregaInicial, DateTime? dataEntregaFinal)
        {
            var opcoesFiltro = new FilterOptions { CurrentPage = paginaAtual, PageSize = tamanhoPagina };
            var comprasGados = await compraGadoRepository.Buscar(opcoesFiltro, id, pecuaristaId, dataEntregaInicial, dataEntregaFinal);
            var comprasGadosDTO = Mapper.Map<PagedResultDTO<CompraGadoConsultaDTO>>(comprasGados);
            return comprasGadosDTO;
        }

        public async Task<bool> Excluir(int id)
        {
            var compraGado = await compraGadoRepository.BuscarPorId(id);

            if (compraGado == null)
                throw new NotFoundException("Compra de gado não encontrada");

            return await compraGadoService.Excluir(compraGado);
        }

        public async Task<CompraGadoRelatorioDTO> RelatorioCompra(int id)
        {
            var relatorioCompra = await compraGadoRepository.RelatorioCompra(id);
            var relatorioDTO = new CompraGadoRelatorioDTO()
            {
                Cabecalho = Mapper.Map<CompraGadoCabecalhoRelatorioDTO>(relatorioCompra),
                Itens = Mapper.Map<IEnumerable<CompraGadoItemRelatorioDTO>>(relatorioCompra.Itens)
            };

            var compraGado = await compraGadoRepository.BuscarPorId(id);
            compraGado.Impressa = true;
            await compraGadoService.AtualizarCompraDeGado(compraGado);

            return relatorioDTO;
        }
    }
}
