using Marfrig.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Marfrig.Infra.Data.Configuration
{
    internal abstract class DomainEntityConfiguration<T> 
        : EntityTypeConfiguration<T> where T: DomainEntity
    {
        public DomainEntityConfiguration()
        {
            HasKey(prop => prop.Id);
        }
    }
}
