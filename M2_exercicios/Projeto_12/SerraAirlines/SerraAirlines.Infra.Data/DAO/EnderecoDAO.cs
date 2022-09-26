using System;
using System.Data.SqlClient;
using SerraAirlines.Domain;

namespace SerraAirlines.Infra.Data.DAO
{
    public class EnderecoDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=SERRAAIRLINESDB; integrated security=true";

        public void Registrar(Endereco endereco)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"INSERT INTO Enderecos VALUES 
                                    (@cep, @rua, @bairro, @numero, @complemento);";
                    ObjectToSql(endereco, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public Endereco BuscarPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT *
                                    FROM Enderecos
                                    WHERE id_endereco = @id_endereco;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@id_endereco", id);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Endereco endereco = SqlToObject(reader);
                        return endereco;
                    }
                }
            }
            return null;
        }

        public void Atualizar(Endereco endereco)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"UPDATE Enderecos 
                    SET cep = @cep, rua = @rua, bairro = @bairro, numero = @numero, complemento = @complemento 
                    WHERE id_endereco = @id_endereco;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@id_endereco", endereco.Id);

                    ObjectToSql(endereco, command);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(Endereco endereco)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"DELETE FROM Enderecos WHERE id_endereco = @id_endereco;";

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@id_endereco", endereco.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public int RetornarUltimaKey()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT IDENT_CURRENT('Enderecos') AS 'ultima_key';";

                    command.CommandText = sql;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        return Convert.ToInt32(reader["ultima_key"]);
                    }
                }
            }
            return 0;
        }

        public Endereco SqlToObject(SqlDataReader reader)
        {
            Endereco endereco = new Endereco();

            endereco.Cep = reader["cep"].ToString();
            endereco.Rua = reader["rua"].ToString();
            endereco.Bairro = reader["bairro"].ToString();
            endereco.Numero = Convert.ToInt32(reader["numero"]);
            endereco.Complemento = reader["complemento"] as string;

            return endereco;
        }

        public void ObjectToSql(Endereco endereco, SqlCommand command)
        {
            command.Parameters.AddWithValue("@cep", endereco.Cep);
            command.Parameters.AddWithValue("@rua", endereco.Rua);
            command.Parameters.AddWithValue("@bairro", endereco.Bairro);
            command.Parameters.AddWithValue("@numero", endereco.Numero);
            command.Parameters.AddWithValue("@complemento", (endereco.Complemento is null) ? DBNull.Value : endereco.Cep);
        }
    }
}