using System;
using System.Collections.Generic;

namespace Marfrig.Application.DTOs.ComprasGado
{
    public class CompraGadoInputDTO
    {
        public int Id { get; set; }
        public DateTime DataEntrega { get; set; }
        public int PecuaristaId { get; set; }
        public virtual ICollection<CompraGadoItemInputDTO> CompraGadoItens { get; set; }
    }
}
