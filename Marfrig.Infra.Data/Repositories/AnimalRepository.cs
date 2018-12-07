using Marfrig.Domain.Entities;
using Marfrig.Domain.Interfaces.Repositories;
using Marfrig.Infra.Data.DbContexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marfrig.Infra.Data.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly MarfrigDbContext dbContext;

        public AnimalRepository()
        {
            dbContext = new MarfrigDbContext();
        }

        public async Task<IEnumerable<Animal>> ObterAnimais()
        {
            return await Task.Run(() =>
            {
                return dbContext.Animais.OrderBy(p => p.Descricao).ToList();
            });
        }
    }
}
