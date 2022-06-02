using System;
using System.Collections.Generic;

namespace A7
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa = new Pessoa();
            do
            {
                Console.Write("Digite o nome: ");
                pessoa.Name = Console.ReadLine();
            }
            while (pessoa.Name == "");
            Console.Write("Digite o pronome de tratamento: ");
            pessoa.Title = Console.ReadLine();
            Console.Write("Digite o ano de nascimento: ");
            pessoa.YearOfBirth = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite o telefone: ");
            pessoa.Cellphone = Console.ReadLine();
            
            pessoa.PrintData();
        }
    }
}
