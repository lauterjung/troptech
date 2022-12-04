using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TropPizza.Domain.Features.Products;

namespace TropPizza.Infra.Data.DAO
{
    public class InventoryProductDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=TROPPIZZADB; integrated security=true";

        public void Create(InventoryProduct inventoryProduct)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"INSERT INTO InventoryProducts VALUES 
                                    (@product_name, @product_description, @is_active, @expiration_date, @quantity, @unit_price, @is_visible, @image_name, @has_image);";
                    ObjectToSql(inventoryProduct, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public InventoryProduct ReadById(Int64 id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM InventoryProducts
                                    WHERE product_id = @product_id;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@product_id", id);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        InventoryProduct inventoryProduct = SqlToObject(reader);
                        return inventoryProduct;
                    }
                }
            }
            return null;
        }

        public InventoryProduct ReadUnique(string name, string description, DateTime expirationDate)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM InventoryProducts
                                    WHERE product_name = @product_name AND product_description = @product_description AND expiration_date = @expiration_date;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@product_name", name);
                    command.Parameters.AddWithValue("@product_description", description);
                    command.Parameters.AddWithValue("@expiration_date", expirationDate.Date);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        InventoryProduct inventoryProduct = SqlToObject(reader);
                        return inventoryProduct;
                    }
                }
            }
            return null;
        }

        public List<InventoryProduct> ReadAll()
        {
            List<InventoryProduct> ProductsList = new List<InventoryProduct>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM InventoryProducts";
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

        public List<InventoryProduct> ReadVisible()
        {
            List<InventoryProduct> ProductsList = new List<InventoryProduct>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM InventoryProducts
                    WHERE is_visible = 1";
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

        public void Update(InventoryProduct inventoryProduct)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"UPDATE InventoryProducts SET 
                    product_name = @product_name, product_description = @product_description, is_active = @is_active, expiration_date = @expiration_date, quantity = @quantity, unit_price = @unit_price, is_visible = @is_visible, image_name= @image_name, has_image=@has_image
                    WHERE product_id = @product_id;";

                    command.CommandText = sql;
                    ObjectToSql(inventoryProduct, command);
                    command.Parameters.AddWithValue("@product_id", inventoryProduct.Id);

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
                    string sql = @"DELETE FROM InventoryProducts WHERE product_id = @product_id;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@product_id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public InventoryProduct SqlToObject(SqlDataReader reader)
        {
            InventoryProduct inventoryProduct = new InventoryProduct();

            inventoryProduct.Id = Convert.ToInt64(reader["product_id"]);
            inventoryProduct.Name = reader["product_name"].ToString();
            inventoryProduct.Description = reader["product_description"].ToString();
            inventoryProduct.IsActive = Convert.ToBoolean(reader["is_active"]);
            inventoryProduct.ExpirationDate = Convert.ToDateTime(reader["expiration_date"]);
            inventoryProduct.Quantity = Convert.ToInt32(reader["quantity"]);
            inventoryProduct.UnitPrice = Convert.ToDouble(reader["unit_price"]);
            inventoryProduct.ImageName = reader["image_name"] as string;

            return inventoryProduct;
        }

        public void ObjectToSql(InventoryProduct inventoryProduct, SqlCommand command)
        {
            command.Parameters.AddWithValue("@product_name", inventoryProduct.Name);
            command.Parameters.AddWithValue("@product_description", inventoryProduct.Description);
            command.Parameters.AddWithValue("@is_active", inventoryProduct.IsActive);
            command.Parameters.AddWithValue("@expiration_date", inventoryProduct.ExpirationDate);
            command.Parameters.AddWithValue("@quantity", inventoryProduct.Quantity);
            command.Parameters.AddWithValue("@unit_price", inventoryProduct.UnitPrice);
            command.Parameters.AddWithValue("@is_visible", inventoryProduct.IsVisible);
            command.Parameters.AddWithValue("@image_name", (inventoryProduct.ImageName != null) ? inventoryProduct.ImageName : DBNull.Value);
            command.Parameters.AddWithValue("@has_image", inventoryProduct.HasImage);
        }
    }
}