using System.Collections.Generic;

namespace Marfrig.Application.DTO.ComprasGado
{
    public class CompraGadoRelatorioDTO
    {
        public CompraGadoCabecalhoRelatorioDTO Cabecalho { get; set; }
        public IEnumerable<CompraGadoItemRelatorioDTO> Itens { get; set; }
    }
}
