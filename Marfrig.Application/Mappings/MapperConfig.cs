using AutoMapper;

namespace Marfrig.Application.Mappings
{
    public class MapperConfig
    {
        public static void ConfigureMappings()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<DomainToDTOProfile>();
                config.AddProfile<DTOToDomainProfile>();
            });
        }
    }
}
