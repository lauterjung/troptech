using System;

namespace primeiro_projeto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Qual é o nome da rua?");
            string rua = Console.ReadLine();
            Console.WriteLine("Qual é o bairro?");
            string bairro = Console.ReadLine();
            Console.WriteLine("Qual é a cidade?");
            string cidade = Console.ReadLine();
            Console.WriteLine("Qual é o número da casa?");
            string numero = Console.ReadLine();
            Console.WriteLine("Rua: " + rua);
            Console.WriteLine("Bairro: " + bairro);
            Console.WriteLine("Cidade: " + cidade);
            Console.WriteLine("Número da casa: " + numero);
        }
    }
}
