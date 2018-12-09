using Marfrig.Domain.Entities;
using Marfrig.Infra.Data.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Marfrig.Infra.Data.DbContexts
{
    internal class MarfrigDbContext : DbContext
    {
        public MarfrigDbContext()
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Pecuarista> Pecuaristas { get; set; }
        public virtual DbSet<Animal> Animais { get; set; }
        public virtual DbSet<CompraGado> ComprasGado { get; set; }
        public virtual DbSet<CompraGadoItem> ComprasGadoItem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            RemoverConvencoes(modelBuilder);
            ConfigurarTiposPadroes(modelBuilder);
            AdicionarConfiguracoesEntidades(modelBuilder);
        }

        private void RemoverConvencoes(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        private void ConfigurarTiposPadroes(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100)
                                 .HasColumnType("varchar"));

            modelBuilder.Properties<decimal>()
                .Configure(p => p.HasColumnType("decimal")
                                 .HasPrecision(18, 2));
        }

        private void AdicionarConfiguracoesEntidades(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnimalConfiguration());
            modelBuilder.Configurations.Add(new PecuaristaConfiguration());
            modelBuilder.Configurations.Add(new CompraGadoConfiguration());
            modelBuilder.Configurations.Add(new CompraGadoItemConfiguration());
        }
    }
}
