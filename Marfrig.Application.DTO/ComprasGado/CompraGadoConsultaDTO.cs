using System;

namespace Marfrig.Application.DTOs.ComprasGado
{
    public class CompraGadoConsultaDTO
    {
        public int Id { get; set; }
        public string Pecuarista { get; set; }
        public DateTime Data { get; set; }
        public bool Impressa { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
