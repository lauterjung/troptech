using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SalaReunioes.Domain;

namespace SalaReunioes.Infra.Data.DAO
{
    public class RoomDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=SECRETARIADB; integrated security=true";

        public List<Room> SearchAllRooms()
        {
            List<Room> RoomList = new List<Room>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT *
                                    FROM Salas;";
                    command.CommandText = sql;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        RoomList.Add(SqlToObject(reader));
                    }
                }
            }
            return RoomList;
        }

        public Room searchRoomByName(string roomName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT *
                                    FROM Salas 
                                    WHERE nome_sala = @nome_sala;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@nome_sala", roomName);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Room room = SqlToObject(reader);
                        return room;
                    }
                }
            }
            return null;
        }
        
        public Room SqlToObject(SqlDataReader reader)
        {
            Room room = new Room();

            room.Id = Convert.ToInt32(reader["sala_id"]);
            room.Name = (AvailableRooms)Enum.Parse(typeof(AvailableRooms), reader["nome_sala"].ToString());
            room.NumberOfSeats = Convert.ToInt32(reader["numero_lugares"]);

            return room;
        }

    }
}