using Marfrig.Domain.Entities;
using Marfrig.Domain.Interfaces.Repositories;
using Marfrig.Domain.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Marfrig.Domain.Tests
{
    public class CompraGadoServiceTest
    {
        [Fact]
        public async void Deve_Chamar_Repositorio_Com_Compra_Valida()
        {
            // arrange
            var compra = new CompraGado()
            {
                DataEntrega = DateTime.Now,
                PecuaristaId = 1,
                CompraGadoItens = new List<CompraGadoItem>
                {
                      new CompraGadoItem { AnimalId = 1, Quantidade = 1, Preco = 100 }
                }
            };

            var compraRepositorio = Substitute.For<ICompraGadoRepository>();
            var compraGadoService = new CompraGadoService(compraRepositorio, null);

            // act
            await compraGadoService.CriarNovaCompraDeGado(compra);

            // assert
           await compraRepositorio.Received(1).Inserir(compra);
        }
    }
}
