using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marfrig.Application.DTO.ComprasGado
{
    public class CompraGadoCabecalhoRelatorioDTO
    {
        public int Id { get; set; }
        public DateTime DataEntrega { get; set; }
        public string Pecuarista { get; set; }
        public decimal Total { get; set; }
    }
}
