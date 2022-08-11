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

        public static void InsertIntoTable(string table, string produto, string descricao, string dataValidade, string preco, string unidade, string quantidadeEstoque)
        {
            string connectionString = "server=.\\SQLexpress; initial catalog=MERCADOSEUZEDB; integrated security=true";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string insertConcat = "INSERT INTO " +
                                  table +
                                  " VALUES (" +
                                  "'" + produto + "'" + ", " +
                                  "'" + descricao + "'" + ", " +
                                  "'" + dataValidade + "'" + ", " +
                                  preco + ", " +
                                  "'" + unidade + "'" + ", " +
                                  quantidadeEstoque +
                                  ");";

            SqlCommand insertCommand = new SqlCommand(insertConcat, connection);
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateTable(string table, string column, string newValue, string produtoId)
        {
            string connectionString = "server=.\\SQLexpress; initial catalog=MERCADOSEUZEDB; integrated security=true";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string updateConcat = "UPDATE " +
                  table +
                  " SET " +
                  column +
                  " = " + newValue +
                  " WHERE produto_id = " + produtoId + ";";

            SqlCommand updateCommand = new SqlCommand(updateConcat, connection);
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteFromTable(string table, string produtoId)
        {
            string connectionString = "server=.\\SQLexpress; initial catalog=MERCADOSEUZEDB; integrated security=true";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string deleteConcat = "DELETE FROM " +
                  table +
                  " WHERE produto_id = " + produtoId + ";";

            SqlCommand deleteCommand = new SqlCommand(deleteConcat, connection);
            deleteCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static void ProductReaderToConsole(SqlDataReader reader)
        {
            if (reader.Read() == false)
            {
                System.Console.WriteLine("Não encontrei o valor procurado!");
            }

            while (reader.Read())
            {
                var produto = reader[0];
                var descricao = reader[1];
                var data_validade = reader[2];
                var preco_unitario = reader[3];
                var unidade = reader[4];
                var quantidade_estoque = reader[5];
                System.Console.WriteLine($"{produto} - {descricao} - {data_validade} - {preco_unitario} - {unidade} - {quantidade_estoque}");
            }
        }

        public static void ViewAllProducts()
        {
            string connectionString = "server=.\\SQLexpress; initial catalog=MERCADOSEUZEDB; integrated security=true";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(@"SELECT * FROM Produtos", connection);
            SqlDataReader reader = command.ExecuteReader();

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
            connection.Close();
        }

        public static void ViewProductById(string product_id)
        {

            connection.Open();

            StringBuilder SbSql = new StringBuilder();
            SbSql.Append("SELECT * FROM Produtos WHERE produto_id = ");
            SbSql.Append(product_id);
            SbSql.Append(";");

            SqlCommand command = new SqlCommand(SbSql.ToString(), connection);
            SqlDataReader reader = command.ExecuteReader();

            ProductReaderToConsole(reader);
            connection.Close();
        }

        public static void ViewProductByDescription(string descricao)
        {
            string connectionString = "server=.\\SQLexpress; initial catalog=MERCADOSEUZEDB; integrated security=true";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            StringBuilder SbSql = new StringBuilder();
            SbSql.Append("SELECT * FROM Produtos WHERE descricao = '");
            SbSql.Append(descricao);
            SbSql.Append("';");

            SqlCommand command = new SqlCommand(SbSql.ToString(), connection);
            SqlDataReader reader = command.ExecuteReader();

            ProductReaderToConsole(reader);
            connection.Close();
        }

        public static void ConsoleAddProduct()
        {
            System.Console.Write("Digite o nome: ");
            string product = Console.ReadLine();
            System.Console.Write("Digite a descricao: ");
            string description = Console.ReadLine();
            System.Console.Write("Digite a data de validade (AAAA-MM-DD): ");
            string expirationDate = Console.ReadLine();
            System.Console.Write("Digite o preço: ");
            string price = Console.ReadLine();
            System.Console.Write("Digite a unidade: ");
            string unit = Console.ReadLine();
            System.Console.Write("Digite a quantidade em estoque: ");
            string stockQuantity = Console.ReadLine();

            InsertIntoTable("Produtos", product, description, expirationDate, price, unit, stockQuantity);
        }
    }
}
