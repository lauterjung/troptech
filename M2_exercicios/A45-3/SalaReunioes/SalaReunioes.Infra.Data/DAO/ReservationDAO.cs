using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SalaReunioes.Domain;

namespace SalaReunioes.Infra.Data.DAO
{
    public class ReservationDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=SECRETARIADB; integrated security=true";

        public void AddReservation(Reservation reservation)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"INSERT INTO Reservas VALUES 
                                    (@sala_id, @data_hora_inicio, @data_hora_fim, @nome_funcionario);";
                    
                    ObjectToSql(reservation, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Reservation> SearchAllReservations()
        {
            List<Reservation> reservationList = new List<Reservation>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT r.*
                                    FROM Reservas r
                                    JOIN Salas s ON (r.sala_id = s.sala_id);";
                    command.CommandText = sql;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        reservationList.Add(SqlToObject(reader));
                    }
                }
            }
            return reservationList;
        }

        public Reservation SqlToObject(SqlDataReader reader)
        {
            Reservation reservation = new Reservation();

            reservation.Id = Convert.ToInt32(reader["reserva_id"]);
            reservation.ReservationRoom.Id = Convert.ToInt32(reader["sala_id"]);
            reservation.StartDateTime = Convert.ToDateTime(reader["data_hora_inicio"]);
            reservation.EndDateTime = Convert.ToDateTime(reader["data_hora_fim"]);
            reservation.EmployeeName = reader["nome_funcionario"].ToString();

            return reservation;
        }

        public void ObjectToSql(Reservation reservation, SqlCommand command)
        {
            command.Parameters.AddWithValue("@sala_id", reservation.ReservationRoom.Id);
            command.Parameters.AddWithValue("@data_hora_inicio", reservation.StartDateTime);
            command.Parameters.AddWithValue("@data_hora_fim", reservation.EndDateTime);
            command.Parameters.AddWithValue("@nome_funcionario", reservation.EmployeeName);
        }
    }
}