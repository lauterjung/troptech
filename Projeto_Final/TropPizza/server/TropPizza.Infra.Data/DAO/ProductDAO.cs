using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TropPizza.Domain.Features.Products;

namespace TropPizza.Infra.Data.DAO
{
    public class ProductDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=TROPPIZZADB; integrated security=true";

        public void Create(Product product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"INSERT INTO Products VALUES 
                                    (@product_name, @product_description, @is_active, @expiration_date, @quantity, @unit_price, @total_price, @is_visible);";
                    ObjectToSql(product, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public Product ReadById(Int64 id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Products
                                    WHERE product_id = @product_id;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@product_id", id);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Product product = SqlToObject(reader);
                        return product;
                    }
                }
            }
            return null;
        }

        public Product ReadUnique(string name, string description, DateTime expirationDate)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Products
                                    WHERE product_name = @product_name AND product_description = @product_description AND expiration_date = @expiration_date;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@product_name", name);
                    command.Parameters.AddWithValue("@product_description", description);
                    command.Parameters.AddWithValue("@expiration_date", expirationDate.Date);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Product product = SqlToObject(reader);
                        return product;
                    }
                }
            }
            return null;
        }

        public List<Product> ReadAll()
        {
            List<Product> ProductsList = new List<Product>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Products";
                    command.CommandText = sql;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ProductsList.Add(SqlToObject(reader));
                    }
                }
            }
            return ProductsList;
        }

        public void Update(Product product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"UPDATE Products SET 
                    product_name = @product_name, product_description = @product_description, is_active = @is_active, expiration_date = @expiration_date, quantity = @quantity, unit_price = @unit_price, total_price = @total_price, is_visible = @is_visible
                    WHERE product_id = @product_id;";

                    command.CommandText = sql;
                    ObjectToSql(product, command);
                    command.Parameters.AddWithValue("@product_id", product.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Int64 id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"DELETE FROM Products WHERE product_id = @product_id;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@product_id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Product SqlToObject(SqlDataReader reader)
        {
            Product product = new Product();

            product.Id = Convert.ToInt64(reader["product_id"]);
            product.Name = reader["product_name"].ToString();
            product.Description = reader["product_description"].ToString();
            product.IsActive = Convert.ToBoolean(reader["is_active"]);
            product.ExpirationDate = Convert.ToDateTime(reader["expiration_date"]);
            product.Quantity = Convert.ToInt32(reader["quantity"]);
            product.UnitPrice = Convert.ToDouble(reader["unit_price"]);
            product.IsActive = Convert.ToBoolean(reader["is_visible"]);

            return product;
        }

        public void ObjectToSql(Product product, SqlCommand command)
        {
            command.Parameters.AddWithValue("@product_name", product.Name);
            command.Parameters.AddWithValue("@product_description", product.Description);
            command.Parameters.AddWithValue("@is_active", product.IsActive);
            command.Parameters.AddWithValue("@expiration_date", product.ExpirationDate);
            command.Parameters.AddWithValue("@quantity", product.Quantity);
            command.Parameters.AddWithValue("@unit_price", product.UnitPrice);
            command.Parameters.AddWithValue("@total_price", product.TotalPrice);
            command.Parameters.AddWithValue("@is_visible", product.IsVisible);
        }
    }
}