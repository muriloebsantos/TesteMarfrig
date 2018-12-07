using Marfrig.Domain.Entities;

namespace Marfrig.Infra.Data.Configuration
{
    internal class AnimalConfiguration: DomainEntityConfiguration<Animal>
    {
        public AnimalConfiguration()
        {
            Property(p => p.Descricao).IsRequired();
        }
    }
}
