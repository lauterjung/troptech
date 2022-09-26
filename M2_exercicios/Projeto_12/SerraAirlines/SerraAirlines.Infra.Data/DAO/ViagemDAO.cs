using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SerraAirlines.Domain;
using SerraAirlines.Domain.Enums;

namespace SerraAirlines.Infra.Data.DAO
{
    public class ViagemDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=SERRAAIRLINESDB; integrated security=true";

        public Viagem BuscarPorCodigo(string codigoReserva)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT v.codigo, v.data_hora_compra, v.valor_total, v.cpf, v.direcao, v.id_passagem_ida, v.id_passagem_volta, 
                    c.cpf AS cliente_cpf, c.nome, c.sobrenome, c.nome_completo, c.id_endereco,
                    e.cep, e.rua, e.bairro, e.numero, e.complemento,
                    p_i.id_passagem AS ida_id_passagem, p_i.origem AS ida_origem, p_i.destino AS ida_destino, p_i.valor AS ida_valor, p_i.data_hora_origem AS ida_data_hora_origem, p_i.data_hora_destino AS ida_data_hora_destino, p_i.passagem_vinculada AS ida_passagem_vinculada,
                    p_v.id_passagem AS volta_id_passagem, p_v.origem AS volta_origem, p_v.destino AS volta_destino, p_v.valor AS volta_valor, p_v.data_hora_origem AS volta_data_hora_origem, p_v.data_hora_destino AS volta_data_hora_destino, p_v.passagem_vinculada AS volta_passagem_vinculada
                    FROM Viagens v
                    JOIN Clientes c ON (c.cpf = v.cpf)
                    JOIN Enderecos e ON (c.id_endereco = e.id_endereco)
                    JOIN Passagens p_i ON (v.id_passagem_ida = p_i.id_passagem)
                    LEFT JOIN Passagens p_v ON (v.id_passagem_volta = p_v.id_passagem)
                    WHERE codigo = @codigo;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@codigo", codigoReserva);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Viagem viagem = SqlToObject(reader);
                        return viagem;
                    }
                }
            }
            return null;
        }

        public List<Viagem> BuscarTodasDeUmCliente(string cpf)
        {
            List<Viagem> listaViagens = new List<Viagem>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT v.codigo, v.data_hora_compra, v.valor_total, v.cpf, v.direcao, v.id_passagem_ida, v.id_passagem_volta, 
                    c.cpf AS cliente_cpf, c.nome, c.sobrenome, c.nome_completo, c.id_endereco,
                    e.cep, e.rua, e.bairro, e.numero, e.complemento,
                    p_i.id_passagem AS ida_id_passagem, p_i.origem AS ida_origem, p_i.destino AS ida_destino, p_i.valor AS ida_valor, p_i.data_hora_origem AS ida_data_hora_origem, p_i.data_hora_destino AS ida_data_hora_destino, p_i.passagem_vinculada AS ida_passagem_vinculada,
                    p_v.id_passagem AS volta_id_passagem, p_v.origem AS volta_origem, p_v.destino AS volta_destino, p_v.valor AS volta_valor, p_v.data_hora_origem AS volta_data_hora_origem, p_v.data_hora_destino AS volta_data_hora_destino , p_v.passagem_vinculada AS volta_passagem_vinculada
                    FROM Viagens v
                    JOIN Clientes c ON (c.cpf = v.cpf)
                    JOIN Enderecos e ON (c.id_endereco = e.id_endereco)
                    JOIN Passagens p_i ON (v.id_passagem_ida = p_i.id_passagem)
                    LEFT JOIN Passagens p_v ON (v.id_passagem_volta = p_v.id_passagem)
                    WHERE v.cpf = @cpf;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@cpf", cpf);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listaViagens.Add(SqlToObject(reader));
                    }
                }
            }
            return listaViagens;
        }

        public void Marcar(Viagem viagem)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"INSERT INTO Viagens VALUES (@codigo, @data_hora_compra, @valor_total, @cpf, @direcao, @id_passagem_ida, @id_passagem_volta);";

                    ObjectToSql(viagem, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public Viagem SqlToObject(SqlDataReader reader)
        {
            Viagem viagem = new Viagem();

            viagem.CodigoReserva = reader["codigo"].ToString();
            viagem.DataHoraCompra = Convert.ToDateTime(reader["data_hora_compra"]);

            viagem.Cliente.Cpf = reader["cliente_cpf"].ToString();
            viagem.Cliente.Nome = reader["nome"].ToString();
            viagem.Cliente.Sobrenome = reader["sobrenome"].ToString();
            viagem.Cliente.Endereco.Id = Convert.ToInt32(reader["id_endereco"].ToString());

            viagem.Cliente.Endereco.Cep = reader["cep"].ToString();
            viagem.Cliente.Endereco.Rua = reader["rua"].ToString();
            viagem.Cliente.Endereco.Bairro = reader["bairro"].ToString();
            viagem.Cliente.Endereco.Numero = Convert.ToInt32(reader["numero"]);
            viagem.Cliente.Endereco.Complemento = reader["cliente_cpf"] as string;
            
            viagem.PassagemIda.Id = Convert.ToInt32(reader["ida_id_passagem"]);
            viagem.PassagemIda.Origem = reader["ida_origem"].ToString();
            viagem.PassagemIda.Destino = reader["ida_destino"].ToString();
            viagem.PassagemIda.Valor = Convert.ToDouble(reader["ida_valor"]);
            viagem.PassagemIda.DataHoraOrigem = Convert.ToDateTime(reader["ida_data_hora_origem"]);
            viagem.PassagemIda.DataHoraOrigem = Convert.ToDateTime(reader["ida_data_hora_destino"]);
            viagem.PassagemIda.EstaVinculada = Convert.ToBoolean(reader["ida_passagem_vinculada"]);

            if (reader["volta_id_passagem"] != DBNull.Value)
            {
                viagem.PassagemVolta = new Passagem();
                viagem.PassagemVolta.Id = Convert.ToInt32(reader["volta_id_passagem"]);
                viagem.PassagemVolta.Origem = reader["volta_origem"].ToString();
                viagem.PassagemVolta.Destino = reader["volta_destino"].ToString();
                viagem.PassagemVolta.Valor = Convert.ToDouble(reader["volta_valor"]);
                viagem.PassagemVolta.DataHoraOrigem = Convert.ToDateTime(reader["volta_data_hora_origem"]);
                viagem.PassagemVolta.DataHoraOrigem = Convert.ToDateTime(reader["volta_data_hora_destino"]);
                viagem.PassagemVolta.EstaVinculada = Convert.ToBoolean(reader["volta_passagem_vinculada"]);
            }

            return viagem;
        }

        public void ObjectToSql(Viagem viagem, SqlCommand command)
        {
            command.Parameters.AddWithValue("@codigo", viagem.CodigoReserva);
            command.Parameters.AddWithValue("@data_hora_compra", viagem.DataHoraCompra);
            command.Parameters.AddWithValue("@valor_total", viagem.ValorTotal);
            command.Parameters.AddWithValue("@cpf", viagem.Cliente.Cpf);
            command.Parameters.AddWithValue("@direcao", viagem.TipoViagem);
            command.Parameters.AddWithValue("@id_passagem_ida", viagem.PassagemIda.Id);
            command.Parameters.AddWithValue("@id_passagem_volta", (viagem.PassagemVolta != null) ? viagem.PassagemVolta.Id : DBNull.Value);
        }
    }
}