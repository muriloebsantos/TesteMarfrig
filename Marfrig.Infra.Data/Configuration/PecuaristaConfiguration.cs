using Marfrig.Domain.Entities;

namespace Marfrig.Infra.Data.Configuration
{
    internal class PecuaristaConfiguration : DomainEntityConfiguration<Pecuarista>
    {
        public PecuaristaConfiguration()
        {
            Property(p => p.Nome).IsRequired();
        }
    }
}
