using Marfrig.Domain.Entities;
using Marfrig.Domain.Interfaces.Repositories;
using Marfrig.Infra.Data.DbContexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Marfrig.Infra.Data.Repositories
{
    public class PecuaristaRepository : IPecuaristaRepository
    {
        private readonly MarfrigDbContext dbContext;

        public PecuaristaRepository()
        {
            dbContext = new MarfrigDbContext();
        }

        public async Task<bool> Existe(int id)
        {
            return await dbContext.Pecuaristas.AnyAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Pecuarista>> ObterPecuaristas()
        {
            return await dbContext.Pecuaristas.OrderBy(p => p.Nome).ToListAsync();
        }
    }
}
