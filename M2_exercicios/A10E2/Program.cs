using System;
using System.Collections.Generic;

namespace A10E2
{
    class Program
    {
        static void Main(string[] args)
        {
            var pessoa = new Pessoa("Miguel Busarello");
            System.Console.WriteLine(pessoa - "Busarello");
        }
    }
}
