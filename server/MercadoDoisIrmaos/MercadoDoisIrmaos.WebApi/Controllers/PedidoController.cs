using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MercadoDoisIrmaos.Domain.Repositories;
using MercadoDoisIrmaos.Infra.Data;
using MercadoDoisIrmaos.Domain;

namespace MercadoDoisIrmaos.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private IPedidoRepository _repository = new PedidoRepository();
        public PedidoController()
        {
            _repository = new PedidoRepository();
        }

        [HttpPost]
        public IActionResult PostPedido([FromBody]Pedido novoPedido)
        {
            try
            {
              _repository.RealizarPedido(novoPedido);
              return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("todos")]
        public IActionResult BuscarPedidos()
        {
            try
            {
                var listaPedidos = _repository.BuscarPedidos();
                if(listaPedidos == null){
                    return StatusCode(204, listaPedidos);
                }
                return StatusCode(200, listaPedidos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult BuscarPedido(int id)
        {
            try
            {
                var pedido = _repository.BuscarPedido(id);
                if(pedido == null){
                    return StatusCode(204, pedido);
                }
                return StatusCode(200, pedido);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult AlterarStatusPedido([FromBody]Pedido pedido)
        {
            try
            {
              _repository.AlterarStatus(pedido);
              return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletePedido(int id)
        {
            try
            {
              _repository.ExcluirPedido(id);
              return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}