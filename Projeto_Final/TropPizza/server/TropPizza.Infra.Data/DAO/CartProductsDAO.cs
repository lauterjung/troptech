using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TropPizza.Domain.Features.Products;

namespace TropPizza.Infra.Data.DAO
{
    public class CartProductsDAO
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
                    string sql = @"INSERT INTO CartProducts VALUES 
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

        public List<CartProduct> ReadAll(Int64 id)
        {
            List<CartProduct> productsList = new List<CartProduct>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT p.product_id, p.product_name, p.product_description, p.unit_price, op.quantity, op.total_price
                    FROM CartProducts op
                    JOIN Orders o ON(op.order_id = o.order_id)
                    JOIN InventoryProducts p ON(op.product_id = p.product_id)
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
                    string sql = @"DELETE FROM CartProducts WHERE order_id = @order_id;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@order_id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public CartProduct SqlToObject(SqlDataReader reader)
        {
            CartProduct cartProduct = new CartProduct();

            cartProduct.Id = Convert.ToInt64(reader["product_id"]);;
            cartProduct.Name = reader["product_name"].ToString();
            cartProduct.Description = reader["product_description"].ToString();
            cartProduct.UnitPrice = Convert.ToDouble(reader["unit_price"]);
            cartProduct.Quantity = Convert.ToInt32(reader["quantity"]);
            
            return cartProduct;
        }
    }
}