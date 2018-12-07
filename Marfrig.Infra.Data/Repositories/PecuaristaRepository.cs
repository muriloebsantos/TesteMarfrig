using Marfrig.Domain.Entities;
using Marfrig.Domain.Interfaces.Repositories;
using Marfrig.Infra.Data.DbContexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marfrig.Infra.Data.Repositories
{
    public class PecuaristaRepository : IPecuaristaRepository
    {
        private readonly MarfrigDbContext dbContext;

        public PecuaristaRepository()
        {
            dbContext = new MarfrigDbContext();
        }

        public async Task<IEnumerable<Pecuarista>> ObterPecuaristas()
        {
            return await Task.Run(() =>
            {
                return dbContext.Pecuaristas.OrderBy(p => p.Nome).ToList();
            });
        }
    }
}
