using System;
using System.Collections.Generic;

namespace MercadoDoisIrmaos.Domain.Repositories
{
    public interface IProdutoRepository
    {
        void CadastrarProduto(Produto novoProduto);
        void AtualizarProduto(Produto produto);
        List<Produto> BuscarProdutos();
        Produto BuscarProduto(int id);
        void DesativarAtivarProduto(Produto produto);
    }
}