﻿using APICorePedidos.Dominio.Entidades;
using APICorePedidos.Dominio.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APICorePedidos.Servico.Servicos
{
    public class PedidoServico : IPedidoServico
    {
        private IPedidoRepositorio _repositorio;

        public PedidoServico(IPedidoRepositorio pedidoRepositorio)
        {
            _repositorio = pedidoRepositorio;
        }

        public void Alterar<V>(Pedido obj) where V : AbstractValidator<Pedido>
        {
            obj.Validar(Activator.CreateInstance<V>());

            _repositorio.Alterar(obj);
        }

        public void Deletar(int id)
        {
            _repositorio.Deletar(id);
        }

        public int Inserir<V>(Pedido obj) where V : AbstractValidator<Pedido>
        {
            obj.Validar(Activator.CreateInstance<V>());

            return _repositorio.Inserir(obj);
        }

        public Pedido ObterPorID(int id)
        {
            return _repositorio.ObterPorID(id);
        }

        public IEnumerable<Pedido> ObterTodos()
        {
            return _repositorio.ObterTodos().OrderByDescending(x => x.DataPedido);
        }
    }
}
