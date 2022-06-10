using System;
using System.Collections.Generic;
using System.Numerics;

namespace A12E2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ABC TropTech Dicionário ABC");
            Console.WriteLine("Palavras contidas:");
            Dicionario dicionario = new Dicionario();
            foreach (string item in dicionario.Palavras)
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine();
            Console.WriteLine("Qual sistema de busca deseja utilizar?");
            Console.WriteLine("1) Contém P");
            Console.WriteLine("2) Começa com N");
            Console.WriteLine("3) Contém G");
            Console.WriteLine("4) Termina com O");
            string input = Console.ReadLine();

            IBuscador buscador;
            switch (input)
            {
                case "1":
                    buscador = new BuscadorContemP();
                    break;
                case "2":
                    buscador = new BuscadorComecaN();
                    break;
                case "3":
                    buscador = new BuscadorContemG();
                    break;
                case "4":
                    buscador = new BuscadorTerminaO();
                    break;
                default:
                    throw new Exception();
            }
            
            foreach (string item in dicionario.Buscar(buscador))
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
