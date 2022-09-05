using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SalaReunioes.Domain;

namespace SalaReunioes.Infra.Data.DAO
{
    public class EmployeeDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=SECRETARIADB; integrated security=true";

        public void AddEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"INSERT INTO Funcionarios VALUES 
                                    (@nome, @cargo, @ramal);";

                    ObjectToSql(employee, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Employee> SearchAllEmployees()
        {
            List<Employee> employeeList = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT *
                                    FROM Funcionarios;";
                    command.CommandText = sql;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        employeeList.Add(SqlToObject(reader));
                    }
                }
            }
            return employeeList;
        }

        internal int GetLastId()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT MAX(funcionario_id) FROM Funcionarios;";
                    command.CommandText = sql;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        return Convert.ToInt32(reader[0]);
                    }
                }
            }
            return 0;
        }

        public Employee SqlToObject(SqlDataReader reader)
        {
            Employee employee = new Employee();

            employee.Id = Convert.ToInt32(reader["funcionario_id"]);
            employee.Name = reader["nome"].ToString();
            employee.Job = reader["cargo"].ToString();
            employee.Phone = reader["ramal"].ToString();

            return employee;
        }

        public void ObjectToSql(Employee employee, SqlCommand command)
        {
            command.Parameters.AddWithValue("@funcionario_id", employee.Id);
            command.Parameters.AddWithValue("@nome", employee.Name);
            command.Parameters.AddWithValue("@cargo", employee.Job);
            command.Parameters.AddWithValue("@ramal", employee.Phone);
        }

        public Employee SearchEmployeeById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT *
                                    FROM Funcionarios
                                    WHERE funcionario_id = @funcionario_id;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@funcionario_id", id.ToString());

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Employee employee = SqlToObject(reader);
                        return employee;
                    }
                }
            }
            return null;
        }
    }
}