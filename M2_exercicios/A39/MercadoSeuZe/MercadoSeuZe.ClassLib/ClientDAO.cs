using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MercadoSeuZe.ClassLib
{
    public class ClientDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=MERCADOSEUZEDB; integrated security=true";

        public void AddClient(Client client)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"INSERT INTO Clientes VALUES 
                                    (@cpf, @data_nascimento, @pontos_fidelidade, @rua, @numero_da_casa, @bairro, @cep, @complemento);";
                    ObjectToSql(client, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateClient(Client modifiedClient)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"UPDATE Clientes SET cpf = @cpf, data_nascimento = @data_nascimento, pontos_fidelidade = @pontos_fidelidade, rua = @rua, numero_da_casa = @numero_da_casa, bairro = @bairro, cep = @cep, complemento = @complemento WHERE cpf = @cpf;";
                    ObjectToSql(modifiedClient, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteFromClientssById(Client client)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"DELETE FROM Clientes WHERE cpf = @cpf;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@cpf", client.Cpf);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Client> ViewAllClients()
        {
            List<Client> clientList = new List<Client>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Clientes";
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

        public Client ViewClientByCpf(string cpf)
        {
            Client searchedClient = new Client();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Clientes WHERE cpf = @cpf;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@cpf", cpf);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        searchedClient = SqlToObject(reader);
                    }
                }
            }
            return searchedClient;
        }

        public List<Client> ViewClientByName(string name)
        {
            List<Client> searchedClients = new List<Client>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Clientes WHERE nome LIKE '%' + @nome +'%';";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@nome", name);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Client client = SqlToObject(reader);
                        searchedClients.Add(client);
                    }
                }
            }
            return searchedClients;
        }

        public Client SqlToObject(SqlDataReader reader)
        {
            Client newClient = new Client();

            newClient.Cpf = reader["cpf"].ToString();
            newClient.BirthDate = Convert.ToDateTime(reader["data_nascimento"]);
            newClient.FidelityPoints = String.IsNullOrEmpty(reader["pontos_fidelidade"].ToString()) ? 0 : Convert.ToDouble(reader["pontos_fidelidade"]);
            newClient.ClientAddress = new Address()
            {
                Street = reader["rua"].ToString(),
                HouseNumber = Convert.ToInt32(reader["numero_da_casa"]),
                Borough = reader["bairro"].ToString(),
                PostalCode = reader["cep"].ToString(),
                Complement = String.IsNullOrEmpty(reader["complemento"].ToString()) ? "" : reader["complemento"].ToString()
            };
            return newClient;
        }

        public void ObjectToSql(Client client, SqlCommand command)
        {
            command.Parameters.AddWithValue("@cpf", client.Cpf);
            command.Parameters.AddWithValue("@data_nascimento", client.BirthDate);
            command.Parameters.AddWithValue("@pontos_fidelidade", client.FidelityPoints);
            command.Parameters.AddWithValue("@rua", client.ClientAddress.Street);
            command.Parameters.AddWithValue("@numero_da_casa", client.ClientAddress.HouseNumber);
            command.Parameters.AddWithValue("@bairro", client.ClientAddress.Borough);
            command.Parameters.AddWithValue("@cep", client.ClientAddress.PostalCode);
            command.Parameters.AddWithValue("@complemento", client.ClientAddress.Complement);
        }
    }
}
