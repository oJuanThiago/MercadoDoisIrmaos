using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoDoisIrmaos.Domain.Repositories
{
    public interface IPedidoRepository
    {
        void RealizarPedido(Pedido novoPedido);
        List<Pedido> BuscarPedidos();
        Pedido BuscarPedido(int id);
        void ExcluirPedido(int id);
        void AlterarStatus(Pedido pedido);
    }
}