using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SerraAirlines.Domain;

namespace SerraAirlines.Infra.Data.DAO
{
    public class ClienteDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=SERRAAIRLINESDB; integrated security=true";

        public void Registrar(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"INSERT INTO Clientes VALUES 
                                    (@cpf, @nome, @sobrenome, @nome_completo, @id_endereco);";
                    ObjectToSql(cliente, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"UPDATE Clientes SET nome = @nome, sobrenome = @sobrenome, nome_completo = @nome_completo
                    WHERE cpf = @cpf;";

                    command.CommandText = sql;
                    ObjectToSql(cliente, command);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"DELETE FROM Clientes WHERE cpf = @cpf;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@cpf", cliente.Cpf);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Cliente BuscarPorCpf(string cpf)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT c.*, e.* FROM Clientes c
                                    JOIN Enderecos e ON (c.id_endereco = e.id_endereco)
                                    WHERE cpf = @cpf;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@cpf", cpf);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Cliente cliente = SqlToObject(reader);
                        return cliente;
                    }
                }
            }
            return null;
        }

        public List<Cliente> BuscarTodos()
        {
            List<Cliente> listaClientes = new List<Cliente>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT c.*, e.* FROM Clientes c
                                    JOIN Enderecos e ON (c.id_endereco = e.id_endereco);";
                    command.CommandText = sql;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listaClientes.Add(SqlToObject(reader));
                    }
                }
            }
            return listaClientes;
        }

        public Cliente SqlToObject(SqlDataReader reader)
        {
            Cliente cliente = new Cliente();

            cliente.Cpf = reader["cpf"].ToString();
            cliente.Nome = reader["nome"].ToString();
            cliente.Sobrenome = reader["sobrenome"].ToString();

            cliente.Endereco.Id = Convert.ToInt32(reader["id_endereco"]);
            cliente.Endereco.Cep = reader["cep"].ToString();
            cliente.Endereco.Rua = reader["rua"].ToString();
            cliente.Endereco.Bairro = reader["bairro"].ToString();
            cliente.Endereco.Numero = Convert.ToInt32(reader["numero"]);
            cliente.Endereco.Complemento = reader["complemento"] as string;

            return cliente;
        }

        public void ObjectToSql(Cliente cliente, SqlCommand command)
        {
            command.Parameters.AddWithValue("@cpf", cliente.Cpf);
            command.Parameters.AddWithValue("@nome", cliente.Nome);
            command.Parameters.AddWithValue("@sobrenome", cliente.Sobrenome);
            command.Parameters.AddWithValue("@nome_completo", cliente.NomeCompleto);
            command.Parameters.AddWithValue("@id_endereco", cliente.Endereco.Id);
        }
    }
}