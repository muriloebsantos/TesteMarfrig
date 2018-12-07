using Marfrig.Domain.Entities;

namespace Marfrig.Infra.Data.Configuration
{
    internal class CompraGadoItemConfiguration  : DomainEntityConfiguration<CompraGadoItem>
    {
        public CompraGadoItemConfiguration()
        {
            HasRequired(r => r.Animal).WithMany().HasForeignKey(f => f.AnimalId);
            HasRequired(r => r.CompraGado).WithMany(n => n.CompraGadoItens).HasForeignKey(f => f.CompraGadoId);
        }
    }
}
