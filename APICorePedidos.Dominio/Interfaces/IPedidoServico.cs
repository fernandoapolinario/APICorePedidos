using APICorePedidos.Dominio.Entidades;
using FluentValidation;
using System.Collections.Generic;

namespace APICorePedidos.Dominio.Interfaces
{
    public interface IPedidoServico<T> where T : EntidadeBase
    {
        int Inserir<V>(T obj) where V : AbstractValidator<T>;

        void Alterar<V>(T obj, int id) where V : AbstractValidator<T>;

        void Deletar(int id);

        T ObterPorID(int id);

        IEnumerable<T> ObterTudo();

        void Validar(T obj, AbstractValidator<T> validator);
    }
}
