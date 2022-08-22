using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace MercadoSeuZe.ClassLib
{
    public class Client
    {
        private string _cpf;
        public string Cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }
        
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        private double _fidelityPoints;
        public double FidelityPoints
        {
            get { return _fidelityPoints; }
            set { _fidelityPoints = value; }
        }

        private Address _clientAddress;
        public Address ClientAddress
        {
            get { return _clientAddress; }
            set { _clientAddress = value; }
        }

        public Client(string cpf, string name, DateTime birthDate, double fidelityPoints, Address address)
        {
            Cpf = cpf;
            BirthDate = birthDate;
            FidelityPoints = fidelityPoints;
            ClientAddress = address;
        }
        public Client(string cpf, string name, DateTime birthDate, Address address)
        {
            Cpf = cpf;
            BirthDate = birthDate;
            ClientAddress = address;
            FidelityPoints = 0;
        }

        public Client()
        {
            FidelityPoints = 0;
        }

        public override string ToString()
        {
            return $"{Cpf} - {Name} - {BirthDate} - {FidelityPoints} - {FidelityPoints} - {ClientAddress}";
        }
    }
}
