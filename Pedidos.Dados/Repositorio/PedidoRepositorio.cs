using APICorePedidos.Data.Contexto;
using APICorePedidos.Dominio.Entidades;
using APICorePedidos.Dominio.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace APICorePedidos.Data.Repositorio
{
    public class PedidoRepositorio : SqlContexto, IPedidoRepositorio
    {
        public PedidoRepositorio(IConfiguration config) : base(config) { }

        public int Alterar(Pedido pedido)
        {
            int resultado = 0;
            using (IDbConnection db = BDConexao)
            {
                var result = db.Execute("sp_Pedidos_Alterar",
                    new
                    {
                        @Id = pedido.Id,
                        @NomeCliente = pedido.NomeCliente,
                        @Email = pedido.Email,
                        @CPF = pedido.CPF,
                        @ValorTotal = pedido.ValorTotal,
                        @DataPedido = pedido.DataPedido
                    }, commandType: System.Data.CommandType.StoredProcedure);

                resultado = result;
            }

            return resultado;
        }

        public int Inserir(Pedido pedido)
        {
            int idInserido = 0;

            using (IDbConnection db = BDConexao)
            {
                var result = db.Query<int>("sp_Pedidos_Inserir",
                    new
                    {
                        @NomeCliente = pedido.NomeCliente,
                        @Email = pedido.Email,
                        @CPF = pedido.CPF,
                        @ValorTotal = pedido.ValorTotal,
                        @DataPedido = pedido.DataPedido
                    }, commandType: System.Data.CommandType.StoredProcedure).Single();

                idInserido = result;
            }

            return idInserido;
        }

        public Pedido ObterPorID(int id)
        {
            Pedido pedidoRetorno = null;
            using (IDbConnection db = BDConexao)
            {
                pedidoRetorno = db.Query<Pedido>("sp_Pedidos_ObterPorId",
                    new { Id = id }, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }

            return pedidoRetorno;
        }

        public IEnumerable<Pedido> ObterTodos()
        {
            IEnumerable<Pedido> listaRetorno;
            using (IDbConnection db = BDConexao)
            {
                listaRetorno = db.Query<Pedido>("sp_Pedidos_Obter",
                    commandType: System.Data.CommandType.StoredProcedure).ToList();
            }

            return listaRetorno;
        }

        public void Deletar(int id)
        {
            using (IDbConnection db = BDConexao)
            {
                db.Execute("sp_Pedidos_Deletar",
                    new { @Id = id }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
