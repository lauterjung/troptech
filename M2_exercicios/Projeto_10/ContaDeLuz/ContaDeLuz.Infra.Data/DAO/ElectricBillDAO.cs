using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ContaDeLuz.Domain;

namespace ContaDeLuz.Infra.Data.DAO
{
    public class ElectricBillDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=CONTADELUZDB; integrated security=true";

        public void AddElectricBill(ElectricBill electricBill)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"INSERT INTO Contas VALUES 
                                    (@numero_leitura, @data_leitura, @kw_gasto, @valor_a_pagar, @media_consumo, @data_pagamento);";
                    ObjectToSql(electricBill, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateElectricBill(ElectricBill electricBill)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"UPDATE Contas SET numero_leitura = @numero_leitura, data_leitura = @data_leitura, kw_gasto = @kw_gasto, valor_a_pagar = @valor_a_pagar, media_consumo = @media_consumo, data_pagamento = @data_pagamento WHERE numero_leitura = @numero_leitura;";

                    ObjectToSql(electricBill, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        internal void DeleteElectricBill(ElectricBill electricBill)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"DELETE FROM Contas WHERE numero_leitura = @numero_leitura;";

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@numero_leitura", electricBill.ReadingNumber);
                    command.ExecuteNonQuery();
                }
            }
        }

        public ElectricBill SearchElectricBillByReadingNumber(float readingNumber)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT *
                                    FROM Contas
                                    WHERE numero_leitura = @numero_leitura;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@numero_leitura", readingNumber);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ElectricBill electricBill = SqlToObject(reader);
                        return electricBill;
                    }
                }
            }
            return null;
        }

        public ElectricBill SearchElectricBillByUniqueDate(int year, int month)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT *
                                    FROM Contas
                                    WHERE YEAR(data_leitura) = @ano AND MONTH(data_leitura) = @mes;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@ano", year);
                    command.Parameters.AddWithValue("@mes", month);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ElectricBill electricBill = SqlToObject(reader);
                        return electricBill;
                    }
                }
            }
            return null;
        }

        public List<ElectricBill> SearchAllElectricBills()
        {
            List<ElectricBill> electricBillList = new List<ElectricBill>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT *
                                    FROM Contas;";
                    command.CommandText = sql;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        electricBillList.Add(SqlToObject(reader));
                    }
                }
            }
            return electricBillList;
        }

        public ElectricBill SqlToObject(SqlDataReader reader)
        {
            ElectricBill electricBill = new ElectricBill();

            electricBill.ReadingNumber = Convert.ToInt64(reader["numero_leitura"]);
            electricBill.ReadingDate = Convert.ToDateTime(reader["data_leitura"]);
            electricBill.PaymentDate = reader["data_pagamento"] as DateTime?;
            electricBill.ConsumedKw = Convert.ToDouble(reader["kw_gasto"]);
            electricBill.BillValue = Convert.ToDouble(reader["valor_a_pagar"]);
            electricBill.AverageConsumption = Convert.ToDouble(reader["media_consumo"]);

            return electricBill;
        }

        public void ObjectToSql(ElectricBill electricBill, SqlCommand command)
        {
            command.Parameters.AddWithValue("@numero_leitura", electricBill.ReadingNumber);
            command.Parameters.AddWithValue("@data_leitura", electricBill.ReadingDate);
            command.Parameters.AddWithValue("@data_pagamento", (electricBill.PaymentDate is null) ? DBNull.Value : electricBill.PaymentDate);
            command.Parameters.AddWithValue("@kw_gasto", electricBill.ConsumedKw);
            command.Parameters.AddWithValue("@valor_a_pagar", electricBill.BillValue);
            command.Parameters.AddWithValue("@media_consumo", electricBill.AverageConsumption);
        }
    }
}




