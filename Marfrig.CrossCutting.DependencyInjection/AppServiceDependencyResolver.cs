using Marfrig.Application.AppServices;
using Marfrig.Application.Interfaces;
using SimpleInjector;

namespace Marfrig.CrossCutting.DependencyInjection
{
    internal class AppServiceDependencyResolver
    {
        public static void Resolve(Container container)
        {
            container.Register<IPecuaristaAppService, PecuaristaAppService>();
            container.Register<IAnimalAppService, AnimalAppService>();
            container.Register<ICompraGadoAppService, CompraGadoAppService>();
        }
    }
}
