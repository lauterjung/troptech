using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace MercadoSeuZeDAO
{
    public static class ProductDAO
    {
        public static string connectionString = "server=.\\SQLexpress; initial catalog=MERCADOSEUZEDB; integrated security=true";
        public static SqlConnection connection = new SqlConnection(connectionString);

        public static void ProductReaderToConsole(SqlDataReader reader)
        {
            if (reader.HasRows == false)
            {
                System.Console.WriteLine("Não encontrei o valor procurado!");
            }

            while (reader.Read())
            {
                string id = Convert.ToString(reader[0]);
                string produto = Convert.ToString(reader[1]);
                string descricao = Convert.ToString(reader[2]);
                string data_validade = Convert.ToDateTime(reader[3]).ToShortDateString();
                double preco_unitario = Convert.ToDouble(reader[4]);
                string unidade = Convert.ToString(reader[5]);
                int quantidade_estoque = Convert.ToInt32(reader[6]);
                System.Console.WriteLine($"{id} - {produto} - {descricao} - {data_validade} - {preco_unitario} - {unidade} - {quantidade_estoque}");
            }
        }
        public static void InsertIntoProducts(string produto, string descricao, string dataValidade, string preco, string unidade, string quantidadeEstoque)
        {
            connection.Open();

            string insertConcat = @"INSERT INTO Produtos VALUES 
                                    (@PRODUTO, @DESCRICAO, @DATA_VALIDADE, @PRECO, @UNIDADE, @QUANTIDADE_ESTOQUE);";

            SqlCommand insertCommand = new SqlCommand(insertConcat, connection);
            insertCommand.Parameters.AddWithValue("@PRODUTO", produto);
            insertCommand.Parameters.AddWithValue("@DESCRICAO", descricao);
            insertCommand.Parameters.AddWithValue("@DATA_VALIDADE", dataValidade);
            insertCommand.Parameters.AddWithValue("@PRECO", preco);
            insertCommand.Parameters.AddWithValue("@UNIDADE", unidade);
            insertCommand.Parameters.AddWithValue("@QUANTIDADE_ESTOQUE", quantidadeEstoque);

            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateProducts(string product_id, string produto, string descricao, string dataValidade, string preco, string unidade, string quantidadeEstoque)
        {
            connection.Open();

            SqlCommand updateCommand = new SqlCommand(@"UPDATE Produtos SET nome = @PRODUTO, descricao = @DESCRICAO, data_vencimento = @DATA_VALIDADE, preco_unitario = @PRECO, unidade = @UNIDADE, quantidade_estoque = @QUANTIDADE_ESTOQUE WHERE produto_id = @PRODUTO_ID;", connection);
            updateCommand.Parameters.AddWithValue("@PRODUTO", produto);
            updateCommand.Parameters.AddWithValue("@DESCRICAO", descricao);
            updateCommand.Parameters.AddWithValue("@DATA_VALIDADE", dataValidade);
            updateCommand.Parameters.AddWithValue("@PRECO", preco);
            updateCommand.Parameters.AddWithValue("@UNIDADE", unidade);
            updateCommand.Parameters.AddWithValue("@QUANTIDADE_ESTOQUE", quantidadeEstoque);
            updateCommand.Parameters.AddWithValue("@PRODUTO_ID", product_id);

            updateCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteFromProductsById(string productId)
        {
            connection.Open();

            SqlCommand deleteCommand = new SqlCommand(@"DELETE FROM Produtos WHERE produto_id = @PRODUTO_ID;", connection);
            deleteCommand.Parameters.AddWithValue("@PRODUTO_ID", productId);
            
            deleteCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static void ViewAllProducts()
        {
            connection.Open();

            SqlCommand command = new SqlCommand(@"SELECT * FROM Produtos", connection);
            SqlDataReader reader = command.ExecuteReader();

            ProductReaderToConsole(reader);
            connection.Close();
        }

        public static void ViewProductById(string product_id)
        {
            connection.Open();

            SqlCommand command = new SqlCommand(@"SELECT * FROM Produtos WHERE produto_id = @PRODUTO_ID", connection);
            command.Parameters.AddWithValue("@PRODUTO_ID", product_id);
            SqlDataReader reader = command.ExecuteReader();

            ProductReaderToConsole(reader);
            connection.Close();
        }

        public static void ViewProductByDescription(string description)
        {
            connection.Open();

            SqlCommand command = new SqlCommand(@"SELECT * FROM Produtos WHERE descricao LIKE '%' + @DESCRICAO +'%';", connection);
            command.Parameters.AddWithValue("@DESCRICAO", description);
            SqlDataReader reader = command.ExecuteReader();

            ProductReaderToConsole(reader);
            connection.Close();
        }
    }
}
