using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaReunioes.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string Phone { get; set; }

        public Employee(string name, string job, string phone)
        {
            Name = name;
            Job = job;
            Phone = phone;
        }

        public Employee()
        {

        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Job} - {Phone}";
        }
    }
}