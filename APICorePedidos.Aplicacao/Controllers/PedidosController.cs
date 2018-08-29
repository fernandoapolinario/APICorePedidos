using APICorePedidos.Dominio.Entidades;
using APICorePedidos.Servico.Servicos;
using APICorePedidos.Servico.Validadores;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APICorePedidos.Aplicacao.Controllers
{
    [Produces("application/json")]
    [Route("api/Pedidos")]
    public class PedidosController : Controller
    {
        private PedidoServico<Pedido> _servico = new PedidoServico<Pedido>();

        [HttpPost]
        [Route("Inserir")]
        public IActionResult Post([FromBody] Pedido item)
        {
            try
            {
                _servico.Inserir<ValidadorPedido>(item);

                return new ObjectResult(item.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("Alterar")]
        public IActionResult Put([FromBody] Pedido item)
        {
            try
            {
                _servico.Alterar<ValidadorPedido>(item);

                return new ObjectResult(item);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("Deletar")]
        public IActionResult Delete(int id)
        {
            try
            {
                _servico.Deletar(id);

                return new NoContentResult();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("ObterTudo")]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(_servico.ObterTudo());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("ObterPorId")]
        public IActionResult GetAll(int id)
        {
            try
            {
                return new ObjectResult(_servico.ObterPorID(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}