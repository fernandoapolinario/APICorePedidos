using APICorePedidos.Dominio.Entidades;
using System.Collections.Generic;

namespace APICorePedidos.Dominio.Interfaces
{
    public interface IPedidoRepositorio<T> where T : EntidadeBase
    {
        void Inserir(T pedido);

        void Alterar(T pedido);

        void Deletar(int id);

        T ObterPorID(int id);

        IEnumerable<T> ObterTudo();
    }
}
