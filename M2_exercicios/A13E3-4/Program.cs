using System;
using System.Collections.Generic;

namespace A13E2
{
    class Program
    {
        static void Main(string[] args)
        {
            Soma soma = new Soma();
            soma.X = 3;
            soma.Y = 2;
            System.Console.WriteLine(soma.Compute());
        }
    }
}

