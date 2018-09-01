using APICorePedidos.Dominio.Entidades;
using FluentValidation.Results;
using Pedidos.Dominio.Validadores;
using System;
using Xunit;

namespace Pedidos.Testes
{
    public class TesteUnitario_Validadores
    {
        [Fact]
        public void CasoSucesso()
        {
            //Arrange
            PedidoValidador validador = new PedidoValidador();
            Pedido pedido = new Pedido
            {
                NomeCliente = "Cliente teste",
                Email = "email@teste.com",
                CPF = "906.532.070-93",
                ValorTotal = 100,
                DataPedido = DateTime.Now
            };

            //Act
            ValidationResult act = validador.Validate(pedido);

            //Assert
            Assert.True(act.IsValid);
        }

        [Fact]
        public void CasoFalha_NomeBranco()
        {
            //Arrange
            PedidoValidador validador = new PedidoValidador();
            Pedido pedido = new Pedido
            {
                NomeCliente = "",
                Email = "email@teste.com",
                CPF = "906.532.070-93",
                ValorTotal = 100,
                DataPedido = DateTime.Now
            };

            //Act
            ValidationResult act = validador.Validate(pedido);

            //Assert
            Assert.False(act.IsValid);
        }

        [Fact]
        public void CasoFalha_EmailBranco()
        {
            //Arrange
            PedidoValidador validador = new PedidoValidador();
            Pedido pedido = new Pedido
            {
                NomeCliente = "Cliente teste",
                Email = "",
                CPF = "906.532.070-93",
                ValorTotal = 100,
                DataPedido = DateTime.Now
            };

            //Act
            ValidationResult act = validador.Validate(pedido);

            //Assert
            Assert.False(act.IsValid);
        }

        [Fact]
        public void CasoFalha_CPFBranco()
        {
            //Arrange
            PedidoValidador validador = new PedidoValidador();
            Pedido pedido = new Pedido
            {
                NomeCliente = "Cliente teste",
                Email = "email@teste.com",
                CPF = "",
                ValorTotal = 100,
                DataPedido = DateTime.Now
            };

            //Act
            ValidationResult act = validador.Validate(pedido);

            //Assert
            Assert.False(act.IsValid);
        }

        [Fact]
        public void CasoFalha_ValorTotalBranco()
        {
            //Arrange
            PedidoValidador validador = new PedidoValidador();
            Pedido pedido = new Pedido
            {
                NomeCliente = "Cliente teste",
                Email = "email@teste.com",
                CPF = "906.532.070-93",
                ValorTotal = 0,
                DataPedido = DateTime.Now
            };

            //Act
            ValidationResult act = validador.Validate(pedido);

            //Assert
            Assert.False(act.IsValid);
        }

        [Fact]
        public void CasoFalha_DataPedidoBranco()
        {
            //Arrange
            PedidoValidador validador = new PedidoValidador();
            Pedido pedido = new Pedido
            {
                NomeCliente = "Cliente teste",
                Email = "email@teste.com",
                CPF = "906.532.070-93",
                ValorTotal = 100
                //DataPedido = ""
            };

            //Act
            ValidationResult act = validador.Validate(pedido);

            //Assert
            Assert.False(act.IsValid);
        }

        [Fact]
        public void CasoFalha_EmailInvalido()
        {
            //Arrange
            PedidoValidador validador = new PedidoValidador();
            Pedido pedido = new Pedido
            {
                NomeCliente = "Cliente teste",
                Email = "emailteste.com",
                CPF = "906.532.070-93",
                ValorTotal = 100,
                DataPedido = DateTime.Now
            };

            //Act
            ValidationResult act = validador.Validate(pedido);

            //Assert
            Assert.False(act.IsValid);
        }

        [Fact]
        public void CasoFalha_CPFInvalido()
        {
            //Arrange
            PedidoValidador validador = new PedidoValidador();
            Pedido pedido = new Pedido
            {
                NomeCliente = "Cliente teste",
                Email = "email@teste.com",
                CPF = "90653207093",
                ValorTotal = 100,
                DataPedido = DateTime.Now
            };

            //Act
            ValidationResult act = validador.Validate(pedido);

            //Assert
            Assert.False(act.IsValid);
        }
    }
}