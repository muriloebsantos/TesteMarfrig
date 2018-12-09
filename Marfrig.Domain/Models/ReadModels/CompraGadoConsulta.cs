using System;

namespace Marfrig.Domain.Models.ReadModels
{
    public class CompraGadoConsulta
    {
        public int Id { get; set; }
        public string Pecuarista { get; set; }
        public bool Impressa { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
