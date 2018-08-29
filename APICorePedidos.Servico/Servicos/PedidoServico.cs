using System;
using System.Collections.Generic;
using APICorePedidos.Data.Repositorio;
using APICorePedidos.Dominio.Entidades;
using APICorePedidos.Dominio.Interfaces;
using FluentValidation;

namespace APICorePedidos.Servico.Servicos
{
    public class PedidoServico<T> : IPedidoServico<Pedido> where T : EntidadeBase
    {
        private PedidoRepositorio _repositorio = new PedidoRepositorio();

        public Pedido Alterar<V>(Pedido obj) where V : AbstractValidator<Pedido>
        {
            Validar(obj, Activator.CreateInstance<V>());

            _repositorio.Alterar(obj);
            return obj;
        }

        public void Deletar(int id)
        {
            if (id == 0)
                throw new ArgumentException("O ID não pode ser zero.");

            _repositorio.Deletar(id);
        }

        public Pedido Inserir<V>(Pedido obj) where V : AbstractValidator<Pedido>
        {
            Validar(obj, Activator.CreateInstance<V>());

            _repositorio.Inserir(obj);
            return obj;
        }

        public Pedido ObterPorID(int id)
        {
            if (id == 0)
                throw new ArgumentException("O ID não pode ser zero.");

            return _repositorio.ObterPorID(id);
        }

        public IEnumerable<Pedido> ObterTudo()
        {
            return _repositorio.ObterTudo();
        }
        
        public void Validar(Pedido obj, AbstractValidator<Pedido> validator)
        {
            if (obj == null)
                throw new Exception("Registros não encontrados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
