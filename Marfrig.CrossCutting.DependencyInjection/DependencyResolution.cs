using SimpleInjector;

namespace Marfrig.CrossCutting.DependencyInjection
{
    public class DependencyResolution
    {
        public static Container GetContainer()
        {
            var container = new Container();

            RepositoryDependencyResolver.Resolve(container);
            AppServiceDependencyResolver.Resolve(container);
            DomainServiceDependencyResolver.Resolve(container);

            return container;
        }
    }
}
