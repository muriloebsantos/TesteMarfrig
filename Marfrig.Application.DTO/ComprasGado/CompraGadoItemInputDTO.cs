namespace Marfrig.Application.DTOs.ComprasGado
{
    public class CompraGadoItemInputDTO
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public int CompraGadoId { get; set; }
        public int AnimalId { get; set; }
    }
}
