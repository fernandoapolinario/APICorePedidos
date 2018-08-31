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
        public IActionResult Post([FromBody] Pedido item)
        {
            try
            {
                var id = _servico.Inserir<PedidoValidador>(item);

                return new ObjectResult(id);
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
                _servico.Alterar<PedidoValidador>(item);

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
        public IActionResult GetAll()
        {
            try
            {
                return new ObjectResult(_servico.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("ObterPorId")]
        public IActionResult Get(int id)
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