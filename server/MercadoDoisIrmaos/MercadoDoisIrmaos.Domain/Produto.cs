using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoDoisIrmaos.Domain
{
    public class Produto
    {
        public Produto()
        {
            Quantidade = 0; // INICIA ZERADA
            Ativo = true; // INICIA ATIVO
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public DateTime Validade { get; set; }
        public bool Ativo { get; set; }

    }
}