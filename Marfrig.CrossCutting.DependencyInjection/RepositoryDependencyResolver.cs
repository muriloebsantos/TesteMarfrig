using Marfrig.Domain.Interfaces.Repositories;
using Marfrig.Infra.Data.Repositories;
using SimpleInjector;

namespace Marfrig.CrossCutting.DependencyInjection
{
    internal class RepositoryDependencyResolver
    {
        public static void Resolve(Container container)
        {
            container.Register<IPecuaristaRepository, PecuaristaRepository>();
            container.Register<IAnimalRepository, AnimalRepository>();
            container.Register<ICompraGadoRepository, CompraGadoRepository>();
        }
    }
}
