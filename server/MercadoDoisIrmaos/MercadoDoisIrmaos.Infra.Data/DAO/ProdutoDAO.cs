using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MercadoDoisIrmaos.Domain;
using System.Threading.Tasks;

namespace MercadoDoisIrmaos.Infra.Data.DAO
{
    public class ProdutoDAO
    {
        private string _connectionString = @"server=.\SQLEXPRESS;initial catalog=MERCADO_DOIS_IRMAOS_DB;integrated security=true;";

        public ProdutoDAO()
        {
        }

        public void CadastrarProduto(Produto novoProduto)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"INSERT PRODUTO VALUES (@DESCRICAO, @VALIDADE, @VALOR, @QUANTIDADE, @ATIVO);";

                    //ADICIONANDO PARAMETROS
                    ConverterObjetoParaSql(novoProduto, comando);

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    //EXECUTA SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Produto> BuscaTodos()
        {
            var listaProduto = new List<Produto>(); //CRIA LISTA

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT ID, DESCRICAO, VALOR, QUANTIDADE,
                                     VALIDADE, ATIVO FROM PRODUTO;"; //CRIA SCRIPT

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI PRODUTO BUSCADO
                        Produto produtoBuscado = ConverterSqlParaObjeto(leitor);

                        //ADICIONA NA LISTA
                        listaProduto.Add(produtoBuscado);
                    }
                }
            }

            return listaProduto;
        }

        public void DesativarAtivarProduto(Produto produtoBuscado)
        {
            produtoBuscado.Ativo = !produtoBuscado.Ativo;

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"UPDATE PRODUTO SET ATIVO = @ATIVO WHERE ID = @ID;";

                    //ADICIONAR PARAMETROS
                    ConverterObjetoParaSql(produtoBuscado, comando);
                    comando.Parameters.AddWithValue("@ID", produtoBuscado.Id);

                    //ATRIBUIR SCRIPT
                    comando.CommandText = sql;

                    //EXECUTAR SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarProduto(Produto produtoBuscado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"UPDATE PRODUTO SET            
                                        DESCRICAO = @DESCRICAO,
                                        VALOR = @VALOR,
                                        VALIDADE = @VALIDADE
                                 WHERE ID = @ID;";

                    //ADICIONAR PARAMETROS
                    ConverterObjetoParaSql(produtoBuscado, comando);
                    comando.Parameters.AddWithValue("@ID", produtoBuscado.Id);

                    //ATRIBUIR SCRIPT
                    comando.CommandText = sql;

                    //EXECUTAR SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void EntradaEstoque(Produto produtoBuscado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"UPDATE PRODUTO SET QUANTIDADE += @QUANTIDADE WHERE ID = @ID;";

                    //ADICIONAR PARAMETROS
                    ConverterObjetoParaSql(produtoBuscado, comando);
                    comando.Parameters.AddWithValue("@ID", produtoBuscado.Id);

                    //ATRIBUIR SCRIPT
                    comando.CommandText = sql;

                    //EXECUTAR SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }
        public void SaidaEstoque(Produto produtoBuscado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"UPDATE PRODUTO SET QUANTIDADE -= @QUANTIDADE WHERE ID = @ID;";

                    //ADICIONAR PARAMETROS
                    ConverterObjetoParaSql(produtoBuscado, comando);
                    comando.Parameters.AddWithValue("@ID", produtoBuscado.Id);

                    //ATRIBUIR SCRIPT
                    comando.CommandText = sql;

                    //EXECUTAR SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Produto> BuscaPorTexto(string nome)
        {
            var listaProduto = new List<Produto>(); //CRIA LISTA

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT ID, DESCRICAO, VALIDADE, VALOR,
                                 QUANTIDADE, ATIVO FROM PRODUTO WHERE DESCRICAO LIKE @TEXTO;"; //CRIA SCRIPT

                    comando.Parameters.AddWithValue("@TEXTO", $"%{nome}%");

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI PRODUTO BUSCADO
                        var produtoBuscado = ConverterSqlParaObjeto(leitor);
                        //ADICIONA NA LISTA
                        listaProduto.Add(produtoBuscado);
                    }
                }
            }

            return listaProduto;
        }

        public Produto BuscarPorId(int idProduto)
        {
            var produtoBuscado = new Produto();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT ID, NOME, VALIDADE, 
                    VALOR, DESCRICAO, QUANTIDADE FROM PRODUTO WHERE ID = @ID;"; //CRIA SCRIPT

                    comando.Parameters.AddWithValue("@ID", idProduto);

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI PRODUTO BUSCADO
                        produtoBuscado = ConverterSqlParaObjeto(leitor);
                    }
                }
            }

            return produtoBuscado;
        }

        private Produto ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            var produto = new Produto();
            produto.Id = int.Parse(leitor["ID"].ToString());
            produto.Descricao = leitor["DESCRICAO"].ToString();
            produto.Validade = Convert.ToDateTime(leitor["VALIDADE"].ToString());
            produto.Valor = decimal.Parse(leitor["VALOR"].ToString());
            produto.Quantidade = int.Parse(leitor["QUANTIDADE"].ToString());
            produto.Ativo = Boolean.Parse(leitor["ATIVO"].ToString());

            return produto;
        }

        private void ConverterObjetoParaSql(Produto produto, SqlCommand comando)
        {
            //ADICIONANDO PARAMETROS
            comando.Parameters.AddWithValue("@ID", produto.Id);
            comando.Parameters.AddWithValue("@DESCRICAO", produto.Descricao);
            comando.Parameters.AddWithValue("@VALIDADE", produto.Validade);
            comando.Parameters.AddWithValue("@VALOR", produto.Valor);
            comando.Parameters.AddWithValue("@QUANTIDADE", produto.Quantidade);
            comando.Parameters.AddWithValue("@ATIVO", produto.Ativo);
        }
    }
}