namespace Marfrig.Domain.Entities
{
    public class CompraGadoItem : DomainEntity
    {
        public int Quantidade { get; set; }
        public int CompraGadoId { get; set; }
        public int AnimalId { get; set; }
        public  virtual CompraGado CompraGado { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
