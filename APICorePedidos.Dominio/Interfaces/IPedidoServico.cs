using APICorePedidos.Dominio.Entidades;
using FluentValidation;
using System.Collections.Generic;

namespace APICorePedidos.Dominio.Interfaces
{
    public interface IPedidoServico<T> where T : EntidadeBase
    {
        T Inserir<V>(T obj) where V : AbstractValidator<T>;

        T Alterar<V>(T obj) where V : AbstractValidator<T>;

        void Deletar(int id);

        T ObterPorID(int id);

        IEnumerable<T> ObterTudo();
    }
}
