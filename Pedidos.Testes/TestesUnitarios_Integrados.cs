using APICorePedidos.Dominio.Entidades;
using APICorePedidos.Dominio.Interfaces;
using NSubstitute;
using Pedidos.Dominio.Validadores;
using Xunit;

namespace Pedidos.Testes
{
    /*
     * Exemplo da utilização do NSubstitute para fazer testes integrados 
     */
    public class TestesUnitarios_Integrados
    {
        private IPedidoRepositorio pedidoRepositorio;
        private IPedidoServico pedidoServico;
        private Pedido pedido;

        public TestesUnitarios_Integrados()
        {
            this.pedidoRepositorio = Substitute.For<IPedidoRepositorio>();
            this.pedidoServico = Substitute.For<IPedidoServico>();
            this.pedido = Substitute.For<Pedido>();
        }

        [Fact]
        public void CasoSucesso_Inserir()
        {
            //arrange
            pedidoServico.Inserir<PedidoValidadorMock>(pedido).Returns(1);

            //act
            int retorno = pedidoServico.Inserir<PedidoValidadorMock>(pedido);

            //assert
            Assert.Equal(1, retorno);
        }
    }
}
