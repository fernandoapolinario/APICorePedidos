using APICorePedidos.Dominio.Entidades;
using System.Collections.Generic;

namespace APICorePedidos.Dominio.Interfaces
{
    public interface IPedidoRepositorio<T> where T : EntidadeBase
    {
        int Inserir(T pedido);

        void Alterar(T pedido, int id);

        void Deletar(int id);

        T ObterPorID(int id);

        IEnumerable<T> ObterTudo();
    }
}
