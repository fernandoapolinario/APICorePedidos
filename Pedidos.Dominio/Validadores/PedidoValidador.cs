﻿using APICorePedidos.CrossCutting;
using APICorePedidos.Dominio.Entidades;
using FluentValidation;
using System;

namespace Pedidos.Dominio.Validadores
{
    public class PedidoValidador : AbstractValidator<Pedido>
    {
        public PedidoValidador()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Não foi possível encontrar o registro.");
                });

            RuleFor(c => c.NomeCliente)
                .NotEmpty().WithMessage("É necessário informar um nome.")
                .NotNull().WithMessage("É necessário informar um nome.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("É necessário informar um E-mail.")
                .NotNull().WithMessage("É necessário informar um E-mail.")
                .Must(ValidadorEmail.EmailValido).WithMessage("É necessário um E-mail válido");

            RuleFor(c => c.CPF)
                .NotEmpty().WithMessage("É necessário informar um CPF.")
                .NotNull().WithMessage("É necessário informar um CPF.")
                .Must(ValidadorCPF.CPFValido).WithMessage("É necessário um CPF válido");

            RuleFor(c => c.ValorTotal)
                .GreaterThan(0).WithMessage("O valor tem que ser maior que zero.");

            RuleFor(c => c.DataPedido)
                .NotEqual(new DateTime()).WithMessage("É necessário informar uma data do pedido.");
        }
    }
}
