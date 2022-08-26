using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Globalization;

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
                                    (@cpf, @nome, @data_nascimento, @pontos_fidelidade, @rua, @numero_da_casa, @bairro, @cep, @complemento);";
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

        public void UpdateClientFidelityPoints(double fidelityPoints, string cpf)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"UPDATE Clientes SET pontos_fidelidade = @pontos_fidelidade WHERE cpf = @cpf;";

                    command.Parameters.AddWithValue("@cpf", cpf);
                    command.Parameters.AddWithValue("@pontos_fidelidade", fidelityPoints);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteClientById(Client client)
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



        public List<Client> SearchAllClients()
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

        public double SearchClientFidelityPointsByCpf(string cpf)
        {
            double searchedFidelityPoints = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT pontos_fidelidade FROM Clientes WHERE cpf = @cpf;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@cpf", cpf);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        searchedFidelityPoints = Convert.ToDouble(reader["pontos_fidelidade"]);
                    }
                }
            }
            return searchedFidelityPoints;
        }

        public Client SearchClientByCpf(string cpf)
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

        public List<Client> SearchClientsByName(string name)
        {
            List<Client> searchedClients = new List<Client>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Clientes WHERE nome LIKE '%' + LOWER(@nome) +'%';";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@nome", name.ToLower());

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
            newClient.Name = reader["nome"].ToString();
            newClient.BirthDate = Convert.ToDateTime(reader["data_nascimento"], CultureInfo.InvariantCulture);
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
            command.Parameters.AddWithValue("@nome", client.Name);
            command.Parameters.AddWithValue("@data_nascimento", client.BirthDate);
            command.Parameters.AddWithValue("@pontos_fidelidade", client.FidelityPoints);
            command.Parameters.AddWithValue("@rua", client.ClientAddress.Street);
            command.Parameters.AddWithValue("@numero_da_casa", client.ClientAddress.HouseNumber);
            command.Parameters.AddWithValue("@bairro", client.ClientAddress.Borough);
            command.Parameters.AddWithValue("@cep", client.ClientAddress.PostalCode);
            command.Parameters.AddWithValue("@complemento", String.IsNullOrEmpty(client.ClientAddress.Complement) ? DBNull.Value : client.ClientAddress.Complement);
        }
    }
}
