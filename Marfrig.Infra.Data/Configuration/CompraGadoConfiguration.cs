using Marfrig.Domain.Entities;

namespace Marfrig.Infra.Data.Configuration
{
    internal class CompraGadoConfiguration : DomainEntityConfiguration<CompraGado>
    {
        public CompraGadoConfiguration()
        {
            HasRequired(r => r.Pecuarista).WithMany().HasForeignKey(f => f.PecuaristaId);
        }
    }
}
