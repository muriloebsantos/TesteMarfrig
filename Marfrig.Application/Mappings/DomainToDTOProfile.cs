using AutoMapper;
using Marfrig.Application.DTOs.Animais;
using Marfrig.Application.DTOs.ComprasGado;
using Marfrig.Application.DTOs.Pecuaristas;
using Marfrig.Domain.Entities;

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
        }
    }
}
