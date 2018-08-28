using System;

namespace APICorePedidos.Dominio.Entidades
{
    public class Pedido : EntidadeBase
    {
        public string NomeCliente { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public double ValorTotal { get; set; }

        public DateTime DataPedido { get; set; }
    }
}
