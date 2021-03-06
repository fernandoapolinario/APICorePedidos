﻿using APICorePedidos.Dominio.Entidades;
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
            PedidoValidadorMock validador = new PedidoValidadorMock();
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
            PedidoValidadorMock validador = new PedidoValidadorMock();
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
            PedidoValidadorMock validador = new PedidoValidadorMock();
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
            PedidoValidadorMock validador = new PedidoValidadorMock();
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
        public void CasoFalha_ValorTotalInvalido()
        {
            //Arrange
            PedidoValidadorMock validador = new PedidoValidadorMock();
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
            PedidoValidadorMock validador = new PedidoValidadorMock();
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
            PedidoValidadorMock validador = new PedidoValidadorMock();
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
            PedidoValidadorMock validador = new PedidoValidadorMock();
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