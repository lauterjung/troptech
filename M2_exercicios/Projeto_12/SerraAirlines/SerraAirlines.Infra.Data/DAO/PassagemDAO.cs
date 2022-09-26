using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SerraAirlines.Domain;

namespace SerraAirlines.Infra.Data.DAO
{
    public class PassagemDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=SERRAAIRLINESDB; integrated security=true";

        public void Adicionar(Passagem passagem)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"INSERT INTO Passagens VALUES 
                                    (@origem, @destino, @valor, @data_hora_origem, @data_hora_destino, @passagem_vinculada);";
                    ObjectToSql(passagem, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(Passagem passagem)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"UPDATE Passagens SET origem = @origem, destino = @destino, valor = @valor, data_hora_origem = @data_hora_origem, data_hora_destino = @data_hora_destino, passagem_vinculada = @passagem_vinculada
                    WHERE id_passagem = @id_passagem;";

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@id_passagem", passagem.Id);

                    ObjectToSql(passagem, command);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Passagem> BuscarPorData(DateTime dataHora)
        {
            List<Passagem> listaPassagens = new List<Passagem>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Passagens
                                    WHERE CONVERT(DATE, data_hora_origem) = CONVERT(DATE, @data_hora) OR CONVERT(DATE, data_hora_destino) = CONVERT(DATE, @data_hora);";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@data_hora", dataHora);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listaPassagens.Add(SqlToObject(reader));
                    }
                }
            }
            return listaPassagens;
        }

        public Passagem BuscarPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Passagens
                                    WHERE id_passagem = @id;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Passagem passagem = SqlToObject(reader);
                        return passagem;
                    }
                }
            }
            return null;
        }

        public List<Passagem> BuscarPorOrigem(string origem)
        {
            List<Passagem> listaPassagens = new List<Passagem>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Passagens
                                    WHERE LOWER(origem) = LOWER(@origem);";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@origem", origem);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listaPassagens.Add(SqlToObject(reader));
                    }
                }
            }
            return listaPassagens;
        }

        public List<Passagem> BuscarPorDestino(string destino)
        {
            List<Passagem> listaPassagens = new List<Passagem>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Passagens
                                    WHERE LOWER(destino) = LOWER(@destino);";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@destino", destino);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listaPassagens.Add(SqlToObject(reader));
                    }
                }
            }
            return listaPassagens;
        }

        public List<Passagem> BuscarTodas()
        {
            List<Passagem> listaPassagens = new List<Passagem>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Passagens;";
                    command.CommandText = sql;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listaPassagens.Add(SqlToObject(reader));
                    }
                }
            }
            return listaPassagens;
        }

        public Passagem SqlToObject(SqlDataReader reader)
        {
            Passagem passagem = new Passagem();

            passagem.Id = Convert.ToInt32(reader["id_passagem"]);
            passagem.Origem = reader["origem"].ToString();
            passagem.Destino = reader["destino"].ToString();
            passagem.Valor = Convert.ToDouble(reader["valor"]);
            passagem.DataHoraOrigem = Convert.ToDateTime(reader["data_hora_origem"]);
            passagem.DataHoraDestino = Convert.ToDateTime(reader["data_hora_destino"]);
            passagem.EstaVinculada = Convert.ToBoolean(reader["passagem_vinculada"]);

            return passagem;
        }

        public void ObjectToSql(Passagem passagem, SqlCommand command)
        {
            command.Parameters.AddWithValue("@origem", passagem.Origem);
            command.Parameters.AddWithValue("@destino", passagem.Destino);
            command.Parameters.AddWithValue("@valor", passagem.Valor);
            command.Parameters.AddWithValue("@data_hora_origem", passagem.DataHoraOrigem);
            command.Parameters.AddWithValue("@data_hora_destino", passagem.DataHoraDestino);
            command.Parameters.AddWithValue("@passagem_vinculada", passagem.EstaVinculada);
        }
    }
}