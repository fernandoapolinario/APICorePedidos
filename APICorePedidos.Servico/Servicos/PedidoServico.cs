using APICorePedidos.Dominio.Entidades;
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

        public void Alterar<V>(Pedido obj, int id) where V : AbstractValidator<Pedido>
        {
            if (id == 0)
                throw new ArgumentException("Insira um ID válido.");

            Validar(obj, Activator.CreateInstance<V>());

            _repositorio.Alterar(obj, id);
        }

        public void Deletar(int id)
        {
            if (id == 0)
                throw new ArgumentException("Insira um ID válido.");

            _repositorio.Deletar(id);
        }

        public int Inserir<V>(Pedido obj) where V : AbstractValidator<Pedido>
        {
            Validar(obj, Activator.CreateInstance<V>());

            return _repositorio.Inserir(obj);
        }

        public Pedido ObterPorID(int id)
        {
            if (id == 0)
                throw new ArgumentException("Insira um ID válido.");

            return _repositorio.ObterPorID(id);
        }

        public IEnumerable<Pedido> ObterTudo()
        {
            return _repositorio.ObterTudo().OrderByDescending(x => x.DataPedido);
        }

        public void Validar(Pedido obj, AbstractValidator<Pedido> validator)
        {
            if (obj == null)
                throw new Exception("Registros não encontrados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
