using Marfrig.Domain.Entities;
using Marfrig.Domain.Interfaces.Repositories;
using Marfrig.Domain.Models;
using Marfrig.Infra.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marfrig.Infra.Data.Repositories
{
    public class CompraGadoRepository : ICompraGadoRepository
    {
        private readonly MarfrigDbContext dbContext;

        public CompraGadoRepository()
        {
            dbContext = new MarfrigDbContext();
        }

        public Task Atualizar(CompraGado compraGado)
        {
            throw new NotImplementedException();
        }

        public Task<PagingResult<CompraGado>> Buscar(FilterOptions options, int id, int pecuaristaId, DateTime dataEntregaInicio, DateTime dataEntregaFim)
        {
            throw new NotImplementedException();
        }

        public Task<CompraGado> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Inserir(CompraGado compraGado)
        {
            dbContext.ComprasGado.Add(compraGado);
            await dbContext.SaveChangesAsync();
        }
    }
}
