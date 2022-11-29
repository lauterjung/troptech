using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TropPizza.Domain.Features.Customers;
using TropPizza.Domain.Features.Orders;
using TropPizza.Domain.Features.Orders.Enums;

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
                                    (@order_status_id, @customer_id, @order_date_time);";
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
                    string sql = @"SELECT o.order_id, o.order_status_id, o.customer_id, o.order_date_time, c.cpf
                    FROM Orders o
                    LEFT JOIN Customers c ON (o.customer_id = c.customer_id)
                    WHERE o.order_id = @order_id;";
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

        public List<Order> ReadUnfinishedOrders(Int64 customerId)
        {
            List<Order> ordersList = new List<Order>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT o.order_id, o.order_status_id, o.customer_id, o.order_date_time, c.cpf
                    FROM Orders o
                    LEFT JOIN Customers c ON (o.customer_id = c.customer_id)
                    WHERE o.customer_id = @customer_id AND o.order_status_id <> 3;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@customer_id", customerId);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ordersList.Add(SqlToObject(reader));
                    }
                }
            }
            return ordersList;
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
                    string sql = @"SELECT o.order_id, o.order_status_id, o.customer_id, o.order_date_time, c.cpf
                    FROM Orders o
                    LEFT JOIN Customers c ON (o.customer_id = c.customer_id);";
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
                    order_status_id = @order_status_id, customer_id = @customer_id, order_date_time = @order_date_time
                    WHERE o.order_id = @order_id;";

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
                    string sql = @"DELETE FROM Orders WHERE order_id = @order_id;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@order_id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public int GetLastKey()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT IDENT_CURRENT('Orders') AS 'last_key';";

                    command.CommandText = sql;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        return Convert.ToInt32(reader["last_key"]);
                    }
                }
            }
            return 0;
        }

        public Order SqlToObject(SqlDataReader reader)
        {
            Order order = new Order();

            order.Id = Convert.ToInt64(reader["order_id"]);
            order.Status = (OrderStatus)Convert.ToInt16(reader["order_status_id"]);
            order.OrderDateTime = Convert.ToDateTime(reader["order_date_time"]);

            if (reader["customer_id"] != DBNull.Value)
            {
                order.OrderCustomer = new Customer();
                order.OrderCustomer.Id = Convert.ToInt64(reader["customer_id"]);
                order.OrderCustomer.Cpf = reader["cpf"].ToString();
            }

            return order;
        }

        public void ObjectToSql(Order order, SqlCommand command)
        {
            command.Parameters.AddWithValue("@order_status_id", (Int16)order.Status);
            command.Parameters.AddWithValue("@customer_id", (order.OrderCustomer != null) ? order.OrderCustomer.Id : DBNull.Value);
            command.Parameters.AddWithValue("@order_date_time", order.OrderDateTime);
        }
    }
}