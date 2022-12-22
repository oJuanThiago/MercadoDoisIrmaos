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
    public class ProdutoController : ControllerBase
    {
        private IProdutoRepository _repository = new ProdutoRepository();
        public ProdutoController()
        {
            _repository = new ProdutoRepository();
        }
        
        [HttpPost]
        public IActionResult PostProduto([FromBody]Produto novoProduto)
        {
            try
            {
              _repository.CadastrarProduto(novoProduto);
              return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("todos")]
        public IActionResult GetProdutos()
        {
            try
            {
                var listaProdutos = _repository.BuscarProdutos();
                if(listaProdutos == null){
                    return StatusCode(204, listaProdutos);
                }
                return StatusCode(200, listaProdutos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult BuscarProduto(int id)
        {
            try
            {
                var produto = _repository.BuscarProduto(id);
                if(produto == null){
                    return StatusCode(204, produto);
                }
                return StatusCode(200, produto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult DesativarAtivarProduto([FromBody]Produto produto)
        {
            try
            {
                _repository.DesativarAtivarProduto(produto);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}