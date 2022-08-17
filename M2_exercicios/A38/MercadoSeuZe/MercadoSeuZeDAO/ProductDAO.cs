using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MercadoSeuZeDAO
{
    public class ProductDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=MERCADOSEUZEDB; integrated security=true";

        public void InsertIntoProducts(Product product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"IN@produto_idT INTO Produtos VALUES 
                                    (@nome, @descricao, @data_vencimento, @preco_unitario, @unidade, @quantidade_estoque);";
                    ObjectToSql(product, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateProducts(Product modifiedProduct)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"UPDATE Produtos SET nome = @nome, descricao = @descricao, data_vencimento = @data_vencimento, preco_unitario = @preco_unitario, unidade = @unidade, quantidade_estoque = @quantidade_estoque WHERE produto_id = @produto_id;";
                    ObjectToSql(modifiedProduct, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteFromProductsById(Product product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"DELETE FROM Produtos WHERE produto_id = @produto_id;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@produto_id", product.ProductId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Product> ViewAllProducts()
        {
            List<Product> productList = new List<Product>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Produtos";
                    command.CommandText = sql;
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        productList.Add(SqlToObject(reader));
                    }
                }
            }
            return productList;
        }

        public Product ViewProductById(string product_id)
        {
            Product searchedProduct = new Product();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Produtos WHERE produto_id = @produto_id;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@produto_id", product_id);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        searchedProduct = SqlToObject(reader);
                    }
                }
            }
            return searchedProduct;
        }

        public List<Product> ViewProductByDescription(string description)
        {
            List<Product> searchedProducts = new List<Product>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Produtos WHERE descricao LIKE '%' + @descricao +'%';";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@descricao", description);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Product product = SqlToObject(reader);
                        searchedProducts.Add(product);
                    }
                }
            }
            return searchedProducts;
        }

        public Product SqlToObject(SqlDataReader reader)
        {
            Product newProduct = new Product();

            newProduct.ProductId = Convert.ToInt32(reader["produto_id"]);
            newProduct.Name = reader["nome"].ToString();
            newProduct.Description = reader["descricao"].ToString();
            newProduct.ExpirationDate = Convert.ToDateTime(reader["data_vencimento"]);
            newProduct.UnitPrice = Convert.ToDouble(reader["preco_unitario"]);
            newProduct.Unit = reader["unidade"].ToString();
            newProduct.Quantity = Convert.ToInt32(reader["quantidade_estoque"]);

            return newProduct;
        }

        public void ObjectToSql(Product product, SqlCommand command)
        {
            command.Parameters.AddWithValue("@produto_id", product.ProductId);
            command.Parameters.AddWithValue("@nome", product.Name);
            command.Parameters.AddWithValue("@descricao", product.Description);
            command.Parameters.AddWithValue("@data_vencimento", product.ExpirationDate);
            command.Parameters.AddWithValue("@preco_unitario", product.UnitPrice);
            command.Parameters.AddWithValue("@unidade", product.Unit);
            command.Parameters.AddWithValue("@quantidade_estoque", product.Quantity);
        }
    }
}
