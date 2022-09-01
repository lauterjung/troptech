using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AgenciaBancaria.Domain;

namespace AgenciaBancaria.Infra.Data.DAO
{
    public class AccountDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=AGENCIABANCARIADB; integrated security=true";

        public void AddAccount(Account account)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"INSERT INTO Contas VALUES 
                                    (@numero, @digito, @agencia, @tipo, @saldo, @limite, @data_abertura, @cesta, @cpf);";
                    ObjectToSql(account, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Account> SearchAllAccounts()
        {
            List<Account> accountList = new List<Account>();

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
                        accountList.Add(SqlToObject(reader));
                    }
                }
            }
            return accountList;
        }

        public Account SearchAccountByClientId(string cpf)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT *
                                    FROM Contas co
                                    JOIN Clientes cl ON (co.cpf = cl.cpf)
                                    WHERE co.cpf = @cpf;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@cpf", cpf);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Account account = SqlToObject(reader);
                        return account;
                    }
                }
            }
            
            return null;
        }

        public Account SqlToObject(SqlDataReader reader)
        {
            Account account = new Account();

            account.AccountNumber = Convert.ToInt32(reader["numero"]);
            account.Digit = Convert.ToInt32(reader["digito"]);
            account.Branch = Convert.ToInt32(reader["agencia"]);
            account.Type = reader["tipo"].ToString();
            account.Balance = Convert.ToDouble(reader["saldo"]);
            account.Limit = reader["limite"] as Double?;
            account.OpeningDate = Convert.ToDateTime(reader["data_abertura"]);
            account.BusinessBasket = reader["cesta"] as Int32?;
            account.OwnerCpf = reader["cpf"].ToString();

            return account;
        }

        public void ObjectToSql(Account account, SqlCommand command)
        {
            command.Parameters.AddWithValue("@numero", account.AccountNumber);
            command.Parameters.AddWithValue("@digito", account.Digit);
            command.Parameters.AddWithValue("@agencia", account.Branch);
            command.Parameters.AddWithValue("@tipo", account.Type);
            command.Parameters.AddWithValue("@saldo", account.Balance);
            command.Parameters.AddWithValue("@limite", (account.Limit is null) ? DBNull.Value : account.Limit);
            command.Parameters.AddWithValue("@data_abertura", account.OpeningDate);
            command.Parameters.AddWithValue("@cesta", (account.BusinessBasket is null) ? DBNull.Value : account.BusinessBasket);
            command.Parameters.AddWithValue("@cpf", account.OwnerCpf);
        }
    }
}