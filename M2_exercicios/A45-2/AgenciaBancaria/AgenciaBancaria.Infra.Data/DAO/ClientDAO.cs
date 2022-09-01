using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AgenciaBancaria.Domain;

namespace AgenciaBancaria.Infra.Data.DAO
{
    public class ClientDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=AGENCIABANCARIADB; integrated security=true";

        public List<Client> SearchAllClients()
        {
            List<Client> clientList = new List<Client>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT *
                                    FROM Clientes;";
                    command.CommandText = sql;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        clientList.Add(SqlToObject(reader));
                    }
                }
            }
            return clientList;
        }

        public Client SearchClientById(string cpf)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT *
                                    FROM Clientes
                                    WHERE cpf = @cpf;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@cpf", cpf);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Client client = SqlToObject(reader);
                        return client;
                    }
                }
            }
            return null;
        }
        
        public Client SqlToObject(SqlDataReader reader)
        {
            Client client = new Client();

            client.Cpf = reader["cpf"].ToString();
            client.Name = reader["nome"].ToString();
            client.BirthDate = Convert.ToDateTime(reader["data_nascimento"]);

            return client;
        }

        public void ObjectToSql(Client client, SqlCommand command)
        {
            command.Parameters.AddWithValue("@cpf", client.Cpf);
            command.Parameters.AddWithValue("@nome", client.Name);
            command.Parameters.AddWithValue("@data_nascimento", client.BirthDate);
        }
    }
}