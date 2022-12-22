using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoDoisIrmaos.Domain
{
    public class Cliente
    {
        public long CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal PtsFidelidade { get; private set; }

        public void AtribuirPtsFidelidade(decimal valor) => this.PtsFidelidade += (valor + valor);
    }
}