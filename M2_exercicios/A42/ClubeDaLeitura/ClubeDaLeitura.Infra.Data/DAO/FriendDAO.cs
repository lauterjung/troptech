using System;
using ClubeDaLeitura.Domain;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ClubeDaLeitura.Infra.Data
{
    public class FriendDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=CLUBEDALEITURADB; integrated security=true";

        public void AddFriend(Friend friend)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"INSERT INTO Amigos VALUES 
                                    (@nome_amigo, @nome_mae, @telefone, @local_amigo);";
                    ObjectToSql(friend, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Friend> SearchAllFriends()
        {
            List<Friend> friendList = new List<Friend>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Amigos";
                    command.CommandText = sql;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        friendList.Add(SqlToObject(reader));
                    }
                }
            }
            return friendList;
        }

        public Friend SearchFriendById(string friendId)
        {
            Friend searchedFriend = new Friend();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Amigos WHERE id_amigo = @id_amigo;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@id_amigo", friendId);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        searchedFriend = SqlToObject(reader);
                    }
                }
            }
            return searchedFriend;
        }

        public Friend SearchFriendByName(string friendName)
        {
            Friend searchedFriend = new Friend();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT TOP(1) * FROM Amigos WHERE nome_amigo LIKE '%' + LOWER(@nome_amigo) +'%';";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@nome_amigo", friendName.ToLower());

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        searchedFriend = SqlToObject(reader);
                    }
                }
            }
            return searchedFriend;
        }

        public Friend SqlToObject(SqlDataReader reader)
        {
            Friend friend = new Friend();

            friend.FriendId = Convert.ToInt64(reader["id_amigo"]);
            friend.Name = reader["nome_amigo"].ToString();
            friend.MotherName = reader["nome_mae"].ToString();
            friend.Phone = reader["telefone"].ToString();
            friend.Place = (FriendPlaces)Enum.Parse(typeof(FriendPlaces), reader["local_amigo"].ToString());

            return friend;
        }

        public void ObjectToSql(Friend friend, SqlCommand command)
        {
            command.Parameters.AddWithValue("@nome_amigo", friend.Name);
            command.Parameters.AddWithValue("@nome_mae", friend.MotherName);
            command.Parameters.AddWithValue("@telefone", friend.Phone);
            command.Parameters.AddWithValue("@local_amigo", friend.Place);
        }
    }
}