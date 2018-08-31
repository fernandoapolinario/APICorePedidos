using APICorePedidos.Dominio.Entidades;
using System.Collections.Generic;

namespace APICorePedidos.Dominio.Interfaces
{
    public interface IPedidoRepositorio
    {
        int Inserir(Pedido pedido);

        void Alterar(Pedido pedido, int id);

        void Deletar(int id);

        Pedido ObterPorID(int id);

        IEnumerable<Pedido> ObterTudo();
    }
}
