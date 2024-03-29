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
                                    (@cpf, @full_name, @birth_date, @customer_address, @fidelity_points);";
                    ObjectToSql(customer, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public Customer ReadById(Int64 id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Customers
                                    WHERE customer_id = @customer_id;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@customer_id", id);

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

        public Customer ReadByCpf(string cpf)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Customers
                                    WHERE cpf = @cpf;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@cpf", cpf);

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
                    cpf = @cpf, full_name = @full_name, birth_date = @birth_date, customer_address = @customer_address, fidelity_points = @fidelity_points
                    WHERE customer_id = @customer_id;";

                    command.CommandText = sql;
                    ObjectToSql(customer, command);

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
                    string sql = @"DELETE FROM Customers WHERE customer_id = @customer_id;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@customer_id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Customer SqlToObject(SqlDataReader reader)
        {
            Customer customer = new Customer();

            customer.Id = Convert.ToInt64(reader["customer_id"]);
            customer.Cpf = reader["cpf"].ToString();
            customer.FullName = reader["full_name"].ToString();
            customer.BirthDate = Convert.ToDateTime(reader["birth_date"]);
            customer.Address = reader["customer_address"].ToString();
            customer.FidelityPoints = Convert.ToDouble(reader["fidelity_points"]);

            return customer;
        }

        public void ObjectToSql(Customer customer, SqlCommand command)
        {
            command.Parameters.AddWithValue("@customer_id", customer.Id);
            command.Parameters.AddWithValue("@cpf", customer.Cpf);
            command.Parameters.AddWithValue("@full_name", customer.FullName);
            command.Parameters.AddWithValue("@birth_date", customer.BirthDate);
            command.Parameters.AddWithValue("@customer_address", customer.Address);
            command.Parameters.AddWithValue("@fidelity_points", customer.FidelityPoints);
        }
    }
}