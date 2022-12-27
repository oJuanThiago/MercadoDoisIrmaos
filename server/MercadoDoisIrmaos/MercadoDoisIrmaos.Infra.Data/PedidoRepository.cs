using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MercadoDoisIrmaos.Infra.Data.DAO;
using MercadoDoisIrmaos.Domain;
using MercadoDoisIrmaos.Domain.Repositories;

namespace MercadoDoisIrmaos.Infra.Data
{
    public class PedidoRepository : IPedidoRepository
    {
        private PedidoDAO pedidoDao;
        private ClienteDAO clienteDao;
        public PedidoRepository()
        {
            pedidoDao = new PedidoDAO();
            clienteDao = new ClienteDAO();
        }

        public void RealizarPedido(Pedido novoPedido)
        {
            if (novoPedido.CpfCliente != 0)
            {
                clienteDao.AtualizarPtsFidelidade(novoPedido);
            }
            pedidoDao.RealizarPedido(novoPedido);
        }

        public List<Pedido> BuscarPedidos() => pedidoDao.BuscaTodos();

        public void AlterarStatus(Pedido pedido) => pedidoDao.AlterarStatus(pedido);

        public void ExcluirPedido(int id) => pedidoDao.ExcluirPedido(id);

        public Pedido BuscarPedido(int id) => pedidoDao.BuscarPedidoPorId(id);
    }
}