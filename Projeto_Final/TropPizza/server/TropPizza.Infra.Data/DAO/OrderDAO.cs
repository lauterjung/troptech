using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TropPizza.Domain.Features.Orders;

namespace TropPizza.Infra.Data.DAO
{
    public class OrderDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=TROPPIZZADB; integrated security=true";

        public void Create(Order order)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"INSERT INTO Orders VALUES 
                                    (@cpf, @full_name, @birth_date, @Order_address, @fidelity_points);";
                    ObjectToSql(order, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public Order ReadById(Int64 id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Orders
                                    WHERE order_id = @order_id;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@order_id", id);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Order order = SqlToObject(reader);
                        return order;
                    }
                }
            }
            return null;
        }

        public List<Order> ReadAll()
        {
            List<Order> ordersList = new List<Order>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Orders";
                    command.CommandText = sql;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ordersList.Add(SqlToObject(reader));
                    }
                }
            }
            return ordersList;
        }

        public void Update(Order order)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"UPDATE Orders SET 
                    cpf = @cpf, full_name = @full_name, birth_date = @birth_date, Order_address = @Order_address, fidelity_points = @fidelity_points
                    WHERE Order_id = @Order_id;";

                    command.CommandText = sql;
                    ObjectToSql(order, command);

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
                    string sql = @"DELETE FROM Orders WHERE Order_id = @Order_id;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@Order_id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Order SqlToObject(SqlDataReader reader)
        {
            Order order = new Order();

            order.Id = Convert.ToInt64(reader["Order_id"]);
            order.Cpf = reader["cpf"].ToString();
            order.FullName = reader["full_name"].ToString();
            order.BirthDate = Convert.ToDateTime(reader["birth_date"]);
            order.Address = reader["Order_address"].ToString();
            order.FidelityPoints = Convert.ToDouble(reader["fidelity_points"]);

            return order;
        }

        public void ObjectToSql(order order, SqlCommand command)
        {
            command.Parameters.AddWithValue("@Order_id", order.Id);
            command.Parameters.AddWithValue("@cpf", order.Cpf);
            command.Parameters.AddWithValue("@full_name", order.FullName);
            command.Parameters.AddWithValue("@birth_date", order.BirthDate);
            command.Parameters.AddWithValue("@Order_address", order.Address);
            command.Parameters.AddWithValue("@fidelity_points", order.FidelityPoints);
            // command.Parameters.AddWithValue("@has_fidelity_discount", order.HasFidelityDiscount);
        }
    }
}