using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AgenciaBancaria.Domain;
using AgenciaBancaria.Domain.Enums;

namespace AgenciaBancaria.Infra.Data.DAO
{
    public class ContractDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=AGENCIABANCARIADB; integrated security=true";

        public void AddContract(Contract contract)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"INSERT INTO Contratos VALUES 
                                    (@contrato_id, @tipo, @valor_total, @quantidade_parcelas, @valor_parcelas, @data_inicial, @data_final, @cpf);";
                    ObjectToSql(contract, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Contract> SearchAllContracts()
        {
            List<Contract> contractList = new List<Contract>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT ct.*, cl.nome AS nome_cliente
                                    FROM Contratos ct
                                    JOIN Clientes cl ON (ct.cpf = cl.cpf);";
                    command.CommandText = sql;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        contractList.Add(SqlToObject(reader));
                    }
                }
            }
            return contractList;
        }

        public List<Contract> SearchContractsByClientId(string cpf)
        {
            List<Contract> contractList = new List<Contract>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT ct.*, cl.nome AS nome_cliente
                                    FROM Contratos ct
                                    JOIN Clientes cl ON (ct.cpf = cl.cpf)
                                    WHERE ct.cpf = @cpf;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@cpf", cpf);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        contractList.Add(SqlToObject(reader));
                    }
                }
            }
            return contractList;
        }

        public Contract SearchContractByContractNumber(float ContractNumber)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT *
                                    FROM Contratos 
                                    WHERE contrato_id = @contrato_id;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@contrato_id", ContractNumber);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Contract contract = SqlToObject(reader);
                        return contract;
                    }
                }
            }
            return null;
        }

        public Contract SqlToObject(SqlDataReader reader)
        {
            Contract contract = new Contract();

            contract.Id = Convert.ToInt32(reader["contrato_id"]);
            contract.ContractType = (ContractTypes)Enum.Parse(typeof(ContractTypes), reader["tipo"].ToString());
            contract.TotalValue = Convert.ToDouble(reader["valor_total"]);
            contract.NumberOfInstallments = Convert.ToInt32(reader["quantidade_parcelas"]);
            contract.InstallmentValue = Convert.ToDouble(reader["valor_parcelas"]);
            contract.StartDate = Convert.ToDateTime(reader["data_inicial"]);
            contract.EndDate = reader["data_final"] as DateTime?;
            contract.ContractOwner.Cpf = reader["cpf"].ToString();
            contract.ContractOwner.Name = reader["nome_cliente"].ToString();
            
            return contract;
        }

        public void ObjectToSql(Contract contract, SqlCommand command)
        {
            command.Parameters.AddWithValue("@contrato_id", contract.Id);
            command.Parameters.AddWithValue("@tipo", contract.ContractType);
            command.Parameters.AddWithValue("@valor_total", contract.TotalValue);
            command.Parameters.AddWithValue("@quantidade_parcelas", contract.NumberOfInstallments);
            command.Parameters.AddWithValue("@valor_parcelas", contract.InstallmentValue);
            command.Parameters.AddWithValue("@data_inicial", contract.StartDate);
            command.Parameters.AddWithValue("@data_final", (contract.EndDate is null) ? DBNull.Value : contract.EndDate);
            command.Parameters.AddWithValue("@cpf", contract.ContractOwner.Cpf);
        }
    }
}