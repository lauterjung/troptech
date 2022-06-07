using System;
using System.Collections.Generic;

namespace A9
{
    class Program
    {
        static void Main(string[] args)
        {
            Ficha ficha1 = new Ficha(1234, Ficha.Generos.FEMININO, "Escócia");
            Ficha ficha2 = new Ficha(1414, Ficha.Generos.MASCULINO, "Suécia");
            Corredores corredor = new Corredores(ficha1, "Corredora", "Rápida", 18.9);
            Arremessadores arremessador = new Arremessadores(ficha2, "Arremessador", "Forte");

            System.Console.WriteLine(corredor.NomeCompleto);
            System.Console.WriteLine(arremessador.NomeCompleto);

            Console.ReadLine();

            arremessador.RegistrarMarcas();

            Console.Clear();
            System.Console.WriteLine(corredor.ToString());
            System.Console.WriteLine(arremessador.ToString());
        }
    }
}
