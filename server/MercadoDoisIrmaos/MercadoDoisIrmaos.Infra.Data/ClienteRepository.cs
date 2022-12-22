using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MercadoDoisIrmaos.Infra.Data.DAO;
using MercadoDoisIrmaos.Domain;
using MercadoDoisIrmaos.Domain.Repositories;

namespace MercadoDoisIrmaos.Infra.Data
{
    public class ClienteRepository : IClienteRepository
    {
        private ClienteDAO clienteDao;
        private PedidoDAO pedidoDao;
        public ClienteRepository()
        {
            clienteDao = new ClienteDAO();
            pedidoDao = new PedidoDAO();
        }   
        
        public void CadastrarCliente(Cliente novoCliente) => clienteDao.CadastrarCliente(novoCliente);

        public List<Cliente> BuscarClientes() => clienteDao.BuscaTodos();

        public Cliente BuscarPorCpf(long cpf) => clienteDao.BuscarPorCpf(cpf);

        public void AtualizarCliente(Cliente cliente) => clienteDao.AtualizarCliente(cliente);
        
        public void ExcluirCliente(long cpf)
        {
            pedidoDao.ExcluirPedidosPorCpf(cpf);
            clienteDao.ExcluirCliente(cpf);
        }
    }
}