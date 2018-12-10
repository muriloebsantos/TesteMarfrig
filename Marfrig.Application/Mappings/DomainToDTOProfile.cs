using AutoMapper;
using Marfrig.Application.DTO.ComprasGado;
using Marfrig.Application.DTOs;
using Marfrig.Application.DTOs.Animais;
using Marfrig.Application.DTOs.ComprasGado;
using Marfrig.Application.DTOs.Pecuaristas;
using Marfrig.Domain.Entities;
using Marfrig.Domain.Models;
using Marfrig.Domain.Models.ReadModels;

namespace Marfrig.Application.Mappings
{
    internal class DomainToDTOProfile : Profile
    {
        public DomainToDTOProfile()
        {
            CreateMap<Animal, AnimalDTO>();
            CreateMap<Pecuarista, PecuaristaDTO>();
            CreateMap<CompraGado, CompraGadoInputDTO>();
            CreateMap<CompraGadoItem, CompraGadoItemInputDTO>();
            CreateMap<PagedResult<CompraGadoConsulta>, PagedResultDTO<CompraGadoConsultaDTO>>();
            CreateMap<CompraGadoRelatorio, CompraGadoCabecalhoRelatorioDTO>();
            CreateMap<CompraGadoItemRelatorio, CompraGadoItemRelatorioDTO>();
        }
    }
}
