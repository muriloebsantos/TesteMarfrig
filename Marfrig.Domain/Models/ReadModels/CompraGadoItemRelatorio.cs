using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marfrig.Domain.Models.ReadModels
{
    public class CompraGadoItemRelatorio
    {
        public string Animal { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal ValorTotal => Quantidade * Preco;
    }
}
