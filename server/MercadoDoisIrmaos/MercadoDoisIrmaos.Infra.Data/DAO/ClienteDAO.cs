using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MercadoDoisIrmaos.Domain;

namespace MercadoDoisIrmaos.Infra.Data.DAO
{
    public class ClienteDAO
    {
        private string _connectionString = @"server=.\SQLEXPRESS;initial catalog=MERCADO_DOIS_IRMAOS_DB;integrated security=true;";

        public ClienteDAO()
        {
        }

        public void CadastrarCliente(Cliente novoCliente)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO
                    //CRIA SCRIPT
                    string sql = @"INSERT CLIENTE VALUES (@CPF, @NOME, @DATA_NASCIMENTO, 
                    @PONTOS_FIDELIDADE);";

                    //ADICIONANDO PARAMETROS
                    ConverterObjetoParaSql(novoCliente, comando);
                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;
                    //EXECUTA SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Cliente> BuscaTodos()
        {
            var listaCliente = new List<Cliente>(); //CRIA LISTA

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT CPF, NOME, DATA_NASCIMENTO, 
                                        PONTOS_FIDELIDADE FROM CLIENTE;"; //CRIA SCRIPT

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI CLIENTE BUSCADO
                        Cliente clienteBuscado = ConverterSqlParaObjeto(leitor);
                        //ADICIONA NA LISTA
                        listaCliente.Add(clienteBuscado);
                    }
                }
            }

            return listaCliente;
        }

        public void ExcluirCliente(long cpf)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO
                    //CRIA SCRIPT
                    string sql = @"DELETE FROM CLIENTE WHERE CPF = @CPF_CLIENTE;";

                    //ADICIONAR PARAMETROS
                    comando.Parameters.AddWithValue("@CPF_CLIENTE", cpf);
                    //ATRIBUIR SCRIPT
                    comando.CommandText = sql;
                    //EXECUTAR SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarCliente(Cliente clienteBuscado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"UPDATE CLIENTE SET            
                                        NOME = @NOME,
                                        DATA_NASCIMENTO = @DATA_NASCIMENTO
                                 WHERE CPF = @CPF_CLIENTE;";

                    //ADICIONAR PARAMETROS
                    ConverterObjetoParaSql(clienteBuscado, comando);
                    comando.Parameters.AddWithValue("@CPF_CLIENTE", clienteBuscado.CPF);

                    //ATRIBUIR SCRIPT
                    comando.CommandText = sql;

                    //EXECUTAR SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }

        public Cliente BuscarPorCpf(long cpf)
        {
            var clienteBuscado = new Cliente();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT CPF, NOME, DATA_NASCIMENTO, 
                                    PONTOS_FIDELIDADE
                                    FROM CLIENTE WHERE CPF = @CPF_CLIENTE;"; //CRIA SCRIPT

                    comando.Parameters.AddWithValue("@CPF_CLIENTE", cpf);
                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;
                    SqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI CLIENTE BUSCADO
                        clienteBuscado = ConverterSqlParaObjeto(leitor);
                    }
                }
            }

            return clienteBuscado;
        }

        public void AtualizarPtsFidelidade(Pedido pedido)
        {
            pedido.Cliente.AtribuirPtsFidelidade(pedido.ValorTotal);

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO
                    //CRIA SCRIPT
                    string sql = @"UPDATE CLIENTE SET            
                                        PONTOS_FIDELIDADE = @PONTOS_FIDELIDADE
                                 WHERE CPF = @CPF;";

                    //ADICIONAR PARAMETROS
                    ConverterObjetoParaSql(pedido.Cliente, comando);
                    comando.Parameters.AddWithValue("@CPF", pedido.Cliente.CPF);
                    //ATRIBUIR SCRIPT
                    comando.CommandText = sql;
                    //EXECUTAR SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }

        private Cliente ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            var cliente = new Cliente();
            cliente.CPF = long.Parse(leitor["CPF"].ToString());
            cliente.Nome = leitor["NOME"].ToString();
            cliente.DataNascimento = Convert.ToDateTime(leitor["DATA_NASCIMENTO"].ToString());
            cliente.AtribuirPtsFidelidade(decimal.Parse(leitor["PONTOS_FIDELIDADE"].ToString()));

            return cliente;
        }

        private void ConverterObjetoParaSql(Cliente cliente, SqlCommand comando)
        {
            //ADICIONANDO PARAMETROS
            comando.Parameters.AddWithValue("@CPF", cliente.CPF);
            comando.Parameters.AddWithValue("@NOME", cliente.Nome);
            comando.Parameters.AddWithValue("@DATA_NASCIMENTO", cliente.DataNascimento);
            comando.Parameters.AddWithValue("@PONTOS_FIDELIDADE", cliente.PtsFidelidade);
        }
    }
}