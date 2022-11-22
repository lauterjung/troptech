using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TropPizza.Domain.Features.Customers;

namespace TropPizza.Infra.Data.DAO
{
    public class CustomerDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=TROPPIZZADB; integrated security=true";

        public void Create(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"INSERT INTO Customers VALUES 
                                    (@client_id, @full_name, @birth_date, @client_address, @fidelity_points, @has_fidelity_discount);";
                    ObjectToSql(customer, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public Customer ReadById(string id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Customers
                                    WHERE client_id = @client_id;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@client_id", id);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Customer customer = SqlToObject(reader);
                        return customer;
                    }
                }
            }
            return null;
        }

        public List<Customer> ReadAll()
        {
            List<Customer> customersList = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Customers";
                    command.CommandText = sql;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        customersList.Add(SqlToObject(reader));
                    }
                }
            }
            return customersList;
        }

        public void Update(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"UPDATE Customers SET 
                    client_id = @client_id, full_name = @full_name, birth_date = @birth_date, client_address = @client_address, fidelity_points = @fidelity_points, has_fidelity_discount = @has_fidelity_discount
                    WHERE client_id = @client_id;";

                    command.CommandText = sql;
                    ObjectToSql(customer, command);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"DELETE FROM Customers WHERE client_id = @client_id;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@client_id", customer.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Customer SqlToObject(SqlDataReader reader)
        {
            Customer customer = new Customer();

            customer.Id = reader["client_id"].ToString();
            customer.FullName = reader["full_name"].ToString();
            customer.BirthDate = Convert.ToDateTime(reader["birth_date"]);
            customer.Address = reader["client_address"].ToString();
            customer.FidelityPoints = Convert.ToInt32(reader["fidelity_points"]);

            return customer;
        }

        public void ObjectToSql(Customer customer, SqlCommand command)
        {
            command.Parameters.AddWithValue("@client_id", customer.Id);
            command.Parameters.AddWithValue("@full_name", customer.FullName);
            command.Parameters.AddWithValue("@birth_date", customer.BirthDate);
            command.Parameters.AddWithValue("@client_address", customer.Address);
            command.Parameters.AddWithValue("@fidelity_points", customer.FidelityPoints);
            command.Parameters.AddWithValue("@has_fidelity_discount", customer.HasFidelityDiscount);
        }
    }
}