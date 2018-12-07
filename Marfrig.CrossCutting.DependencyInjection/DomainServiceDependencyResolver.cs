using Marfrig.Domain.Interfaces.Services;
using Marfrig.Domain.Services;
using SimpleInjector;

namespace Marfrig.CrossCutting.DependencyInjection
{
    internal class DomainServiceDependencyResolver
    {
        public static void Resolve(Container container)
        {
            container.Register<ICompraGadoService, CompraGadoService>();
        }
    }
}
