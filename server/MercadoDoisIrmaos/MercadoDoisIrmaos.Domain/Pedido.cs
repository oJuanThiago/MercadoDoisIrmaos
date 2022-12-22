using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoDoisIrmaos.Domain
{
    public class Pedido
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Produto Produto { get; set; }
        public DateTime DataHora { get; set; }
        public int QtdProduto { get; set; }
        public int Status { get; set; }
        public decimal ValorTotal { get; private set; }

        public Pedido()
        {
            DataHora = DateTime.Now;
        }
        public void AtribuirValorTotal(decimal valor)
        {
            ValorTotal = valor;
        }

    }
}