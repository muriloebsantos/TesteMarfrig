using Marfrig.Domain.Entities;
using Marfrig.Domain.Interfaces.Repositories;
using Marfrig.Infra.Data.DbContexts;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Marfrig.Domain.Models.ReadModels;
using Marfrig.Domain.Models;

namespace Marfrig.Infra.Data.Repositories
{
    public class CompraGadoRepository : ICompraGadoRepository
    {
        private readonly MarfrigDbContext dbContext;

        public CompraGadoRepository()
        {
            dbContext = new MarfrigDbContext();
        }

        public async Task Atualizar(CompraGado compraGado)
        {
            var itensAntesDeSalvar = dbContext.ComprasGadoItem.Where(i => i.CompraGadoId == compraGado.Id).ToList();
            var codigosItensAtualizar = compraGado.CompraGadoItens.Select(i => i.Id).ToList();
            var itensExcluir = itensAntesDeSalvar.Where(i => !codigosItensAtualizar.Contains(i.Id));
            var compraAtualizar = dbContext.ComprasGado.Find(compraGado.Id);

            foreach (var item in compraGado.CompraGadoItens)
            {
                if (item.Id == 0)
                    dbContext.ComprasGadoItem.Add(item);
                else
                {
                    var itemAtualizar = itensAntesDeSalvar.FirstOrDefault(i => i.Id == item.Id);
                    dbContext.Entry(itemAtualizar).CurrentValues.SetValues(item);
                }

            }

            foreach (var itemExcluir in itensExcluir)
                dbContext.Entry(itemExcluir).State = EntityState.Deleted;

            dbContext.Entry(compraAtualizar).CurrentValues.SetValues(compraGado);

            await dbContext.SaveChangesAsync();
        }

        public async Task<PagedResult<CompraGadoConsulta>> Buscar(FilterOptions options, int id, int pecuaristaId, DateTime? dataEntregaInicio, DateTime? dataEntregaFim)
        {
            var query = dbContext.ComprasGadoItem.AsQueryable();
            var buscarPorId = id > 0;

            if (!buscarPorId)
            {
                if (pecuaristaId > 0)
                    query = query.Where(q => q.CompraGado.PecuaristaId == pecuaristaId);

                if (dataEntregaInicio != null)
                    query = query.Where(q => q.CompraGado.DataEntrega >= dataEntregaInicio);

                if (dataEntregaFim != null)
                    query = query.Where(q => q.CompraGado.DataEntrega <= dataEntregaFim);
            }
            else
            {
                query = query.Where(q => q.CompraGado.Id == id);
            }

            var agrupamento = query.GroupBy(g => new
            {
                Id = g.CompraGadoId,
                Data = g.CompraGado.DataEntrega,
                Pecuarista = g.CompraGado.Pecuarista.Nome,
                g.CompraGado.Impressa
            });

            var qtdeRegistros = await agrupamento.CountAsync();

            var registros = await agrupamento
                                     .OrderBy(q => q.Key.Id)
                                     .Skip(options.Skip)
                                     .Take(options.PageSize)
                                     .Select(g => new CompraGadoConsulta
                                     {
                                         Id = g.Key.Id,
                                         Data = g.Key.Data,
                                         Pecuarista = g.Key.Pecuarista,
                                         Impressa = g.Key.Impressa,
                                         ValorTotal = g.Sum(s => s.Quantidade * s.Preco)
                                     })
                                     .ToListAsync();

            var pagedResult = new PagedResult<CompraGadoConsulta>
            {
                CurrentPage = options.CurrentPage,
                PageSize = options.PageSize,
                TotalRecords = qtdeRegistros,
                Data = registros
            };

            return pagedResult;
        }

        public async Task<CompraGado> BuscarPorId(int id)
        {
            return await dbContext.ComprasGado
                                  .Include(a => a.CompraGadoItens)
                                  .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task Excluir(int id)
        {
            var compraGado = await dbContext.ComprasGado.FindAsync(id);
            dbContext.ComprasGado.Remove(compraGado);
            await dbContext.SaveChangesAsync();
        }

        public async Task Inserir(CompraGado compraGado)
        {
            dbContext.ComprasGado.Add(compraGado);
            await dbContext.SaveChangesAsync();
        }

        public async Task<CompraGadoRelatorio> RelatorioCompra(int id)
        {
            var compraGado = await dbContext.ComprasGado.Where(c => c.Id == id)
                                                        .Select(c => new CompraGadoRelatorio
                                                        {
                                                            Id = c.Id,
                                                            DataEntrega = c.DataEntrega,
                                                            Pecuarista = c.Pecuarista.Nome
                                                        }).FirstOrDefaultAsync();

            var itens = await dbContext.ComprasGadoItem.Where(c => c.CompraGadoId == id)
                                                        .Select(i => new CompraGadoItemRelatorio
                                                        {
                                                            Animal = i.Animal.Descricao,
                                                            Preco = i.Preco,
                                                            Quantidade = i.Quantidade
                                                        }).ToListAsync();

            compraGado.Itens = itens;

            return compraGado;
        }
    }
}
