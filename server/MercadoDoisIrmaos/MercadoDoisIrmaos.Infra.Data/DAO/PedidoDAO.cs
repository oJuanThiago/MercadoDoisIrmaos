using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MercadoDoisIrmaos.Domain;

namespace MercadoDoisIrmaos.Infra.Data.DAO
{
    public class PedidoDAO
    {
        private string _connectionString = @"server=.\SQLEXPRESS;initial catalog=MERCADO_DOIS_IRMAOS_DB;integrated security=true;";
        public PedidoDAO()
        {
        }

        public void RealizarPedido(Pedido novoPedido)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT PEDIDO VALUES (@CPF_CLIENTE, @ID_PRODUTO, @DATA_HORA, 
                                    @QUANTIDADE_PRODUTO, @STATUS_PEDIDO, @VALOR_TOTAL)";

                    ConverterObjetoParaSql(novoPedido, comando);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }

        }

        public List<Pedido> BuscaTodos()
        {
            var listaPedido = new List<Pedido>(); //CRIA LISTA

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT ID_PEDIDO, CPF_CLIENTE, ID_PRODUTO, DATA_HORA,
                                    QUANTIDADE_PRODUTO, STATUS_PEDIDO, 
                                    VALOR_TOTAL FROM PEDIDO;"; //CRIA SCRIPT

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI Pedido BUSCADO
                        Pedido pedidoBuscado = ConverterSqlParaObjeto(leitor);

                        //ADICIONA NA LISTA
                        listaPedido.Add(pedidoBuscado);
                    }
                }
            }

            return listaPedido;
        }

        public Pedido BuscarPedidoPorId(int id)
        {
            var pedidoBuscado = new Pedido();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT ID_PEDIDO, CPF_CLIENTE, ID_PRODUTO, DATA_HORA,
                                    QUANTIDADE_PRODUTO, STATUS_PEDIDO, 
                                    VALOR_TOTAL FROM PEDIDO WHERE ID_PEDIDO = @ID_PEDIDO;"; //CRIA SCRIPT

                    comando.Parameters.AddWithValue("@ID_PEDIDO", id);
                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;
                    SqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI CLIENTE BUSCADO
                        pedidoBuscado = ConverterSqlParaObjeto(leitor);
                    }
                }
            }

            return pedidoBuscado;
        }


        public void AlterarStatus(Pedido pedido)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO
                    //CRIA SCRIPT
                    string sql = @"UPDATE PEDIDO SET            
                                        STATUS_PEDIDO = @STATUS_PEDIDO
                                 WHERE ID_PEDIDO = @ID_PEDIDO;";

                    //ADICIONAR PARAMETROS
                    ConverterObjetoParaSql(pedido, comando);
                    comando.Parameters.AddWithValue("@ID_PEDIDO", pedido.Id);
                    //ATRIBUIR SCRIPT
                    comando.CommandText = sql;
                    //EXECUTAR SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void ExcluirPedidosPorCpf(long cpf)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"DELETE FROM PEDIDO WHERE CPF_CLIENTE = @CPF_CLIENTE;";

                    //ADICIONAR PARAMETROS
                    comando.Parameters.AddWithValue("@CPF_CLIENTE", cpf);

                    //ATRIBUIR SCRIPT
                    comando.CommandText = sql;

                    //EXECUTAR SCRIPT
                    comando.ExecuteNonQuery();
                }
            }            
        }
        
        public void ExcluirPedido(int id)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"DELETE FROM PEDIDO WHERE ID_PEDIDO = @ID_PEDIDO;";

                    //ADICIONAR PARAMETROS
                    comando.Parameters.AddWithValue("@ID_PEDIDO", id);

                    //ATRIBUIR SCRIPT
                    comando.CommandText = sql;

                    //EXECUTAR SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }

        private Pedido ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            var pedido = new Pedido();
            pedido.Id = int.Parse(leitor["ID_PEDIDO"].ToString());
            pedido.CpfCliente = long.Parse(leitor["CPF_CLIENTE"].ToString());
            pedido.IdProduto = int.Parse(leitor["ID_PRODUTO"].ToString());
            pedido.DataHora = Convert.ToDateTime(leitor["DATA_HORA"].ToString());
            pedido.QtdProduto = int.Parse(leitor["QUANTIDADE_PRODUTO"].ToString());
            pedido.Status = int.Parse(leitor["STATUS_PEDIDO"].ToString());
            pedido.AtribuirValorTotal(decimal.Parse(leitor["VALOR_TOTAL"].ToString()));

            return pedido;
        }

        private void ConverterObjetoParaSql(Pedido pedido, SqlCommand comando)
        {
            //ADICIONANDO PARAMETROS
                    comando.Parameters.AddWithValue("@ID_PEDIDO", pedido.Id);
                    comando.Parameters.AddWithValue("@CPF_CLIENTE", pedido.CpfCliente);
                    comando.Parameters.AddWithValue("@ID_PRODUTO", pedido.IdProduto);
                    comando.Parameters.AddWithValue("@DATA_HORA", pedido.DataHora);
                    comando.Parameters.AddWithValue("@QUANTIDADE_PRODUTO", pedido.QtdProduto);
                    comando.Parameters.AddWithValue("@STATUS_PEDIDO", pedido.Status);
                    comando.Parameters.AddWithValue("@VALOR_TOTAL", pedido.ValorTotal);
        }

    }
}