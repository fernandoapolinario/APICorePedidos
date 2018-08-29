using System.Collections.Generic;
using APICorePedidos.Dominio.Entidades;
using APICorePedidos.Dominio.Interfaces;

namespace APICorePedidos.Data.Repositorio
{
    public class PedidoRepositorio : IPedidoRepositorio<Pedido>
    {
        public void Alterar(Pedido pedido)
        {
            throw new System.NotImplementedException();
        }

        public void Inserir(Pedido pedido)
        {
            throw new System.NotImplementedException();
        }

        public Pedido ObterPorID(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Pedido> ObterTudo()
        {
            throw new System.NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
