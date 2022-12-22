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
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _repository = new ClienteRepository();
        public ClienteController()
        {
            _repository = new ClienteRepository();
        }

        [HttpPost]
        public IActionResult PostCliente([FromBody]Cliente novoCliente)
        {
            try
            {
              _repository.CadastrarCliente(novoCliente);
              return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("todos")]
        public IActionResult GetClientes()
        {
            try
            {
                var listaClientes = _repository.BuscarClientes();
                if(listaClientes == null){
                    return StatusCode(204, listaClientes);
                }
                return StatusCode(200, listaClientes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("{cpf}")]
        public IActionResult GetCliente(long cpf)
        {
            try
            {
                var cliente = _repository.BuscarPorCpf(cpf);
                if(cliente == null){
                    return StatusCode(204, cliente);
                }
                return StatusCode(200, cliente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult AtualizarCliente([FromBody]Cliente cliente)
        {
            try
            {
                _repository.AtualizarCliente(cliente);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("{cpf}")]
        public IActionResult ExcluirCliente(long cpf)
        {
            try
            {
                _repository.ExcluirCliente(cpf);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}