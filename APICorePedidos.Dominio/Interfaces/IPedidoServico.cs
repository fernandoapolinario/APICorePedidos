using APICorePedidos.Dominio.Entidades;
using FluentValidation;
using System.Collections.Generic;

namespace APICorePedidos.Dominio.Interfaces
{
    public interface IPedidoServico
    {
        int Inserir<V>(Pedido obj) where V : AbstractValidator<Pedido>;

        void Alterar<V>(Pedido obj) where V : AbstractValidator<Pedido>;

        void Deletar(int id);

        Pedido ObterPorID(int id);

        IEnumerable<Pedido> ObterTodos();
    }
}
