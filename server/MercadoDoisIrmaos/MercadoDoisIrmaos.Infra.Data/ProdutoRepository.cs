using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MercadoDoisIrmaos.Domain;
using MercadoDoisIrmaos.Infra.Data.DAO;
using MercadoDoisIrmaos.Domain.Repositories;

namespace MercadoDoisIrmaos.Infra.Data
{
    public class ProdutoRepository : IProdutoRepository
    {
        private ProdutoDAO produtoDao;
        public ProdutoRepository()
        {
            produtoDao = new ProdutoDAO();
        }

        public List<Produto> BuscarProdutos() => produtoDao.BuscaTodos();
        
        public Produto BuscarProduto(int id) => produtoDao.BuscarPorId(id);

        public void CadastrarProduto(Produto novoProduto) => produtoDao.CadastrarProduto(novoProduto);

        public void DesativarAtivarProduto(Produto produto) => produtoDao.DesativarAtivarProduto(produto);

        public void AtualizarProduto(Produto produto) => produtoDao.AtualizarProduto(produto);
    }
}