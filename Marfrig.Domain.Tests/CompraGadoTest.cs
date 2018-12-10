using Marfrig.Domain.Entities;
using System;
using Xunit;

namespace Marfrig.Domain.Tests
{
    public class CompraGadoTest
    {

        [Fact]
        public void Nao_Deve_Validar_Data_Nova_Instancia()
        {
            // arrange
            var compraGado = new CompraGado();

            // act
            var dataValida = compraGado.InformouDataValida();

            // assert
            Assert.False(dataValida);
        }

        [Fact]
        public void Nao_Deve_Validar_Data_Min_Date()
        {
            // arrange
            var compraGado = new CompraGado
            {
               DataEntrega = DateTime.MinValue
            };

            // act
            var dataValida = compraGado.InformouDataValida();

            // assert
            Assert.False(dataValida);
        }
    }
}
