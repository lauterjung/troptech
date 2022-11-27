using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TropPizza.Domain.Features.Orders;
using TropPizza.Domain.Features.Products;
using TropPizza.Domain.Features.Orders.Enums;

namespace TropPizza.Infra.Data.DAO
{
    public class OrderProductsDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=TROPPIZZADB; integrated security=true";

        public void Create(Int64 orderId, Int64 productId, Int32 productQuantity, Double productTotalPrice)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"INSERT INTO OrderProducts VALUES 
                                    (@order_id, @product_id, @quantity, @total_price);";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@order_id", orderId);
                    command.Parameters.AddWithValue("@product_id", productId);
                    command.Parameters.AddWithValue("@quantity", productQuantity);
                    command.Parameters.AddWithValue("@total_price", productTotalPrice);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Product> ReadAll(Int64 id)
        {
            List<Product> productsList = new List<Product>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT p.product_id, p.product_name, p.unit_price, op.quantity, op.total_price
                    FROM OrderProducts op
                    JOIN Orders o ON(op.order_id = o.order_id)
                    JOIN Products p ON(op.product_id = p.product_id)
                        WHERE op.order_id = @order_id";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@order_id", id);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        productsList.Add(SqlToObject(reader));
                    }
                }
            }
            return productsList;
        }

        public void Delete(Int64 id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"DELETE FROM OrderProducts WHERE order_id = @order_id;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@order_id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Product SqlToObject(SqlDataReader reader)
        {
            Product product = new Product();

            product.Id = Convert.ToInt64(reader["product_id"]);;
            product.Name = reader["product_name"].ToString();
            product.UnitPrice = Convert.ToDouble(reader["unit_price"]);

            product.Quantity = Convert.ToInt32(reader["quantity"]);
            // product.TotalPrice = Convert.ToDouble(reader["total_price"]);

            return product;
        }
    }
}