using System;

namespace AgenciaBancaria.Domain
{
    public class Client
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public Client(string cpf, string name, DateTime birthDate)
        {
            Cpf = cpf;
            Name = name;
            BirthDate = birthDate;
        }

        public Client()
        {

        }

        public override string ToString()
        {
            return $"CPF: {Cpf} - Nome: {Name} - Data Nascimento: {BirthDate}";
        }
    }
}