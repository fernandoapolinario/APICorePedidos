using APICorePedidos.Dominio.Entidades;
using APICorePedidos.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Pedidos.Dominio.Validadores;
using System;

namespace APICorePedidos.Aplicacao.Controllers
{
    [Produces("application/json")]
    [Route("api/Pedidos")]
    public class PedidosController : Controller
    {
        private IPedidoServico _servico;

        public PedidosController(IPedidoServico pedidoServico)
        {
            _servico = pedidoServico;
        }

        [HttpPost]
        [Route("Inserir")]
        public IActionResult Inserir([FromBody] Pedido item)
        {
            try
            {
                item.Id = _servico.Inserir<PedidoValidador>(item);

                return CreatedAtAction(nameof(ObterPorId), new { id = item.Id }, item);
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
        public IActionResult Alterar([FromBody] Pedido item)
        {
            try
            {
                _servico.Alterar<PedidoValidador>(item);

                return Ok(item);
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
        public IActionResult Deletar(int id)
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
        public IActionResult ObterTudo()
        {
            try
            {
                return Ok(_servico.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("ObterPorId")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                return Ok(_servico.ObterPorID(id));
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