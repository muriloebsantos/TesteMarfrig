using System;
using System.Collections.Generic;
using System.Linq;

namespace Marfrig.Domain.Models.ReadModels
{
    public class CompraGadoRelatorio
    {
        public int Id { get; set; }
        public DateTime DataEntrega { get; set; }
        public string Pecuarista { get; set; }
        public decimal Total => Itens?.Sum(i => i.ValorTotal) ?? 0;
        public IEnumerable<CompraGadoItemRelatorio> Itens { get; set; }
    }
}
