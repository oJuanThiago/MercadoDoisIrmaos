using System;
using System.Collections.Generic;

namespace MercadoDoisIrmaos.Domain.Repositories
{
    public interface IClienteRepository
    {
        void CadastrarCliente(Cliente novoCliente);
        List<Cliente> BuscarClientes();
        Cliente BuscarPorCpf(long cpf);
        void AtualizarCliente(Cliente cliente);
        void ExcluirCliente(long cpf);
        
    }
}