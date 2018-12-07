using AutoMapper;
using Marfrig.Application.DTOs.ComprasGado;
using Marfrig.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marfrig.Application.Mappings
{
    public class DTOToDomainProfile : Profile
    {
        public DTOToDomainProfile()
        {
            CreateMap<CompraGadoInputDTO, CompraGado>();
            CreateMap<CompraGadoItemInputDTO, CompraGadoItem>();
        }
    }
}
